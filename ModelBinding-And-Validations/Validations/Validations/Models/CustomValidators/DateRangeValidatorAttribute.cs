using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Validations.Models.CustomValidators;

public class DateRangeValidatorAttribute : ValidationAttribute
{
  public string OtherPropertyName { get; set; }
  public DateRangeValidatorAttribute(string otherPropertyName)
  {
    OtherPropertyName = otherPropertyName;
  }
  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    if (value != null)
    {
      // get to date
      DateTime to_date = Convert.ToDateTime(value);

      // get from date
      PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

      if (otherProperty != null)
      {
        DateTime from_date = Convert.ToDateTime(otherProperty?.GetValue(validationContext.ObjectInstance));

        if (from_date > to_date)
        {
          return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName, validationContext.MemberName });
        }
      }
    }

    return null;
  }
}