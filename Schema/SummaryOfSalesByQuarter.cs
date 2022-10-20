using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class SummaryOfSalesByQuarterController : Controller
{
    private readonly ILogger<SummaryOfSalesByQuarterController> _logger;

    private readonly SchemaContext _context;

    public SummaryOfSalesByQuarterController(ILogger<SummaryOfSalesByQuarterController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.SummaryOfSalesByQuarters.ToList());
    }
    
}

public partial class SummaryOfSalesByQuarter
{
    public DateTime? ShippedDate { get; set; }

    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
