nAngular: an opinionated Angular 6 and .NET starter
===================================================
This project demonstrates one way to build your frontend as an Angular 6
single page application (SPA) and host it within an ASP.NET MVC "wrapper"
app.

Why? Because sometimes you want authentication, some configuration, and
simple routing to be handled by ASP; meanwhile the Angular SPA sits inside
an MVC view (`_Layout.cshtml`) which is not reachable until your server
detects an authenticated and authorized user making the request.

* See [server/README.md](server/README.md) for server and database docs.

* See [client/README.md](client/README.md) for frontend docs.

## Features
This is an opinionated starter. It is based on Angular CLI 6 and includes:

* Angular Material
* Ngrx (store, router, effects, devtools)
* CSS Preprocessing of `*.scss` (SASS)
* Hot Module Replacement (HMR)
* The Git changeset hash of `HEAD` inserted into production JS and CSS files
* A modified `.browserlistrc` (change it to target whatever browsers you desire)
* Polyfills enabled for IE 9/10/11, see polyfills.ts
* `<noscript>` warning for browsers with disabled JavaScript
* Linting with rules to suit [Prettier](https://prettier.io/docs/en/why-prettier.html)
* Simple UserManagement WebAPI to be used as an example
* Unix style line endings (LF) for the Angular Client, Windows style (CRLF) for the server backend
* Configurations and code to prevent XSS and unnecessary information disclosures.
