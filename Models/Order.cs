#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _9_E_Commerce.Models;
public class Order
{
    [Key]
    public int OrderId {get;set;}

    [Required]
    [Display(Name = "Customer")]
    public int CustomerId {get;set;}
    public Customer? Customer {get;set;}

    [Required]
    [Display(Name = "Product")]
    public int ProductId {get;set;}
    public Product? Product {get;set;}

    [Required]
    public int Quantity {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}