using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace Tests;

public class CountriesServiceTest
{
    private readonly ICountriesService _countriesService;

    public CountriesServiceTest()
    {
        _countriesService = new CountriesService();
    }

    // When CountryAddRequests is null, it should throw ArgumentNullException
    [Fact]
    public void AddCountry_NullCountry()
    {
        CountryAddRequest? request = null;

        Assert.Throws<ArgumentNullException>(() => { _countriesService.AddCountry(request); });
    }

    // When CountryName is null, it should throw ArgumentException
    [Fact]
    public void AddCountry_CountryNameIsNull()
    {
        CountryAddRequest? request = new CountryAddRequest() { Name = null };

        Assert.Throws<ArgumentException>(() => { _countriesService.AddCountry(request); });
    }

    // When the CountryName is duplicate, it should throw ArgumentException
    [Fact]
    public void AddCountry_CountryNameIsDuplicate()
    {
        CountryAddRequest? request1 = new CountryAddRequest() { Name = "Brazil" };
        CountryAddRequest? request2 = new CountryAddRequest() { Name = "Brazil" };

        Assert.Throws<ArgumentException>(() =>
        {
            _countriesService.AddCountry(request1);
            _countriesService.AddCountry(request2);
        });
    }

    // When you supply proper country name, it should insert (add) the country to existing list of countries
    [Fact]
    public void AddCountry_ProperCountryDetails()
    {
        CountryAddRequest? request = new CountryAddRequest() { Name = "Japan" };

        CountryResponse response = _countriesService.AddCountry(request);

        Assert.True(response.Id != Guid.Empty);
    }
}