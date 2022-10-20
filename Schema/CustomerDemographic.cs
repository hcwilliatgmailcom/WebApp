using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Schema;

public class CustomerDemographicController : Controller
{
    private readonly ILogger<CustomerDemographicController> _logger;

    private readonly SchemaContext _context;

    public CustomerDemographicController(ILogger<CustomerDemographicController> logger,SchemaContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        return View(_context.CustomerDemographics.ToList());
    }
    
}

public partial class CustomerDemographic
{
    public string CustomerTypeId { get; set; } = null!;

    public string? CustomerDesc { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}
