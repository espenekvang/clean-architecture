# clean-architecture

Repo for clean architecture workshop.
Implementasjonen er inspirert av Clean Architecture fra https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html

Strukturen i repoet i "src"-mappen er som følger:

1. **Domain**  
   Entiteter, valuetypes, aggregater
2. **Application**  
   Applikasjonslogikk, query og command handlere
3. **Infrastructure**  
   Database, eksterne tjenester, repsitorier
4. **Web**  
   Controllere, dependency injection setup ++

**Domain** er den innerste delen av arkitekturen og skal derfor ikke referere til noe annet lag.
**Application** kan bare referere til **Domain**.  
**Infrastructure** kan referere til **Application** og **Domain**.  
**Web** er ytterst og kan dermed kjenne til alle lag.

## Forutsetninger

- .NET 6.0 https://dotnet.microsoft.com/en-us/download/dotnet/6.0
- Editor (Visual studio code, Visual Studio, Rider)

## Kjøre applikasjonen

- Åpne en terminal der .NET CLI er tilgjengelig
- Navigèr til `src\Web` og skriv `dotnet run` etterfulgt av enter:

```
~\clean-architecture\src\Web> dotnet run
```

- Noe som dette bør vises i konsollet:

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

- OpenAPI-spec: `https://localhost:7233/swagger/index.html` 

## Postman collection

`clean-architecture-postman-collection.json` er en postman collection med ressurser som representerer de ulike use casene i workshopen.

# Use caser for workshopen
- (En kunde skal kunne opprettes fra et navn, legal id, legal country.)
- (En kunde skal kunne hentes vha id)
- Alle kunder skal kunne hentes ut 
- En kunde skal kunne få lagt til målepunkter (id, navn, addresse, strømsone).
- En kunde skal kunne si opp et målepunkt og beholde eventuelle andre målepunkter. 
- En kunde skal kunne se detaljer om alle målepunktene sine (strømsone, anleggsaddresse, et egendefinert navn f.eks. «hytta», status, type). 
- En kunde skal kunne se hva forbruket har vært på et gitt målepunkt i et gitt tidsrom.



