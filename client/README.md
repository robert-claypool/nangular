nAngular Client
===============

# Introduction
This is 'nAngular Client', our front end SPA written in Angular 6 TypeScript!

# Initial Setup
We use Angular CLI for dev work and production deployments.

* https://cli.angular.io/

## 1. Setup Node with NVM
Check `.nvmrc` for the recommended version of Node.
The original Node Version Manager (NVM) does not run on Windows, use
[nvm-windows](https://github.com/coreybutler/nvm-windows) instead,
but beware that it doesn't support reading `.nvmrc` files so you'll
need to explicitly enter the version number you want, see
https://github.com/coreybutler/nvm-windows/issues/128

Check [.nvmrc](.nvmrc) and install whatever version is specified in that file.
Don't try to install and manage Node without a version manager, NVM works
better.

## 2. Install TypeScript and the Angular CLI

```Shell
npm install --global typescript
npm install --global @angular/cli
ng --version
```

The version should be 6.0.0 or higher.

```Shell
#     _                      _                 ____ _     ___
#    / \   _ __   __ _ _   _| | __ _ _ __     / ___| |   |_ _|
#   / △ \ | '_ \ / _` | | | | |/ _` | '__|   | |   | |    | |
#  / ___ \| | | | (_| | |_| | | (_| | |      | |___| |___ | |
# /_/   \_\_| |_|\__, |\__,_|_|\__,_|_|       \____|_____|___|
#                |___/
# Angular CLI: 6.0.3
# Node: 8.11.2
```

## 3. Install Node Packages, Go!
Now that you have the proper tools, install Node packages (which are
specified in `package.json`) and run the app:

```Shell
cd nangular/
npm install
ng serve
```

Go to `http://localhost:4200/`. The app will auto reload if you edit
source files. (Hot Module Replacement)

# Developing with Angular CLI

## Code scaffolding

Run `ng generate component component-name` to generate a new component.
You can also use `ng generate directive/pipe/service/class/module`.

## Build

Run `ng build` to build the project.
See [Deployment](#deployment) for more info.

## Running unit tests

Run `ng test` for unit tests with [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` for end-to-end tests with [Protractor](http://www.protractortest.org/).
Before running these tests, make sure you are serving the app with `ng serve`.

# Dev and Debugging
Run `ng serve`, this launches a Webpack dev server.

[VS Code](https://code.visualstudio.com/) is a free and lightweight IDE which
can attach to the process of `ng serve`. It has strong support for TypeScript
intellisense, and it provides an excellent editing/debugging experience for
Angular apps.

# Deployment
It's important to use Angular CLI for production builds. Why? Because the
"ng" build process uses Webpack which is correctly configured to do
[nice things](https://github.com/angular/angular-cli/wiki/build) like
bundling, tree shaking, cache burst hashing, and dead code removal.

In case it's not obvious, Visual Studio and msbuild have nothing to contribute
to the frontend build process; this is a pure TypeScript/Angular application,
and while you can use Visual Studio as a code editor, you shouldn't use
Visual Studio to build this frontend.

```Shell
# This example assumes you will host the contents of /dist at a URL like
# https://example.org/nangular (where "nangular" is the root path
# to the site for that domain).
ng build --base-href '/nangular/' --target=production
 ```

`ng build` creates a `/dist` folder which contains an entirely
static website (no server-side rendering or runtime is needed to host the
site, all you need is a minimal web server which responds to requests for
static files).

On Windows, use IIS to host the contents of `/dist`. You don't need ASP or
.NET for this site, just copy the contents of `/dist` into something like
`C:\inetpub\wwwroot\nangular`, and finally, convert
`C:\inetpub\wwwroot\nangular` into a virtual directory in IIS.

Check out the sample `Web.config` for IIS at `nangular/Web.config`.

# Further help

To get more help on Angular CLI use `ng help` or go check the
[Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
