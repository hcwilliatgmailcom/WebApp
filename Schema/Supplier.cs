using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class SupplierController : Controller
{
    private readonly ILogger<SupplierController> _logger;

    private readonly SchemaContext _context;

    public SupplierController(ILogger<SupplierController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.Suppliers.ToList());
    }
    
}

public partial class Supplier
{
    public int SupplierId { get; set; }

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

    public string? HomePage { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
