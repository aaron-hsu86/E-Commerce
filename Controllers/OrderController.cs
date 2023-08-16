using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _9_E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace _9_E_Commerce.Controllers;

public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;
    public MyContext db;

    public OrderController(ILogger<OrderController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

    [HttpGet("orders")]
    public IActionResult Index()
    {
        MyViewModel allItems = new(){
            allOrders = db.Orders.Include(o => o.Customer).Include(o => o.Product).OrderBy(o => o.CreatedAt).ToList(),
            allCustomers = db.Customers.ToList(),
            allProducts = db.Products.ToList(),
            
        };
        return View(allItems);
    }

    [HttpPost("orders/create")]
    public IActionResult Create(Order newOrder)
    {
        if (!ModelState.IsValid)
        {
            MyViewModel allItems = new(){
                allOrders = db.Orders.Include(o => o.Customer).Include(o => o.Product).OrderBy(o => o.CreatedAt).ToList(),
                allCustomers = db.Customers.ToList(),
                allProducts = db.Products.ToList(),
                
            };
            return View("Index", allItems);
        }
        Product prodInDB = db.Products.FirstOrDefault(p => p.ProductId == newOrder.ProductId);
        if (prodInDB.Quantity < newOrder.Quantity)
        {
            ModelState.AddModelError("allOrders", "Not enough Product quantity");
            MyViewModel allItems = new(){
                allOrders = db.Orders.Include(o => o.Customer).Include(o => o.Product).OrderBy(o => o.CreatedAt).ToList(),
                allCustomers = db.Customers.ToList(),
                allProducts = db.Products.ToList(),
                
            };
            return View("Index", allItems);
        }
        prodInDB.Quantity -= newOrder.Quantity;
        db.Update(prodInDB);
        db.Add(newOrder);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost("orders/{orderId}/delete")]
    public IActionResult Delete()
    {
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
