using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _9_E_Commerce.Models;

namespace _9_E_Commerce.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    public MyContext db;

    public ProductController(ILogger<ProductController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

    [HttpGet("products")]
    public IActionResult Index()
    {
        List<Product> allProducts = db.Products.ToList();
        return View(allProducts);
    }

    [HttpGet("products/{productId}")]
    public IActionResult ViewOne(int productId)
    {
        return View();
    }

    [HttpPost("products/create")]
    public IActionResult Create(Product newProd)
    {
        if (!ModelState.IsValid)
        {
            List<Product> allProducts = db.Products.ToList();
            return View("Index", allProducts);
        }
        db.Add(newProd);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("products/{productId}/edit")]
    public IActionResult Edit(int productId)
    {
        return View();
    }

    [HttpPost("products/{productId}/update")]
    public IActionResult Update(int productId)
    {
        return View();
    }

    [HttpPost("products/{productId}/delete")]
    public IActionResult Delete(int productId)
    {
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
