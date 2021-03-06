# clean-architecture

Repo for clean architecture workshop.
The implementation is based on the Clean Architecture from https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html

Th structure within the `src` folder in this repo is as follows:

1. **Domain**  
   Entities, valuetypes, aggregates, factories, repositories
2. **Usecase**  
   Use cases with application logic
3. **Infrastructure**  
   Database, external services++
4. **Web**  
   Entrypoint med api controllere, DI-setup etc

**Domain** is the innermost part of the architecture, hence it cannot refer to any other layer.  
**Usecase** can only refer to **Domain**.  
**Infrastructure** can refer to **Usecase** and **Domain**.  
**Web** is outer most layer and can reference all other layers.

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

## Postman collection

The `clean-architecture-postman-collection.json` is a postman collection with resources to represent the different use cases in the workshop.
