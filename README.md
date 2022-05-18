# clean-architecture

Repo for clean architecture workshop

## Prerequisite

- .NET 6.0 https://dotnet.microsoft.com/en-us/download/dotnet/6.0
- Editor of choice (Visual studio code, Visual Studio, Rider)

## Running the application

- Open terminal of choice where .NET CLI is available
- Navigate to `src\Web` and type `dotnet run` followed by enter:

```
~\clean-architecture\src\Web> dotnet run
```

- Something like this should display in the console:

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7233
      Now listening on: http://localhost:5233
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\dev\clean-architecture\src\Web\
```

- By navigating to `https://localhost:7233/swagger/index.html` you should be able to se the openapi specification for the api
