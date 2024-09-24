# Easy Peasy Migration Readme

## Add migration 

``dotnet ef migrations add MigrationName -s ../EasyPeasy.Api/EasyPeasy.Api.csproj -o ./Migrations``

## Update database

``dotnet ef database update -s ../EasyPeasy.Api/EasyPeasy.Api.csproj --verbose``
