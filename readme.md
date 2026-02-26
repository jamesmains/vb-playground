# VB Playground
*This readme is a WIP as the projects expand and also I need to figure out why 3 projects are using 3 different .NET versions... Also some filepaths are PHs*
## Installation
### Linux
#### Install .NET SDK
* `sudo apt update`
* `sudo apt install dotnet-sdk-8.0`
### Mac
#### Install .NET SDK
* Download & Install(9.0): https://dotnet.microsoft.com/en-us/download/dotnet/9.0
### Extensions for VS Code
* C# Dev Kit or OmniSharp
## Start New Project
* `cd %your_target/path%`
* `dotnet new console -lang "VB"`
(*) = Project has different new project instructions.
## Run Project
* `cd %your_target/path%`
* `dotnet run`

## Projects

### 1_Beginner
This project was just for getting something running. This is an 'expenses' program to track and add expenses. There is no serialization or GUI (console app).

### 2_Generics
This was a conceptual project to better understand how VB treats generics.

### 3_Database
An expanded version of '1_Beginner' to save expenses tracked to a database. SQLite for the database and Dapper to automatically map parameterys in query executions.
#### Dependencies
* SQLite: `dotnet add package Microsoft.Data.Sqlite`
* Dapper: `dotnet add package Dapper`

### 4_Inventory(*)
#### Dependencies
* SQLite: `dotnet add package Microsoft.Data.Sqlite`
* Dapper: `dotnet add package Dapper`
* Avalonia: `dotnet new install Avalonia.Templates`
    (https://github.com/AvaloniaUI/avalonia-dotnet-templates)
#### New Project
##### Create Solution
* `cd %your_target/path%`
* `dotnet new sln`
###### Create VB Logic Project
* `dotnet new classlib -lang "VB" -o Inventory.Logic`
* `dotnet sln add Inventory.Logic`
##### Create C# UI
* `dotnet new avalonia.app -o Inventory.Desktop`
* `dotnet sln add Inventory.Desktop`
##### Link UI & Logic
* `cd Inventory.Desktop`
* `dotnet add reference ../Inventory.Logic/Inventory.Logic.vbproj`
#### Build
* `cd 4_Inventory`
* `dotnet run --project Inventory.Desktop`