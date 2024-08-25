using Microsoft.AspNetCore.Mvc;

namespace ModelBinding_And_Validations.Models;

public class Book
{
  // [FromQuery] => Define o tipo de parâmetro na própria classe
  public int? BookId { get; set; }
  public string? Author { get; set; }

  public override string ToString()
  {
    return $"Book object - Book id: {BookId}, Book author: {Author}";
  }
}