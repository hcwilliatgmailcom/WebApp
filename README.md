dotnet add package MySql.EntityFrameworkCore
dotnet tool install --global dotnet-ef
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlserver
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
ssh-keygen
cat /home/hcwilli/.ssh/id_rsa.pub
ssh ssh-w011d2f0@hcwilli.at
cd hcwilli.at
git clone https://github.com/datacharmer/test_db.git
mysql -u d03adb48 -D d03adb48 -p -t < load_departments.dump
mysql -u d03adb48 -D d03adb48 -p -t < load_departments.dump
mysql -u d03adb48 -D d03adb48 -p -t < load_employees.dump
mysql -u d03adb48 -D d03adb48 -p -t < load_dept_emp.dump
mysql -u d03adb48 -D d03adb48 -p -t < load_dept_manager.dump
mysql -u d03adb48 -D d03adb48 -p -t < load_titles.dump
k8J3CMGz7sL68rJW

source load_salaries1.dump ;
source load_salaries2.dump ;
source load_salaries3.dump ;
 
dotnet ef dbcontext scaffold "server=hcwilli.at;database=d03adb48;user=d03adb48;password=k8J3CMGz7sL68rJW" MySql.EntityFrameworkCore --context-dir Data --output-dir Data
dotnet-aspnet-codegenerator  controller  -m Ticket -dc d03adb48Context  --referenceScriptLibraries --useDefaultLayout --controllerName TicketController --relativeFolderPath Controllers
dotnet-aspnet-codegenerator  controller  -m Department -dc d03adb48Context  --restWithNoViews --controllerName DepartmentApiController --relativeFolderPath Controllers

Assembly asm = Assembly.GetExecutingAssembly();

var controlleractions = asm.GetTypes()
        .Where(type=> typeof(Controller).IsAssignableFrom(type))
        .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
        .Where(m => !m.GetCustomAttributes(typeof( System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
        .Select(x => new {
            Controller = x.DeclaringType.Name
            , Action = x.Name
            , ReturnType = x.ReturnType.Name
            , Attributes = x.GetCustomAttributes()//= String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute",""))) 
            })
        .OrderBy(x=>x.Controller).ThenBy(x => x.Action).ToList();