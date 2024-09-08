using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using ordersApp.CustomValidations;

namespace ordersApp.Models;

public class Order : IValidatableObject
{
  [Required(ErrorMessage = "{0} can't be blank")]
  public int? OrderNo { get; set; }
  [Required(ErrorMessage = "{0} can't be blank")]
  public DateTime OrderDate { get; set; }
  [Required(ErrorMessage = "{0} can't be blank")]
  [InvoicePriceValidator("Products")]
  [Range(0, 99999)]
  public double InvoicePrice { get; set; }
  [Required(ErrorMessage = "{0} can't be blank")]
  [MinimalProductValidator]
  public List<Product>? Products { get; set; }

  public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
  {
    if (OrderDate < DateTime.Now)
    {
      yield return new ValidationResult("OrderDate deve ser maior que a data atual", new[] {nameof(OrderDate)});
    }
  }
}