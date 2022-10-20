using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class ProductsByCategoryController : Controller
{
    private readonly ILogger<ProductsByCategoryController> _logger;

    private readonly SchemaContext _context;

    public ProductsByCategoryController(ILogger<ProductsByCategoryController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.ProductsByCategories.ToList());
    }
    
}

public partial class ProductsByCategory
{
    public string CategoryName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? QuantityPerUnit { get; set; }

    public short? UnitsInStock { get; set; }

    public bool Discontinued { get; set; }
}
