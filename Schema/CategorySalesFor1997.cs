using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class CategorySalesFor1997Controller : Controller
{
    private readonly ILogger<CategorySalesFor1997Controller> _logger;

    private readonly SchemaContext _context;

    public CategorySalesFor1997Controller(ILogger<CategorySalesFor1997Controller> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.CategorySalesFor1997s.ToList());
    }
    
}

public partial class CategorySalesFor1997
{
    public string CategoryName { get; set; } = null!;

    public decimal? CategorySales { get; set; }
}
