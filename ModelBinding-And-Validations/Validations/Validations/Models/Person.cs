using System.ComponentModel.DataAnnotations;

namespace Validations.Models;

public class Person
{
  [Required(ErrorMessage = "{0} can not be empty or null.")]
  [Display(Name = "Person Name")]
  [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long.")]
  public string? PersonName { get; set; }
  public string? Email { get; set; }
  public string? Phone { get; set; }
  public string? Password { get; set; }
  public string? ConfirmPassword { get; set; }
  [Range(0, 999.9, ErrorMessage = "{0} should be between {1} and {2}")]
  public double? Price { get; set; }

  public override string ToString()
  {
    return $"Person object - Person name: {PersonName}, Person email: {Email}, Person phone: {Phone}, Person password: {Password}, Person confirm password: {ConfirmPassword}, Person price: {Price}";
  }
}
