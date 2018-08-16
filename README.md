# User & Groups

Application that allows you to manage users.You may create, read, edit and delete users and groups, as well as add and remove users from groups. 

## Getting Started

Clone or download repository. 

### Prerequisites

-restore the database backup(Users&Group.bak)
-change ConnectionString in UserRepository and GroupRepository so that Server suits your location.

## Running the tests

Unit test are in UGUnitTest project. 12 test - to run in Visual Studio.
They test whether returned model is proper.

## Built With
Microsoft Visual Studio Community 2017 version 15.3.2
Microsoft SQL Server 2014 Management studio 12.0.2000.8

## Acknowledgments

I started with building SQL Database.
Then build MVC project, with repositories for methods.Added models to suit database plus ViewModels for displaying. CSHTML with Razor. 
Before creating tests I added Interfaces to project, with dependency injection to controller. 
Created test project, with test repositories implementing interfaces.
Repositories does not have connection to database - they return test values.