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
    
    [HttpPost]
    [Route("api/petitions")]
    public async Task<IActionResult> CreatePetition(CreatePetitionModel model)
    {
        return Ok(await _petitionService.CreatePetitionAsync(model));
    }
    
    [HttpGet]
    [Route ("api/petitions")]
    public async Task<IActionResult> RetrievePetition(int id)
    {
        return Ok(await _petitionService.GetPetitionAsync(id));
    }

    [HttpGet(Name = "RetrieveAllPetitions")]
    public IActionResult RetrieveAllPeople()
    {
        return Ok( _petitionService.GetAllPetitions());
    }

    [HttpPut(Name = "UpdatePetition")]
    public async Task<IActionResult> UpdatePetition(int id, UpdatePetitionModel model)
    {
        return Ok(await _petitionService.UpdatePetitionAsync(id, model));
    }

    [HttpDelete(Name = "api/petitions/{id}")]
    public async Task<IActionResult> DeletePetition(int id)
    {
        return Ok(await _petitionService.DeletePetitionAsync(id));
    }
}