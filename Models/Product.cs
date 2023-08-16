#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _9_E_Commerce.Models;
public class Product
{
    [Key]
    public int ProductId {get;set;}

    [Required]
    public string Name {get;set;}

    [Required]
    public string ImageUrl {get;set;}

    [Required]
    [Range(1, Int32.MaxValue, ErrorMessage = "Please put a valid Quantity greater than 1")]
    public int Quantity {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<Order> ProductOrder {get;set;} = new List<Order>();
}