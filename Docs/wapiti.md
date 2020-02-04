# Wapiti

## Generator scripts

Scripts used to generate several parts of the project

### Controllers

```
cd Src/Wapiti.Api
dotnet aspnet-codegenerator controller -name CardsController -async -api -m Card -dc WapitiDbContext -outDir Controllers
dotnet aspnet-codegenerator controller -name CollectionsController -async -api -m Collection -dc WapitiDbContext -outDir Controllers
dotnet aspnet-codegenerator controller -name DecksController -async -api -m Deck -dc WapitiDbContext -outDir Controllers
dotnet aspnet-codegenerator controller -name DeckBoardsController -async -api -m DeckBoard -dc WapitiDbContext -outDir Controllers
```

### DB using EF core

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
