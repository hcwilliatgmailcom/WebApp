using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class CustomerController : Controller
{
    private readonly ILogger<CustomerController> _logger;

    private readonly SchemaContext _context;

    public CustomerController(ILogger<CustomerController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.Customers.ToList());
    }
    
}

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? ContactTitle { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<CustomerDemographic> CustomerTypes { get; } = new List<CustomerDemographic>();
}
