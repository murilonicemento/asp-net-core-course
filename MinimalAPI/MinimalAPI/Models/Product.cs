namespace MinimalAPI.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Product Id: {Id}, Product Name: {Name}";
    }
}