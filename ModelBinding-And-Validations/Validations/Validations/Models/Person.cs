using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Validations.Models.CustomValidators;

namespace Validations.Models;

public class Person
{
  [Required(ErrorMessage = "{0} can not be empty or null.")]
  [Display(Name = "Person Name")]
  [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long.")]
  [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should be contain only alphabets, space and dot (.).")]
  public string? PersonName { get; set; }

  [EmailAddress(ErrorMessage = "{0} should be a proper email address.")]
  [Required(ErrorMessage = "{0} can not be blank.")]
  public string? Email { get; set; }

  [Phone(ErrorMessage = "{0} should contain 10 digits.")]
  // [ValidateNever]
  public string? Phone { get; set; }

  [Required(ErrorMessage = "{0} can not be blank.")]
  public string? Password { get; set; }

  [Required(ErrorMessage = "{0} can not be blank.")]
  [Compare("Password", ErrorMessage = "{0} and {1} do not match.")]
  [Display(Name = "Re-enter Password")]
  public string? ConfirmPassword { get; set; }

  [Range(0, 999.9, ErrorMessage = "{0} should be between {1} and {2}")]
  public double? Price { get; set; }

  [MinimalYearValidator(2000, ErrorMessage = "Date of birth should not be newer than Jan 01, {0}")]
  public DateTime? DateOfBirth { get; set; }

  public DateTime? FromDate { get; set; }
  [DateRangeValidator("FromDate", ErrorMessage = "'From Date' should be older than or equal to 'To Date'")]
  public DateTime? ToDate { get; set; }

  public override string ToString()
  {
    return $"Person object - Person name: {PersonName}, Person email: {Email}, Person phone: {Phone}, Person password: {Password}, Person confirm password: {ConfirmPassword}, Person price: {Price}";
  }
}
