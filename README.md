### Introduction
This is a RESTful api for managing geospatials.
A geospatial is record in a GeoJson(https://geojson.org/) file from UK Gov data. 
This app shows an example of managing ColdCallingControlledZone(http://data.cyc.opendata.arcgis.com/datasets/1debe34bd98443c0a5497e0a2a451d7d_6.geojson)

### Features
- [X] ColdCallingControlledZone - CRUD geospatial to MSSql database

### Running the application locally

**Prerequisite:** 
- [MSSql Express](https://go.microsoft.com/fwlink/p/?linkid=2216019&clcid=0x809&culture=en-gb&country=gb)
- [.Net Core 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.401-windows-x64-installer)

1. Clone this repository onto your machine
2. Create tables in database using (EgretApi\DbScripts\Create_Geospatial_Tables.sql)
3. Amend [Data Source] and [Initial Catalog] in appsettings.Development.json
4. Install
```
dotnet restore
```
5. Run
```
dotnet run
```

The application will then be accessible at:

http://localhost:5001/swagger/index.html

### Running unit tests
```
dotnet test
```

### Technology stack used
- [X] C# ASP.Net 7.0
- [X] MSSql
