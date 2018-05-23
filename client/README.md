nAngular Frontend
=================

# Introduction
This is 'nAngular Client', our frontend SPA written in Angular 6 TypeScript!

# Initial Setup
We use Angular CLI for development and for building production deployments.

* https://cli.angular.io/

## 1. Setup Node with NVM
Check `.nvmrc` for the recommended version of NodeJS.
The original Node Version Manager (NVM) does not run on Windows, use
[nvm-windows](https://github.com/coreybutler/nvm-windows) instead,
but beware that it doesn't support reading `.nvmrc` files so you'll
need to explicitly enter the version number you want, see
https://github.com/coreybutler/nvm-windows/issues/128

Check [.nvmrc](.nvmrc) and install whatever version is specified in that file.
Don't try to install and manage Node without a version manager. NVM works
better.

## 2. Install TypeScript and the Angular CLI

```Shell
npm install --global typescript
npm install --global @angular/cli
ng --version
```

The version should be 6.0.0 or higher.

```Shell
# Now you should have the `ng` command installed globally on your system:
ng version
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
Now that you have the proper command line tools, install Node packages (which
are specified in `package.json`) and run the app:

```Shell
cd client/nangular
npm install
ng serve
```

Navigate to `http://localhost:4200/`. The app will automatically reload if
you change any of the source files.

