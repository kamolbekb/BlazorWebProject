using Microsoft.AspNetCore.Mvc;
using Nafaqa.Application.Models.Petition;
using Nafaqa.Application.Services;

namespace Nafaqa.API.Controllers;

public class PetitionsController : ApiController
{
    private readonly IPetitionService _petitionService;

    public PetitionsController (IPetitionService petitionService)
    {
        _petitionService = petitionService;
    }
    
    [HttpPost(Name="CreatePetition")]
    public async Task<IActionResult> CreatePetition(CreatePetitionModel model)
    {
        return Ok(await _petitionService.CreatePetitionAsync(model));
    }
}