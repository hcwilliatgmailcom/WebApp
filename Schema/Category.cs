using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;

    private readonly SchemaContext _context;

    public CategoryController(ILogger<CategoryController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.Categories.ToList());
    }
    
}

public partial class Category
{
    /// <summary>
    /// TestComment
    /// </summary>
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    /// <summary>
    /// Testcomment
    /// </summary>
    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
