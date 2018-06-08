This **partials** directory is where to put snippets of CSS that can be
`@import`ed into other Sass files.

You should prefer to style our app/components/ in their own `.scss` file.
This keeps the scope of that styling local to the component. The build will
auto-prefix class names to avoid name collisions and if the component is not
loaded, then the styles won't load either.

We probably will need very few if any partials since component styling
covers the vast majority of what would otherwise go here.
