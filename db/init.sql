-- This creates a SQL Express LocalDB in App_Data.
-- Replace C:\PATH\TO\REPO\ as needed.
If(db_id(N'nangular') IS NULL)
BEGIN
  SELECT 'Creating database...'
  CREATE DATABASE [nangular]
   CONTAINMENT = NONE
   ON PRIMARY
  ( NAME = N'nangular',
   FILENAME = N'C:\PATH\TO\REPO\nangular\server\nangular\App_Data\nangular.mdf',
   SIZE = 8192KB,
   FILEGROWTH = 65536KB )
   LOG ON
  ( NAME = N'nangular_log',
   FILENAME = N'C:\PATH\TO\REPO\nangular\server\nangular\App_Data\nangular_log.ldf',
   SIZE = 8192KB,
   FILEGROWTH = 65536KB )
END
ELSE
BEGIN
  SELECT 'Database already exists.'
  -- DROP DATABASE nangular;
END
