using Microsoft.AspNetCore.Http;

namespace Nafaqa.Application.Services;

public interface IPhotoService
{
    Task<string?> AddPhotoToPersonAsync(int personId, IFormFile file);

    FileStream GetPersonPhotos(int personId);
    Task<bool> RemovePhotoAsync(int personId);
}