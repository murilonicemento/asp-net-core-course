namespace ViewComponents.Models;

public class PersonGridModel
{
    public string GridTitle { get; set; } = string.Empty;
    public List<Person> Persons = new List<Person>();
}   