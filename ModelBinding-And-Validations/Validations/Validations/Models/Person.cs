using System.ComponentModel.DataAnnotations;

namespace Validations.Models;

public class Person
{
  [Required(ErrorMessage = "Person Name can not be empty or null.")]
  public string? PersonName { get; set; }
  public string? Email { get; set; }
  public string? Phone { get; set; }
  public string? Password { get; set; }
  public string? ConfirmPassword { get; set; }
  public double? Price { get; set; }

  public override string ToString()
  {
    return $"Person object - Person name: {PersonName}, Person email: {Email}, Person phone: {Phone}, Person password: {Password}, Person confirm password: {ConfirmPassword}, Person price: {Price}";
  }
}
