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

    public async Task<Petition> CreatePetitionAsync(Petition petition)
    {
        var response = await _httpClient.PostAsJsonAsync("Petitions", petition);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<Petition>();
    }
}