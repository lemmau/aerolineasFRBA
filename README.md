# [UTN-FRBA] AerolineasFRBA - GDD-2C2015
## Directorios
 
* `code`: codigo C#, proyectos del VS , etc.
* `doc`: DB a migrar, documentación, diagramas, enunciado, estrategia de resolución, etc.
* `sql`: scripts de creación de tablas, stored procedures, functions, etc.

> DER: https://drive.draw.io/#G0B9xE2Vns3l-xUFJMWDNWX3lGYlk


![alt tag](https://github.com/lemmau/aerolineasFRBA/blob/master/images/HAY_TABLA.png)


## Notas

Para correr la App, recordar tener la DB arriba y en ejecución !

En caso de errores, revisar la siguiente configuración:


* Login MS SQL Server: 
 Server Name: `SQLSERVER2012`
 Username: `gd`
 Password: `gd2015`
* code > AerolineaFrba > AerolineaFrba > App.config
línea: `<add connectionString="Server=.\SQLSERVER2012;Database=GD2C2015;User Id=gd; Password=gd2015;" providerName="" name="gdd"></add>`
* sql > script_creacion_inicial.sql
 línea: `USE [GD2C2015]`
