# FlexContextCnnStringLinker
C# tool: creates a versatile DLL/NuGet for .NET Framework and .NET Core. Enables projects to pass a connection string for customized DbContext usage. The idea of this project is work as an Interface for centralize the data operations and expose the services for the diverse services projects that need it. 
Made in .NET Standard 2.0, compatible with .NET Framework and .NET Core.
It should be noted that the entities, services and operations used are nothing more than examples

#Dependencies
Autofac
EntityFramework
Microsoft.Data.SqlClient
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.Extensions.Configuration.Abstraction
Microsoft.Extensions.DependencyInjection.Abstractions
Microsoft.SqlServer.Server
System.ComponentModel.Annotations
System.Data.SqlClient

#Instructions
- Can be consumed as Dll or Nuget Package, in the second case is mandatory to Compile the projects in Release mode config and publish the .nupkg file in a registry.
- The project includes a context to be initialized with EF Core, so it's essential to have EF Core installed even when consuming it from .NET Framework. The consistent approach is to pass the ConnectionString as a parameter through extension methods from the startup project. With this simple step, the context initializes, and dependency injections are performed.
- Is required to call the extension methods from the startup project
