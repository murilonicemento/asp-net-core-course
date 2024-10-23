using System.ComponentModel.DataAnnotations;
using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;

namespace Services;

public class PersonsService : IPersonsService
{
    private readonly List<Person> _persons;
    private readonly ICountriesService _countriesService;

    public PersonsService()
    {
        _persons = new List<Person>();
        _countriesService = new CountriesService();
    }

    private PersonResponse ConvertToPersonResponse(Person person)
    {
        PersonResponse personResponse = person.ToPersonResponse();
        personResponse.Country = _countriesService.GetCountryByCountryId(person.CountryId)?.Name;

        return personResponse;
    }

    public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
    {
        ArgumentNullException.ThrowIfNull(personAddRequest);
        ValidationHelper.ModelValidation(personAddRequest);

        Person person = personAddRequest.ToPerson();
        person.Id = Guid.NewGuid();

        _persons.Add(person);

        return ConvertToPersonResponse(person);
    }

    public List<PersonResponse> GetAllPersons()
    {
        return _persons.Select(person => person.ToPersonResponse()).ToList();
    }

    public PersonResponse? GetPersonByPersonId(Guid? id)
    {
        return _persons.FirstOrDefault(person => person.Id == id)?.ToPersonResponse();
    }

    public List<PersonResponse> GetFilteredPerson(string searchBy, string? searchString)
    {
        List<PersonResponse> allPersons = GetAllPersons();
        List<PersonResponse> matchingPersons = allPersons;

        if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchString)) return matchingPersons;

        switch (searchBy)
        {
            case nameof(Person.Name):
                matchingPersons = allPersons.Where(person =>
                    (!string.IsNullOrEmpty(person.Name))
                        ? person.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                        : true).ToList();
                break;
            case nameof(Person.Email):
                matchingPersons = allPersons.Where(person =>
                    (!string.IsNullOrEmpty(person.Email))
                        ? person.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                        : true).ToList();
                break;
            case nameof(Person.DateOfBirth):
                matchingPersons = allPersons.Where(person =>
                    (person.DateOfBirth != null)
                        ? person.DateOfBirth.Value.ToString("dd MMMM yyyy")
                            .Contains(searchString, StringComparison.OrdinalIgnoreCase)
                        : true).ToList();
                break;
            case nameof(Person.Gender):
                matchingPersons = allPersons.Where(person =>
                    (!string.IsNullOrEmpty(person.Gender))
                        ? person.Gender.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                        : true).ToList();
                break;
            case nameof(Person.CountryId):
                matchingPersons = allPersons.Where(person =>
                    (!string.IsNullOrEmpty(person.Country))
                        ? person.Country.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                        : true).ToList();
                break;
            case nameof(Person.Address):
                matchingPersons = allPersons.Where(person =>
                    (!string.IsNullOrEmpty(person.Address))
                        ? person.Address.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                        : true).ToList();
                break;
            default:
                matchingPersons = allPersons;
                break;
        }

        return matchingPersons;
    }
}