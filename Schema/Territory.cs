using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class TerritoryController : Controller
{
    private readonly ILogger<TerritoryController> _logger;

    private readonly SchemaContext _context;

    public TerritoryController(ILogger<TerritoryController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.Territories.ToList());
    }
    
}

public partial class Territory
{
    public string TerritoryId { get; set; } = null!;

    public string TerritoryDescription { get; set; } = null!;

    public int RegionId { get; set; }

    public virtual Region Region { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
