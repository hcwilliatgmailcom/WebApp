using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class QuarterlyOrderController : Controller
{
    private readonly ILogger<QuarterlyOrderController> _logger;

    private readonly SchemaContext _context;

    public QuarterlyOrderController(ILogger<QuarterlyOrderController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.QuarterlyOrders.ToList());
    }
    
}

public partial class QuarterlyOrder
{
    public string? CustomerId { get; set; }

    public string? CompanyName { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }
}
