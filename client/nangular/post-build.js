var sh = require('shelljs');

if (!sh.which('git')) {
  sh.echo('Error: This script requires Git.');
  sh.exit(1);
}

// https://stackoverflow.com/questions/949314/how-to-retrieve-the-hash-for-the-current-commit-in-git
var changeset = sh.exec('git rev-parse --short HEAD', { silent: true }).trim();

sh.cd('dist/nangular');
sh.ls('*.{js,css}').forEach(function(file) {
  // Insert at the start of our file because the end might have
  // a source map comment which needs to stay last.
  sh.ShellString(
    `/* The repo was at ${changeset} for this build. Uncommitted edits in the working directory may have also contributed. */\n` +
      sh.cat(file)
  ).to(file);
});

// Create a layout from our template.
// The template is under source control, but this generated layout is not since it changes each build.
var layoutsPath = '../../../../server/NAngular/Views/Shared/';
sh.cp(layoutsPath + '_LayoutTemplate.cshtml', layoutsPath + '_Layout.cshtml');

// Clean up our target folders.
var stylesPath = '../../../../server/NAngular/Content/SPA/';
sh.rm(stylesPath + '*.css');
var scriptsPath = '../../../../server/NAngular/Scripts/SPA/';
sh.rm(scriptsPath + '*.js');

var styleTags;
var scriptTags;
var indent = '    ';

// Now copy our build files and inject them as <style> and <script> tags into the layout...
// Keep <style> and <script> tags in the correct runtime load order!

sh.ls('styles*.css').forEach(function(file) {
  // Exists only for PRODUCTION builds.
  styleTags = `<link href="Content\/SPA\/${file}" rel="stylesheet">`;
  sh.cp(file, stylesPath);
});
if (styleTags) {
  sh.sed(
    '-i',
    '<!--POST-BUILD.JS_STYLES_GO_HERE-->',
    styleTags,
    layoutsPath + '_Layout.cshtml'
  );
}

sh.ls('runtime*.js').forEach(function(file) {
  // Exists for PRODUCTION builds.
  scriptTags = `<script src="Scripts\/SPA\/${file}"><\/script>\r\n`;
  sh.cp(file, scriptsPath);
});
sh.ls('polyfills*.js').forEach(function(file) {
  // Exists for PRODUCTION & DEVELOPMENT builds.
  scriptTags =
    scriptTags + indent + `<script src="Scripts\/SPA\/${file}"><\/script>\r\n`;
  sh.cp(file, scriptsPath);
});
sh.ls('styles*.js').forEach(function(file) {
  // Exists for DEVELOPMENT builds.
  scriptTags =
    scriptTags + indent + `<script src="Scripts\/SPA\/${file}"><\/script>\r\n`;
  sh.cp(file, scriptsPath);
});
sh.ls('vendor*.js').forEach(function(file) {
  // Exists for DEVELOPMENT builds.
  scriptTags =
    scriptTags + indent + `<script src="Scripts\/SPA\/${file}"><\/script>\r\n`;
  sh.cp(file, scriptsPath);
});
sh.ls('main*.js').forEach(function(file) {
  // Exists for PRODUCTION & DEVELOPMENT builds.
  scriptTags =
    scriptTags + indent + `<script src="Scripts\/SPA\/${file}"><\/script>`;
  sh.cp(file, scriptsPath);
});

sh.sed(
  '-i',
  '<!--POST-BUILD.JS_SCRIPTS_GO_HERE-->',
  scriptTags,
  layoutsPath + '_Layout.cshtml'
);

sh.echo('');
sh.echo('-------------------------------');
sh.echo(`-- Done, build ID is ${changeset} --`);
sh.echo('-------------------------------');
