using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ordersApp.Models;

namespace ordersApp.CustomValidations;

public class InvoicePriceValidatorAttribute(string products) : ValidationAttribute
{
    private new string Products { get; set; } = products;
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return null;

        double invoicePrice = (double)value;
        PropertyInfo? property = validationContext.ObjectType.GetProperty(Products);

        if (property != null)
        {
            if (property.GetValue(validationContext.ObjectInstance) is IEnumerable<Product> list)
            {
                double cost = list.Sum(product => product.Price * product.Quantity);

                if (cost != invoicePrice)
                {
                    return new ValidationResult("InvoicePrice deve ser igual a soma total dos produtos");
                }
            }
        }

        return null;
    }
}