using Microsoft.AspNetCore.Http;
using Nafaqa.Application.Models;
using Nafaqa.Application.Models.Person;
using Nafaqa.Application.Models.Petition;
using Nafaqa.Core.Entities;

namespace Nafaqa.Application.Services;

public interface IPersonService
{
    Task<CreatePersonResponseModel> CreatePersonAsync(CreatePersonModel createPersonModel);
    Task<PersonResponseModel> GetPersonAsync(int personId);
    IEnumerable<PersonResponseModel> GetAllPersons();
    Task<BaseResponseModel<int>> UpdatePersonAsync(int id, UpdatePersonModel updatePersonModel);
    Task<BaseResponseModel<int>> DeletePersonAsync(int id);

    Task<IEnumerable<Person>> GetPersonWith();
    Task<string?> AddPhotoToPersonAsync(int personId, IFormFile file);

    Task<IEnumerable<string>> GetPersonPhotosAsync(int personId);
    Task<bool> RemovePhotoAsync(int personId, int photoId);
}