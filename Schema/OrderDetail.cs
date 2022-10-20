using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class OrderDetailController : Controller
{
    private readonly ILogger<OrderDetailController> _logger;

    private readonly SchemaContext _context;

    public OrderDetailController(ILogger<OrderDetailController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.OrderDetails.ToList());
    }
    
}

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal UnitPrice { get; set; }

    public short Quantity { get; set; }

    public float Discount { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
