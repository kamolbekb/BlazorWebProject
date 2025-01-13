using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Nafaqa.Application.Models;
using Nafaqa.Application.Models.Person;
using Nafaqa.Core.Entities;
using Nafaqa.DataAccess.Repositories;

namespace Nafaqa.Application.Services.Implementation;

public class PersonService : IPersonService
{
    private readonly IMapper _mapper;
    private readonly IPersonRepository _personRepository;
    private readonly string _imageFolderPath;

    public PersonService(IMapper mapper, IPersonRepository personRepository, string imageFolderPath)
    {
        _mapper = mapper;
        _personRepository = personRepository;
        _imageFolderPath = imageFolderPath;
    }

    public async Task<CreatePersonResponseModel> CreatePersonAsync(CreatePersonModel createPersonModel)
    {
        var person = _mapper.Map<Person>(createPersonModel);
        var addedPerson = await _personRepository.InsertAsync(person);
        return new CreatePersonResponseModel
        {
            Id = addedPerson.Id,
        };
    }

    public async Task<IEnumerable<Person>> GetPersonWith()
    {
        return await _personRepository.SelectAllWithIncludesAsync("Photos");
    }
    public async Task<PersonResponseModel> GetPersonAsync(int personId)
    {
        var entity = await _personRepository.SelectByIdAsync(personId);

        if (entity == null)
        {
            return new PersonResponseModel()
            {
                Id = personId,
                Errors = new List<string> { "There is no such person in the database." }
            };
        }

        return _mapper.Map<PersonResponseModel>(entity);
    }

    public IEnumerable<PersonResponseModel> GetAllPersons()
    {
        var entities = _personRepository
            .SelectAll()
            .OrderBy(x => x.Id);
    
        return _mapper.Map<IEnumerable<PersonResponseModel>>(entities);
    }
    
    // public async Task<IEnumerable<PersonResponseModel>> GetAllPersons(int pageNumber, int elementsPerPage)
    // {
    //     var skip = (pageNumber - 1) * elementsPerPage;
    //     var take = elementsPerPage;
    //
    //     var entities = await _personRepository.SelectAll()
    //         .OrderBy(x => x.Id)
    //         .Skip(skip)
    //         .Take(take)
    //         .ToListAsync();
    //
    //     if (entities == null || !entities.Any())
    //     {
    //         return Enumerable.Empty<PersonResponseModel>();
    //     }
    //
    //
    //     var responseModels = _mapper.Map<IEnumerable<PersonResponseModel>>(entities);
    //
    //     return responseModels.ToList();
    // }

    public async Task<BaseResponseModel<int>> UpdatePersonAsync(int id, UpdatePersonModel updatePersonModel)
    {
        var entity = _personRepository.SelectAll()
            .FirstOrDefault(i => i.Id == id);

        if (entity is null)
        {
            return new BaseResponseModel<int>
            {
                Id = -1,
                Errors = new List<string> { "You are trying to Update a Person that doesn't exist" }
            };
        }
        
        _mapper.Map(updatePersonModel, entity);
        
        await _personRepository.UpdateAsync(entity);
        await _personRepository.SaveChangesAsync();

        return new BaseResponseModel<int>
        {
            Id = id,
            Errors = null
        };
    }

