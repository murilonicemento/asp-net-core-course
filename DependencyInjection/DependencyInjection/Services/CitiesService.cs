using ServiceContracts;

namespace Services;

public class CitiesService : ICitiesService, IDisposable
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
        
        // some logic to open a database connection
    }

    public List<string> GetCities() => _cities;
    public void Dispose()
    {
        // some logic to close a database connection
    }
}