using AutoMapper;
using Microsoft.AspNetCore.Http;
using Nafaqa.Core.Entities;
using Nafaqa.DataAccess.Repositories;

namespace Nafaqa.Application.Services.Implementation;

public class PhotoService : IPhotoService
{
    private readonly IMapper _mapper;
    private readonly IPhotoRepository _photoRepository;
    private readonly IPersonRepository _personRepository;
    private readonly string _imageFolderPath;

    public PhotoService(IMapper mapper, IPhotoRepository photoRepository, IPersonRepository personRepository,string imageFolderPath)
    {
        _mapper = mapper;
        _photoRepository = photoRepository;
        _personRepository = personRepository;
        _imageFolderPath = imageFolderPath;
    }
    
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
        var filePath = Path.Combine(_imageFolderPath+"/images", fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var relativePath = $"/images/{fileName}";

        await _photoRepository.InsertAsync(new Photo
        {
            FilePath = relativePath,
            PersonId = personId
        });
        
        await _photoRepository.SaveChangesAsync();

        return relativePath;
    }
    
    public FileStream GetPersonPhotos(int personId)
    {
        var photo =  _photoRepository.SelectAll().FirstOrDefault(p => p.PersonId == personId);

        if (photo == null)
        {
            return new FileStream(_imageFolderPath+"/images/d3zxxnoe.rol.jpeg", FileMode.Open);
        }
        
        return new FileStream(_imageFolderPath+photo.FilePath, FileMode.Open);
    }

    public async Task<bool> RemovePhotoAsync(int personId)
    {
        var person = await _personRepository.SelectByIdAsync(personId);
        if (person == null)
        {
            return false;
        }
        
        var photo = _photoRepository.SelectAll().FirstOrDefault(p => p.PersonId == personId);
        if (photo == null)
        {
            return false;
        }
        var filePath = Path.Combine(_imageFolderPath+"/images", Path.GetFileName(photo.FilePath));
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        await _photoRepository.DeleteAsync(photo);
        await _photoRepository.SaveChangesAsync();
        
        return true;
    }
}