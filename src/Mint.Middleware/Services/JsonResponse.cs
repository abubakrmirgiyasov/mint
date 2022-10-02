using Newtonsoft.Json;

namespace Mint.Middleware.Services;

public class JsonResponse<T>
{
    public T GetResponse(HttpResponseMessage response, string apiResponse)
    {
        return response.IsSuccessStatusCode ?
            JsonConvert.DeserializeObject<T>(apiResponse) :
            throw new Exception(JsonConvert.DeserializeObject<string>(apiResponse));
    }
}