    public async Task<BaseResponseModel<int>> DeletePersonAsync(int id)
    {
        var entity = await _personRepository.SelectByIdAsync(id);
        if (entity is null)
        {
            return new BaseResponseModel<int>
            {
                Id = -1,
                Errors = new List<string> { "You are trying to Delete a Person that doesn't exist" }
            };
        }

        await _personRepository.DeleteAsync(entity);
        await _personRepository.SaveChangesAsync();
        return new BaseResponseModel<int>
        {
            Id = id,
            Errors = null
        };
    }

//     public async Task<string?> AddPhotoToPersonAsync(int personId, IFormFile file)
// {
//     var person = await _personRepository.SelectByIdAsync(personId);
//     if (person == null)
//     {
//         return null; // Person not found
//     }
//
//     if (file == null || file.Length == 0)
//     {
//         throw new ArgumentException("Invalid file.");
//     }
//
//     // Generate unique file name and save photo
//     var fileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
//     var filePath = Path.Combine(_imageFolderPath, fileName);
//
//     using (var stream = new FileStream(filePath, FileMode.Create))
//     {
//         await file.CopyToAsync(stream);
//     }
//
//     var relativePath = $"/images/{fileName}";
//
//     // Add photo to person
//     person.Photo.Add(new Photo
//     {
//         FilePath = relativePath,
//         PersonId = personId
//     });
//
//     await _personRepository.UpdateAsync(person);
//     await _personRepository.SaveChangesAsync();
//
//     return relativePath;
// }
//
// public async Task<IEnumerable<string>> GetPersonPhotosAsync(int personId)
// {
//     var person = await _personRepository.SelectByIdAsync(personId);
//     if (person == null)
//     {
//         return Enumerable.Empty<string>();
//     }
//
//     return person.Photo.Select(photo => photo.FilePath);
// }
// public async Task<bool> UpdatePersonPhotoAsync(int personId, string newFilePath)
// {
//     var person = await _personRepository.SelectByIdAsync(personId, include => include.Photo);
//     if (person == null || person.Photo == null)
//     {
//         return false;
//     }
//
//     // Обновление фотографии
//     person.Photo.FilePath = newFilePath;
//     await _personRepository.UpdateAsync(person.Photo);
//     await _personRepository.SaveChangesAsync();
//
//     return true;
// }
//
// public async Task<bool> DeletePersonPhotoAsync(int personId, int photoId)
// {
//     // Retrieve the person by their ID
//     var person = await _personRepository.SelectByIdAsync(personId);
//     if (person == null)
//     {
//         return false;
//     }
//
//     // Retrieve the associated photo
//     var photo = person.Photo;
//     if (photo == null)
//     {
//         return false;
//     }
//
//     // Construct the full file path for the photo
//     var filePath = Path.Combine(_imageFolderPath, Path.GetFileName(photo.FilePath));
//
//     // Delete the photo file if it exists
//     if (File.Exists(filePath))
//     {
//         File.Delete(filePath);
//     }
//
//     // Remove the photo reference from the person's entity
//     person.Photo = null;
//
//     // Update the person entity in the repository
//     await _personRepository.UpdateAsync(person);
//     await _personRepository.SaveChangesAsync();
//
//     return true;
// }
    public async Task<string?> AddPhotoToPersonAsync(int personId, IFormFile file)
    {
        var person = await _personRepository.SelectByIdAsync(personId);
        if (person == null)
        {
            return null;
        }

        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("Invalid file.");
        }
        
        var fileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(_imageFolderPath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var relativePath = $"/images/{fileName}";

        person.Photos.Add(new Photo
        {
            FilePath = relativePath,
            PersonId = personId
        });

        await _personRepository.UpdateAsync(person);
        await _personRepository.SaveChangesAsync();

        return relativePath;
    }
    
    public async Task<IEnumerable<string>> GetPersonPhotosAsync(int personId)
    {
        var person = await _personRepository.SelectByIdAsync(personId);
        if (person == null)
        {
            return Enumerable.Empty<string>();
        }

        return person.Photos.Select(photo => photo.FilePath);
    }

    public async Task<bool> RemovePhotoAsync(int personId, int photoId)
    {
        var person = await _personRepository.SelectByIdAsync(personId);
        if (person == null)
        {
            return false; 
        }

        var photo = person.Photos.FirstOrDefault(p => p.Id == photoId);
        if (photo == null)
        {
            return false; 
        }

        var fullFilePath = Path.Combine(_imageFolderPath, Path.GetFileName(photo.FilePath));
        if (File.Exists(fullFilePath))
        {
            File.Delete(fullFilePath);
        }

        person.Photos.Remove(photo);

        await _personRepository.UpdateAsync(person);
        await _personRepository.SaveChangesAsync();

        return true;
    }
}