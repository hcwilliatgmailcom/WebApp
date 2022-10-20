using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class SalesTotalsByAmountController : Controller
{
    private readonly ILogger<SalesTotalsByAmountController> _logger;

    private readonly SchemaContext _context;

    public SalesTotalsByAmountController(ILogger<SalesTotalsByAmountController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.SalesTotalsByAmounts.ToList());
    }
    
}

public partial class SalesTotalsByAmount
{
    public decimal? SaleAmount { get; set; }

    public int OrderId { get; set; }

    public string CompanyName { get; set; } = null!;

    public DateTime? ShippedDate { get; set; }
}
