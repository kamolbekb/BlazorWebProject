using System.Net.Http.Json;
using Common;

namespace Nafaqa.Web.Services;

public class PetitionService
{
    private readonly HttpClient _httpClient;

    public PetitionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> CreatePetitionAsync(PetitionDto petition)
    {
        var response = await _httpClient.PostAsJsonAsync("Petitions", petition);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<int>();
    }

    public async Task<IEnumerable<PetitionDto>?> GetPetitionsAsync()
    {
        var response = await _httpClient.GetAsync("Petitions");
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<IEnumerable<PetitionDto>>();
    }
}