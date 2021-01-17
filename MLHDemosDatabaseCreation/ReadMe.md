# Databases and migrations 

## overview 

A load of stuff i have compiled from multiple sources to create a guide. 

We can work with a load of different databases using EFCore. 

The main concept is to have a code first agnostic approach to designing and querying databases. 

This means that you could replace the one database for another one and you code remains the same. 
in addition to this, you can create the same database again after again in different  providers and get the same result. 

... We all know we almost never do that, but it's a nice idea.



### How to do it from scratch

To do this from scratch. 
Install the below NuGet libraries 

Install-Package Microsoft.EntityFrameworkCore.Sqlite
Install-Package Microsoft.EntityFrameworkCore.Design

Create a console project and then reference the above libraries. 

TODO index:
Create the database
Create a migration that represents the structure of the database
Apply the new migration to create the database
Read from the database
Write to the database
Seed our database with initial data



### Learning Resources 

#### Main one to read

[Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

#### Really helpful background resources


[Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/?wt.mc_id=personal-blog-chnoring)

[Getting Started with EF Core](https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?wt.mc_id=personal-blog-chnoring&tabs=netcore-cli)

[EF Core in an ASP.NET MVC web app](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-2.2&wt.mc_id=personal-blog-chnoring)

[Database providers](https://docs.microsoft.com/en-us/ef/core/providers/?wt.mc_id=personal-blog-chnoring&tabs=dotnet-core-cli) 

[Loading Related Data - Eager loading](https://docs.microsoft.com/en-us/ef/core/querying/related-data/?wt.mc_id=personal-blog-chnoring)

Eager loading is more advanced but really worth learning. 

[Querying Data](https://docs.microsoft.com/en-us/ef/core/querying/?wt.mc_id=personal-blog-chnoring)

* Loading all data
* Loading a single entity
* Filtering
* TODO: must add these querying samples to APIs demo? 

[Basic Linq Query Operations](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations)


### Data design approaches 

#### Schema first, 
In this method, you would define your Database Schema, (tables etc) upon you database. most commonly on Microsoft SQL Server Management Studio.
though this method its can be a lot more work to provision all of the databases, but can add more in depth functionally if you are a experienced Database administrator. 
If your not a experienced Database administrator, you could end up not setting up table relationships correctly. 
for example making sure that all the necessary the necessary tables have the correct foreign keys and needed table indexes. 

At the End of this, you would need to reverse Engineer the Database with Migrations to generate the model structure in here. 

#### Code first, 
In this method, you would define your Database Schema within the entity models and db context first. 
In this approach, you can use agile methodologies to change and iterate the final database structure first before creating it upon a database.
This works out better as you can setup the same database again after again and get the same result.   


### migration Code 

#### Create a migration

```c#
dotnet ef migrations add InitialCreate
```

#### Undo a migration

```c#
dotnet ef migrations remove
```


#### Apply a migration to a database 

```c#
dotnet ef database update
```