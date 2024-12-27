using Microsoft.AspNetCore.Mvc;
using Nafaqa.Application.Models.Person;
using Nafaqa.Application.Services;

namespace Nafaqa.API.Controllers;

public class PersonsController : ApiController
{
    private readonly IPersonService _personService;

    public PersonsController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpPost(Name = "CreatePerson")]
    public async Task<IActionResult> CreatePerson(CreatePersonModel model)
    {
        return Ok(await _personService.CreatePersonAsync(model));
    }
    
    [HttpGet]
    [Route ("GetPersonById")]
    public async Task<IActionResult> RetrievePerson(int id)
    {
        return Ok(await _personService.GetPersonAsync(id));
    }

    [HttpGet(Name = "RetrieveAllPeople")]
    public IActionResult RetrieveAllPeople()
    {
        return Ok( _personService.GetAllPersons());
    }

    [HttpPut(Name = "UpdatePerson")]
    public async Task<IActionResult> UpdatePerson(int id, UpdatePersonModel model)
    {
        return Ok(await _personService.UpdatePersonAsync(id, model));
    }

    [HttpDelete(Name = "DeletePerson")]
    public async Task<IActionResult> DeletePerson(int id)
    {
        return Ok(await _personService.DeletePersonAsync(id));
    }
}