#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _9_E_Commerce.Models;
public class Customer
{
    [Key]
    public int CustomerId {get;set;}

    [Required(ErrorMessage = "Name is required!")]
    [MinLength(2, ErrorMessage = "Name requires at least 2 characters")]
    public string Name {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<Order> CustomerOrder {get;set;} = new List<Order>();
}