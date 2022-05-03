namespace ApiKeyExample;


interface IApiKeyRepository
{
    ApiKey? GetKey(string? key);
}

public class ApiKeyRepository : IApiKeyRepository
{
    private readonly IDictionary<string, ApiKey> _keys = new Dictionary<string, ApiKey>
    {
        {"123", new ApiKey(Guid.NewGuid(), "123", "Api 1") },
        {"456", new ApiKey(Guid.NewGuid(), "456", "Api 2") },
        {"789", new ApiKey(Guid.NewGuid(), "789", "Api 3") },
    };

    public ApiKey? GetKey(string? key)
    {
        if (key == null)
        {
            return null;
        }

        _keys.TryGetValue(key, out var foundKey);
        return foundKey;
    }
}

public record ApiKey(Guid Id, string Key, string ClientName);