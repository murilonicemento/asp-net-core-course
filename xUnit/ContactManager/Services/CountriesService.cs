using ServiceContracts;
using ServiceContracts.DTO;
using Entities;

namespace Services;

public class CountriesService : ICountriesService
{
    private readonly List<Country> _countries;

    public CountriesService()
    {
        _countries = new List<Country>();
    }

    public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
    {
        if (countryAddRequest == null)
        {
            throw new ArgumentNullException(nameof(countryAddRequest));
        }

        if (countryAddRequest.Name == null)
        {
            throw new ArgumentException(nameof(countryAddRequest.Name));
        }

        if (_countries.Where(country => country.Name == countryAddRequest.Name).Count() > 0)
        {
            throw new ArgumentException("Given country name already exists.");
        }

        Country country = countryAddRequest.ToCountry();

        country.Id = Guid.NewGuid();

        _countries.Add(country);

        return country.ToCountryResponse();
    }
}