using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class CustomerAndSuppliersByCityController : Controller
{
    private readonly ILogger<CustomerAndSuppliersByCityController> _logger;

    private readonly SchemaContext _context;

    public CustomerAndSuppliersByCityController(ILogger<CustomerAndSuppliersByCityController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.CustomerAndSuppliersByCities.ToList());
    }
    
}

public partial class CustomerAndSuppliersByCity
{
    public string? City { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string Relationship { get; set; } = null!;
}
