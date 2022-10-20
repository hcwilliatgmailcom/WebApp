using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class CurrentProductListController : Controller
{
    private readonly ILogger<CurrentProductListController> _logger;

    private readonly SchemaContext _context;

    public CurrentProductListController(ILogger<CurrentProductListController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.CurrentProductLists.ToList());
    }
    
}

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
