using Microsoft.AspNetCore.Components.Forms;

namespace Nafaqa.Web.Services;

public class PhotoService
{
    private readonly HttpClient _httpClient;

    public PhotoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    
}