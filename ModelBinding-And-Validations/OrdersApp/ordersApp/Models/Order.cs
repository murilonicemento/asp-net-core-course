using System.ComponentModel.DataAnnotations;
using ordersApp.CustomValidations;

namespace ordersApp.Models;

public class Order
{
  [Required(ErrorMessage = "{0} can't be blank")]
  public int? OrderNo { get; set; }
  [Required(ErrorMessage = "{0} can't be blank")]
  public DateTime OrderDate { get; set; }
  [Required(ErrorMessage = "{0} can't be blank")]
  [InvoicePriceValidator("Products")]
  public double InvoicePrice { get; set; }
  [Required(ErrorMessage = "{0} can't be blank")]
  [MinimalProductValidator]
  public List<Product>? Products { get; set; }
}