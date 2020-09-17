# core.api
.NET Core API in C#, swagger and Entity Framework Core

To obtain the code, clone the solution on your local drive
This is a simple restful api developed in visual studio 2019 with .NET Core 3.1
The APIs are documented with swagger
(to install for latest version, go to Package Manager Console in visual studio)
PM> Install-Package Swashbuckle

The project has access to the database via Entity Framework Core
(to install for latest version, go to Package Manager Console in visual studio)
PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer

Before you run the solution, make sure you have SQL Server instance somewhere local or remote
Edit the CommerceContext to change the connection strings as per your Sql Server instance

Go to the Package Manager Console and type the following command to create the migration script 
PM> Add-Migration InitialMigration
(if you decide to re-run the migration, either delete the files in the migration folder or change the name of the migration instance)

Once migration is successful, run the following command to apply the migration onto a physical database and import data
PM> Update-Database

At this point, the database should be there and some dummy values added

Run the solution to load the swagger documentation for the API. Here you can execute the methods as desired with the correct inputs.

Enjoy the technology !
