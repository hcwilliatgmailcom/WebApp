using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class ShipperController : Controller
{
    private readonly ILogger<ShipperController> _logger;

    private readonly SchemaContext _context;

    public ShipperController(ILogger<ShipperController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.Shippers.ToList());
    }
    
}

public partial class Shipper
{
    public int ShipperId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
