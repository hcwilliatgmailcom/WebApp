using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class ProductsAboveAveragePriceController : Controller
{
    private readonly ILogger<ProductsAboveAveragePriceController> _logger;

    private readonly SchemaContext _context;

    public ProductsAboveAveragePriceController(ILogger<ProductsAboveAveragePriceController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.ProductsAboveAveragePrices.ToList());
    }
    
}

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
