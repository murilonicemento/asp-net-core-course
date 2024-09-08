using System.ComponentModel.DataAnnotations;

namespace ordersApp.Models;

public class Product
{
  [Required]
  [Range(0, 99999)]
  public int ProductCode { get; set; }
  [Required]
  [Range(0, 99999)]
  public double Price { get; set; }
  [Required]
  [Range(0, 99999)]
  public int Quantity { get; set; }

}