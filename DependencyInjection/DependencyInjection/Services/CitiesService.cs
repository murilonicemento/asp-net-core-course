using ServiceContracts;

namespace Services;

public class CitiesService : ICitiesService
{
    private List<string> _cities;

    public CitiesService()
    {
        _cities = new List<string>()
        {
            "London",
            "Paris",
            "Tokyo",
            "Okinawa",
            "Rome"
        };
    }

    public List<string> GetCities() => _cities;
}