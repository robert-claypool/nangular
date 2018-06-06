# Introduction
This folder is to save/share performance reports.

We use [Google Lighthouse](https://github.com/GoogleChrome/lighthouse) to
audit site performance and compare results against our "baseline" scores in
[2018-06-04.report.html](2018-06-04.report.html). Only small deviations from
that initial Lighthouse report should be allowed as the application grows.

Use Lighthouse as a tool to find and remove technical debts that impact
site performance.

# Installation and Use
Lighthouse is listed in [`package.json`](../nangular/package.json)
`devDependencies`; use `npm install`.

Lighthouse can analyze locally hosted sites without an Internet connection.

To test a development build:
```Shell
cd client/nangular
# Run Webpack's dev server
ng serve
# Open another terminal, then...
cd client/performance-reports
npm run lighthouse -- http://localhost:4200 # change port as necessary
```

To test a production build:
```Shell
cd client/nangular
ng build --prod
cd dist/nangular
http-server # run in a lightweight web server, https://www.npmjs.com/package/http-server
# Open another terminal, then...
cd client/performance-reports
npm run lighthouse -- http://localhost:8080 # change port as necessary
```

It's production builds that really matter. (We expect dev builds
to be slower because Webpack dev server is not optimizing for performance.)