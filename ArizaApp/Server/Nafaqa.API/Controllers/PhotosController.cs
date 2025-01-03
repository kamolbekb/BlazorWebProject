using Microsoft.AspNetCore.Mvc;
using Nafaqa.Application.Services;

namespace Nafaqa.API.Controllers;

public class PhotosController : ApiController
{
    private readonly IPhotoService _photoService;

    public PhotosController( IPhotoService photoService )
    {
        _photoService = photoService;
    }
    
    [HttpPost]
    [Route("AddPhotoToPerson{personId}")]
    public async Task<IActionResult> AddPhoto(int personId, IFormFile file)
    {
        return Ok(await _photoService.AddPhotoToPersonAsync(personId, file));
    }

    [HttpGet]
    [Route("GetPersonPhoto")]
    public async Task<IActionResult> GetPersonPhoto(int personId)
    {
        return Ok( _photoService.GetPersonPhotos(personId));
    }

    [HttpDelete]
    [Route("DeletePhotoFromPersonAsync")]
    public async Task<IActionResult> DeletePhotoFromPerson(int personId)
    {
        return Ok(await _photoService.RemovePhotoAsync(personId));
    }
}