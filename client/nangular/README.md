This project was generated with
[Angular CLI](https://github.com/angular/angular-cli) version 6.0.3.

## Development server

Run `npm run start` to run the app.

Do *not* use 'ng serve' because it will not enable Hot Module Replacements (HMR).

Navigate to `http://localhost:4200/`.
The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component`. Include the name, parent module, SCSS for
styles, and `--spec` to create a spec file:

```Shell
# Create a 404 Not Found component.
ng generate component not-found --spec --styleext scss --module app.module.ts
```

You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `npm run build`.

1. Do *not* use 'ng build' because it won't optimize the output like we need
     and it won't run [`post-build.js`](post-build.js).
2. The build artifacts will be written to `dist/` and `post-build.js` copies
     them to certain folders in `server/NAngular`.

## Running unit tests

Run `ng test` to execute the unit tests via
[Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via
[Protractor](http://www.protractortest.org/).

## Further help

To get more help on Angular CLI use `ng help` or go check its
[README](https://github.com/angular/angular-cli/blob/master/README.md).
