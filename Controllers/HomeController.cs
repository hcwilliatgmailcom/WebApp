using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using System.Reflection;

namespace App.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        Assembly asm =  typeof(HomeController).Assembly;

        var controlleractionlist = asm.GetTypes()
        .Where(type=> typeof(Microsoft.AspNetCore.Mvc.Controller).IsAssignableFrom(type))
        .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
        .Where(m => !m.GetCustomAttributes(typeof( System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
        .Select(x => new {Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute",""))) })
        .OrderBy(x=>x.Controller).ThenBy(x => x.Action).ToList();

        ViewBag.controllers=controlleractionlist.Select(e=>e.Controller).Distinct();

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
