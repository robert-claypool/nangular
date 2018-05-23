nAngular: an Angular 6 and .NET starter
=======================================
This project demonstrates one way to build your frontend as an Angular 6
single page application (SPA) and host it within an ASP.NET MVC "wrapper"
app.

Why? Because sometimes you want authentication, some configuration, and
simple routing to be handled by ASP; meanwhile the Angular SPA sits inside
an MVC view (`Index.cshtml`) which is not reachable until your server
detects an authenticated and authorized user making the request.

* See [server/README.md](server/README.md) for server and database docs.

* See [client/README.md](client/README.md) for frontend docs.
