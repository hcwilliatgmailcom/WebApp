using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class SummaryOfSalesByYearController : Controller
{
    private readonly ILogger<SummaryOfSalesByYearController> _logger;

    private readonly SchemaContext _context;

    public SummaryOfSalesByYearController(ILogger<SummaryOfSalesByYearController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.SummaryOfSalesByYears.ToList());
    }
    
}

public partial class SummaryOfSalesByYear
{
    public DateTime? ShippedDate { get; set; }

    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
