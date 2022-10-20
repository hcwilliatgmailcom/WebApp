dotnet new mvc
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-ef 
dotnet add package  
dotnet user-secrets init
dotnet user-secrets set ConnectionStrings:MySql "server=hcwilli.at;database=d03adb48;user=d03adb48;password=k8J3CMGz7sL68rJW"
dotnet ef migrations add Start
dotnet ef database update
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design 
dotnet add package Microsoft.EntityFrameworkCore.Sqlserver
dotnet-aspnet-codegenerator  controller  -m Product -dc SchemaContext  --referenceScriptLibraries --useDefaultLayout --controllerName ProductController --relativeFolderPath Controllers
dotnet ef dbcontext scaffold "server=hcwilli.at;database=d03adb48;user=d03adb48;password=k8J3CMGz7sL68rJW" MySql.EntityFrameworkCore
select concat('create view ',table_name,' as select * from information_schema.',table_name,';') FROM `INFORMATION_SCHEMA`.`TABLES`
dotnet ef dbcontext scaffold "server=hcwilli.at;database=d03adb48;user=d03adb48;password=k8J3CMGz7sL68rJW;" MySql.EntityFrameworkCore  --output-dir Schema --context SchemaContext --context-dir Schema
select concat('create view `ZZZ_',table_name,'` as select * from information_schema.`',table_name,'`;') FROM `INFORMATION_SCHEMA`.`TABLES` where table_schema='information_schema'
dotnet ef dbcontext scaffold "Server=localhost;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer  --output-dir Schema --context SchemaContext --context-dir Schema -f
https://github.com/dotnet/efcore/tree/main/src/EFCore.Design/Scaffolding/Internal

CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `d03adb48`@`%` 
    SQL SECURITY DEFINER
VIEW `Entity` AS
    SELECT 
        `information_schema`.`TABLES`.`TABLE_NAME` AS `ID`,
        `information_schema`.`TABLES`.`TABLE_NAME` AS `Name`
    FROM
        `INFORMATION_SCHEMA`.`TABLES`
    WHERE
        `information_schema`.`TABLES`.`TABLE_SCHEMA` = DATABASE()
            AND `information_schema`.`TABLES`.`TABLE_TYPE` = 'BASE TABLE';




 
  
  


 