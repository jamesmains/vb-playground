This is a simple project to explore VB (specifically in the context of .Net)

## Installation
### Linux
* Install .NET SDK
* `sudo apt update`
* `sudo apt install dotnet-sdk-8.0`
### Extensions for VS Code
* C# Dev Kit or OmniSharp
## Start New Project
* `cd %your_target/path%`
* `dotnet new console -lang "VB"`
Run Project
dotnet run

## Projects

### 1 Beginner
This project was just for getting something running. This is an 'expenses' program to track and add expenses. There is no serialization or GUI (console app).

### 2 Generics
This was a conceptual project to better understand how VB treats generics.

### 3 Database

#### Dependencies
SQLite: `dotnet add package Microsoft.Data.Sqlite`
Dapper: `dotnet add package Dapper`