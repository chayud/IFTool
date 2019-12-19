set mypath=%cd%

dotnet script %mypath%\PocosGenerator.csx -- output:Models.cs namespace:api.IFTool.Models config:..\appsettings.json connectionstring:ConnectionStrings:DefaultConnection dapper:true

@echo off
pause
