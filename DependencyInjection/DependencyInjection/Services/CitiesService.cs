using ServiceContracts;

namespace Services;

public class CitiesService : ICitiesService
{
    private List<string> _cities;
    private Guid _serviceInstanceId;
    public Guid ServiceInstanceId
    {
        get
        {
            return _serviceInstanceId;
        }
    }

    public CitiesService()
    {
        _serviceInstanceId = Guid.NewGuid();
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