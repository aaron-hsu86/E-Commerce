using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _9_E_Commerce.Models;

namespace _9_E_Commerce.Controllers;

public class CustomerController : Controller
{
    private readonly ILogger<CustomerController> _logger;
    public MyContext db;

    public CustomerController(ILogger<CustomerController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

    [HttpGet("customers")]
    public IActionResult Index()
    {
        List<Customer> allCustomers = db.Customers.OrderBy(c => c.CreatedAt).ToList();
        return View(allCustomers);
    }

    [HttpGet("customers/{customerId}")]
    public IActionResult ViewOne(int customerId)
    {
        return View();
    }

    [HttpPost("customers/create")]
    public IActionResult Create(Customer newCust)
    {
        if(!ModelState.IsValid)
        {
            List<Customer> allCustomers = db.Customers.OrderBy(c => c.CreatedAt).ToList();
            return View("Index", allCustomers);
        }

        db.Customers.Add(newCust);
        db.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet("customers/{customerId}/edit")]
    public IActionResult Edit(int customerId)
    {
        return View();
    }

    [HttpPost("customers/{customerId}/update")]
    public IActionResult Update(int customerId)
    {
        return View();
    }

    [HttpPost("customers/{customerId}/delete")]
    public IActionResult Delete(int customerId)
    {
        Customer? custInDB = db.Customers.SingleOrDefault(c => c.CustomerId == customerId);
        if (custInDB == null)
        {
            return RedirectToAction("Index");
        }
        db.Remove(custInDB);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
