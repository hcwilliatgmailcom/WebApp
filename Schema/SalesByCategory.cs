using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class SalesByCategoryController : Controller
{
    private readonly ILogger<SalesByCategoryController> _logger;

    private readonly SchemaContext _context;

    public SalesByCategoryController(ILogger<SalesByCategoryController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.SalesByCategories.ToList());
    }
    
}

public partial class SalesByCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal? ProductSales { get; set; }
}
