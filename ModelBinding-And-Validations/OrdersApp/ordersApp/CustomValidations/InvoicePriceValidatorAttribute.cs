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

        double invoicePrice = Convert.ToDouble(value);

        PropertyInfo? propertyInfo = validationContext.ObjectType.GetProperty(Products);

        if (propertyInfo != null)
        {
            if (propertyInfo.GetValue(validationContext.ObjectInstance) is IEnumerable<Product> listProduct)
            {
                double cost = listProduct.Sum(product => product.Price * product.Quantity);

                if (cost != invoicePrice)
                {
                    return new ValidationResult("InvoicePrice não deve ser diferente da soma dos produtos.");
                }
            }
        }

        return null;
    }
}

