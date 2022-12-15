using Mint.Domain.Exceptions;
using Mint.Domain.Extensions;
using Mint.Middleware.Extensions;
using System.Net.Http.Headers;
using System.Text;

namespace Mint.Middleware.Services;

public class RequestService<T>
{
    private HttpClient _client = null!;
    private bool _auth;

    public HttpClient Client { get => _client; set => _client = value; }

    public RequestService(bool auth)
    {
        _auth = auth;
        SetHttpClient();
    }

    private void SetHttpClient()
    {
        Client = new HttpClient { BaseAddress = new Uri(BaseUrl.BASE) };
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        if (_auth)
        {
            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(Constants.TOKEN_SCHEME, Params.AccessToken); ///////
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
            Validation(ex);
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<T> PostRequestAsync(string content, string route)
    {
        try
        {
            var response = await _client.PostAsync(route, new StringContent(content, Encoding.UTF8, "application/json"));
            var apiResponse = await response.Content.ReadAsStringAsync();
            return new JsonResponse<T>().GetResponse(response, apiResponse);
        }
        catch (SimilarUserException ex)
        {
            throw new SimilarUserException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<T> UpdateRequestAsync(string content, string route)
    {
        var response = await _client.PutAsync(route, new StringContent(content, Encoding.UTF8, "application/json"));
        var apiResponse = await response.Content.ReadAsStringAsync();
        return new JsonResponse<T>().GetResponse(response, apiResponse);
    }

    private void Validation(Exception ex)
    {

    }
}
