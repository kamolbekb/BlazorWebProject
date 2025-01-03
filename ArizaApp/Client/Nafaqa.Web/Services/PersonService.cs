using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Nafaqa.Web.Models;

namespace Nafaqa.Web.Services;

public class PersonService
{
    private readonly HttpClient _httpClient;

    public PersonService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    
}