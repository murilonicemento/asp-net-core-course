namespace StocksApp.Services;

public class MyService(IHttpClientFactory httpClientFactory)
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    public async Task method()
    {
        using (HttpClient httpClient = _httpClientFactory.CreateClient())
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri(""),
                Method = HttpMethod.Get
            };

            HttpResponseMessage responseMessage = await httpClient.SendAsync(httpRequestMessage);
        }
    }
}