using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class OrderSubtotalController : Controller
{
    private readonly ILogger<OrderSubtotalController> _logger;

    private readonly SchemaContext _context;

    public OrderSubtotalController(ILogger<OrderSubtotalController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.OrderSubtotals.ToList());
    }
    
}

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
