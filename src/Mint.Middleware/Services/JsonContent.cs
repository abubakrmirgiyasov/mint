using Newtonsoft.Json;

namespace Mint.Middleware.Services;

public class JsonContent<T>
{
    public string GetContent(T entity)
    {
        return JsonConvert.SerializeObject(
            entity, 
            Formatting.None, 
            new JsonSerializerSettings() 
            { 
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore 
            });
    }
}
