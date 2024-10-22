using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services;

namespace Tests;

public class PersonServiceTest
{
    private readonly IPersonsService _personsService;
    private readonly ICountriesService _countriesService;

    public PersonServiceTest()
    {
        _personsService = new PersonsService();
        _countriesService = new CountriesService();
    }

    #region AddPerson

    // When we supply null value as PersonAddRequest, it should throw ArgumentNullException
    [Fact]
    public void AddPerson_NullPerson()
    {
        PersonAddRequest? personAddRequest = null;

        Assert.Throws<ArgumentNullException>(() => { _personsService.AddPerson(personAddRequest); });
    }

    // When we supply null value as person name, it should throw ArgumentException
    [Fact]
    public void AddPerson_PersonNameIsNull()
    {
        PersonAddRequest personAddRequest = new PersonAddRequest() { Name = null };

        Assert.Throws<ArgumentException>(() => { _personsService.AddPerson(personAddRequest); });
    }

    // When we supply proper person details, it should insert the person into the person list; and it should return object of PersonResponse, which includes with the newly generated person id
    [Fact]
    public void AddPerson_ProperPersonDetails()
    {
        PersonAddRequest personAddRequest = new PersonAddRequest()
        {
            Name = "Yeti",
            Email = "yeti@gmail.com",
            Address = "Xique Xique - BA",
            Gender = GenderOptions.Male,
            CountryId = Guid.NewGuid(),
            DateOfBirth = DateTime.Parse("2002-05-28"),
            ReceiveNewsLetters = true
        };

        PersonResponse personResponse = _personsService.AddPerson(personAddRequest: personAddRequest);
        List<PersonResponse> listOfPerson = _personsService.GetAllPersons();

        Assert.True(personResponse.Id != Guid.Empty);
        Assert.Contains(personResponse, listOfPerson);
    }

    #endregion

    #region GetPersonByPersonId

    // If we supply null as person id, it should return as response
    [Fact]
    public void GetPersonByPersonId_NullId()
    {
        PersonResponse? personResponse = _personsService.GetPersonByPersonId(null);

        Assert.Null(personResponse);
    }

    // If we supply a valid person id, it should return the valid person details as response
    [Fact]
    public void GetPersonByPersonId_ProperPersonDetails()
    {
        CountryAddRequest countryAddRequest = new CountryAddRequest()
        {
            Name = "Japan"
        };
        CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

        PersonAddRequest personAddRequest = new PersonAddRequest()
        {
            Name = "Yeti",
            Email = "yeti@gmail.com",
            Address = countryResponse.Name,
            Gender = GenderOptions.Male,
            CountryId = countryResponse.Id,
            DateOfBirth = DateTime.Parse("2002-05-28"),
            ReceiveNewsLetters = true
        };

        PersonResponse personResponseAddPerson = _personsService.AddPerson(personAddRequest: personAddRequest);

        PersonResponse? personResponseGetPersonId = _personsService.GetPersonByPersonId(personResponseAddPerson.Id);

        Assert.Equal(personResponseAddPerson, personResponseGetPersonId);
    }

    #endregion
}