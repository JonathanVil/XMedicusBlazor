using Newtonsoft.Json;

namespace BlazorApp.Data;

public class RegentService
{
    private readonly HttpClient _httpClient;

    public RegentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<RegentEntry>?> GetRegentsAsync()
    {
        // get from https://gist.githubusercontent.com/adbir/e8b768cc854f0499034cd40fcf34a720/raw
        return await _httpClient.GetFromJsonAsync<List<RegentEntry>>("https://gist.githubusercontent.com/adbir/e8b768cc854f0499034cd40fcf34a720/raw");
    }
}