using System.Net.Http.Json;
using Nafaqa.Web.Models;

namespace Nafaqa.Web.Services;

public class PetitionService
{
    private readonly HttpClient _httpClient;

    public PetitionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> CreatePetitionAsync(Petition petition)
    {
        var response = await _httpClient.PostAsJsonAsync("Petitions", petition);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<int>();
    }

    public async Task<IEnumerable<Petition>> GetPetitionsAsync()
    {
        var response = await _httpClient.GetAsync("Petitions");
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<IEnumerable<Petition>>();
    }
}