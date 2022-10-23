dotnet new mvc
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-ef 
dotnet user-secrets init
dotnet user-secrets set ConnectionStrings:MySql "server=hcwilli.at;database=d03adb48;user=d03adb48;password=k8J3CMGz7sL68rJW"
dotnet ef dbcontext scaffold "Server=localhost;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer  --output-dir Data/hcwilli/Northwind --context NorthwindContext --context-dir Data/hcwilli/Northwind -f
dotnet ef dbcontext scaffold Name=ConnectionStrings:MySql MySql.EntityFrameworkCore  --output-dir Data/hcwilli.at/d03adb48 --context d03adb48Context --context-dir Data/hcwilli.at/d03adb48
dotnet-aspnet-codegenerator  controller  -m Product -dc NorthwindContext  --referenceScriptLibraries --useDefaultLayout --controllerName ProductController --relativeFolderPath Controllers -f
dotnet ef migrations add Start --context d03adb48Context
dotnet ef migrations add Product --context d03adb48Context
dotnet ef database update --context d03adb48Context
dotnet-aspnet-codegenerator  controller  -m App.Data.hcwilli.Northwind.Product -dc NorthwindContext  --referenceScriptLibraries --useDefaultLayout --controllerName ProductController --relativeFolderPath Controllers -f 
dotnet-aspnet-codegenerator  controller  -m App.Data.hcwilli.at.d03adb48.Product -dc d03adb48Context  --referenceScriptLibraries --useDefaultLayout --controllerName ProductController --relativeFolderPath Controllers -f

https://github.com/dotnet/efcore/tree/main/src/EFCore.Design/Scaffolding/Internal
https://github.com/telerik/scaffold-templates-core/blob/master/Templates/ViewGenerator/Create.cshtml
 

