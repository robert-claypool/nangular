nAngular: an opinionated Angular 6 and .NET starter
===================================================
This project demonstrates one way to build your frontend as an Angular 6
single page application (SPA) and host it within an ASP.NET MVC "wrapper"
app.

Why? Because sometimes you want authentication, some configuration, and
simple routing to be handled by ASP; meanwhile the Angular SPA sits inside
an MVC view (`_Layout.cshtml`) which is not reachable until your server
detects an *authenticated* and *authorized* user making the request.

* See [server/README.md](server/README.md) for server and database docs.

* See [client/README.md](client/README.md) for frontend docs.

## Features
This is an opinionated starter. It is based on Angular CLI 6 and includes:

* Angular Material
* Ngrx (store, router, effects, devtools)
* CSS Preprocessing of `.scss` (SASS)
* Hot Module Replacement (HMR)
* The Git changeset hash of `HEAD` inserted into production JS and CSS files
* A modified `.browserlistrc` (change it to target whatever browsers you desire)
* Polyfills enabled for IE 9/10/11, see [polyfills.ts](client/nangular/src/polyfills.ts)
* A `<noscript>` warning for browsers with disabled JavaScript
* Linting with rules to suit [Prettier](https://prettier.io/docs/en/why-prettier.html)
* Simple user management WebAPI to be used as an example
* Unix-style line endings (LF) for the Angular client, Windows-style (CRLF) for the server backend
* Settings to prevent XSS and unnecessary info disclosures
* A documented build process which ties togeter the frontend and backend codebases, see below:

## How it Works
Our primary goal was to embed a fully functioning Angular app into a "wrapper" page hosted
by IIS and ASP.NET MVC. This is accomplished by some slight modifications to the MVC
project and a [`post-build.js`](client/nangular/post-build.js) script to help with
the embedding process:

1. Notice that `Views/Shared/_Layout.cshtml` is not in the repo but
   [`_LayoutTemplate.cshtml`](server/NAngular/Views/Shared/_LayoutTemplate.cshtml) is.
2. Notice also that `_Layout.cshtml` is [required](server/NAngular/NAngular.csproj) for
   the MVC app to run!

We need to create the layout file for MVC and test it:

1. Enter `client/nangular`. Run `npm install` and `npm run build`.
2. Open [`server/NAngular.sln`](server/NAngular.sln) and `F5` to debug.
3. View the page source in your browser. You'll see it is using files from
   `npm run build`, and in each file, you'll see that the first line includes a Git
   changeset hash; this can be useful for tracking down the source of an issue.

`_Layout.cshtml` will point to a new production build each time you run
[`npm run build`](client/nangular/package.json). Keep `_Layout.cshtml` out of Git
because it changes with every build.

## Use 'npm run start' for Development
The MVC layout points to files *copied* by `post-build.js`. This is fine if you aren't
constantly changing them, but for active development, those files are too old.

Solution: Continue to use all the hotness of Angular CLI. Run your frontend with
`npm run start` and keep http://localhost:4200 open duing development. This gives
real time feedback with Hot Module Replacement and debugging is easy with whatever
flavor of TypeScript debugger you prefer (I like VS Code with *'Debugger for Chrome'*).

For AJAX/API requests, run the MVC backend in Visual Studio (or another instance of
VS Code with *'C# for Visual Studio Code'*). It defaults to port `4201`, http://localhost:4201

So, development typically consists of running the backend and frontend in separate
IDEs, or if you aren't making changes to the frontend, then run the backend
alone because `_Layout.cshtml` should already point to a recent frontend build.
