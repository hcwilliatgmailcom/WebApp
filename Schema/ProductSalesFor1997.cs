using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class ProductSalesFor1997Controller : Controller
{
    private readonly ILogger<ProductSalesFor1997Controller> _logger;

    private readonly SchemaContext _context;

    public ProductSalesFor1997Controller(ILogger<ProductSalesFor1997Controller> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.ProductSalesFor1997s.ToList());
    }
    
}

public partial class ProductSalesFor1997
{
    public string CategoryName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal? ProductSales { get; set; }
}
