# Local Database Setup
Connect to whatever database you want. These docs will get you started on a
SQL Server Express named instance running 
[LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-2016-express-localdb):

1. Install [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express).

2. Create a named instance with `SqlLocalDB.exe create nangular`
   and `SqlLocalDB.exe start nangular`.

3. Open SQL Management Studio and execute `init.sql`.

4. Edit `<connectionStrings>` in `server\NAngular\Web.config` and
   and `server\NAngular.Tests\App.config` as needed.
