#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _9_E_Commerce.Models;

[NotMapped]
public class MyViewModel
{
    public List<Order> allOrders {get;set;} = new List<Order>();

    public List<Customer> allCustomers {get;set;} = new List<Customer>();

    public List<Product> allProducts {get;set;} = new List<Product>();
}