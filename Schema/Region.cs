using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class RegionController : Controller
{
    private readonly ILogger<RegionController> _logger;

    private readonly SchemaContext _context;

    public RegionController(ILogger<RegionController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.Regions.ToList());
    }
    
}

public partial class Region
{
    public int RegionId { get; set; }

    public string RegionDescription { get; set; } = null!;

    public virtual ICollection<Territory> Territories { get; } = new List<Territory>();
}
