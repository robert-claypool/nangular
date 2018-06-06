var shell = require('shelljs');

if (!shell.which('git')) {
  shell.echo('Error: This script requires Git.');
  shell.exit(1);
}

// https://stackoverflow.com/questions/949314/how-to-retrieve-the-hash-for-the-current-commit-in-git
var changeset = shell
  .exec('git rev-parse --short HEAD', { silent: true })
  .trim();

shell.cd('dist/nangular');
shell.ls('*.{js,css}').forEach(function(file) {
  // Insert at the start of our file because the end might have
  // a source map comment which needs to stay last.
  shell
    .ShellString(
      `/* The repo was at ${changeset} for this build. Uncommitted edits in the working directory may have also contributed. */\n` +
        shell.cat(file)
    )
    .to(file);
});
