using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class OrdersQryController : Controller
{
    private readonly ILogger<OrdersQryController> _logger;

    private readonly SchemaContext _context;

    public OrdersQryController(ILogger<OrdersQryController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.OrdersQries.ToList());
    }
    
}

public partial class OrdersQry
{
    public int OrderId { get; set; }

    public string? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public int? ShipVia { get; set; }

    public decimal? Freight { get; set; }

    public string? ShipName { get; set; }

    public string? ShipAddress { get; set; }

    public string? ShipCity { get; set; }

    public string? ShipRegion { get; set; }

    public string? ShipPostalCode { get; set; }

    public string? ShipCountry { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }
}
