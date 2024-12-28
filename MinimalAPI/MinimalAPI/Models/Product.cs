using System.ComponentModel.DataAnnotations;

namespace MinimalAPI.Models;

public class Product
{
    [Required(ErrorMessage = "Id can't be blank")]
    [Range(0, int.MaxValue, ErrorMessage = "Id should be between 0 to maximun integer value")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name can't be blank")]
    public string? Name { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Product Id: {Id}, Product Name: {Name}";
    }
}