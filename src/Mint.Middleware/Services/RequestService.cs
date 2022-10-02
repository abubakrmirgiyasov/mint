using Mint.Domain.Extensions;
using System.Net.Http.Headers;

namespace Mint.Middleware.Services;

public class RequestService<T>
{
    private HttpClient _client;
    private bool _auth;

    public HttpClient Client { get => _client; set => _client = value; }

    public RequestService(bool auth)
    {
        _auth = auth;
        SetHttpClient();
    }

    private void SetHttpClient()
    {
        Client = new HttpClient { BaseAddress = new Uri("https://localhost:7190") };
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        if (_auth)
        {
            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(Constants.TOKEN_SCHEME);
        }
    }

    public async Task<T> GetRequestAsync(string route)
    {
        try
        {
            var response = await _client.GetAsync(route);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return new JsonResponse<T>().GetResponse(response, apiResponse);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
