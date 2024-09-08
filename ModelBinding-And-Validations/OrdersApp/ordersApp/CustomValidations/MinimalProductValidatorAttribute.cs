using System.ComponentModel.DataAnnotations;
using ordersApp.Models;

namespace  ordersApp.CustomValidations;

public class MinimalProductValidatorAttribute : ValidationAttribute
{
   protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
   {
      if (value is not IEnumerable<Product> list) return null;

      return !list.Any() ? new ValidationResult("Deve ter no mínimo um produto") : null;
   }
}

