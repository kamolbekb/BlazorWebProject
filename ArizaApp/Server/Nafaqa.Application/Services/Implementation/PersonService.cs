using AutoMapper;
using Nafaqa.Application.Models;
using Nafaqa.Application.Models.Person;
using Nafaqa.Core.Entities;
using Nafaqa.DataAccess.Repositories;

namespace Nafaqa.Application.Services.Implementation;

public class PersonService : IPersonService
{
    private readonly IMapper _mapper;
    private readonly IPersonRepository _personRepository;

    public PersonService(IMapper mapper, IPersonRepository personRepository)
    {
        _mapper = mapper;
        _personRepository = personRepository;
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

    public async Task<PersonResponseModel> GetPersonAsync(int personId)
    {
        var entity = await _personRepository.SelectByIdAsync(personId);

        if (entity == null)
        {
            return new PersonResponseModel()
            {
                Id = personId,
                Errors = new List<string>{ "There is no such person in the database."}
            };
        }

        return _mapper.Map<PersonResponseModel>(entity);
    }

    public IEnumerable<PersonResponseModel> GetAllPersons()
    {
        var entities = _personRepository
            .SelectAll()
            .OrderByDescending(x => x.FullName);

        return _mapper.Map<IEnumerable<PersonResponseModel>>(entities);
    }

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
        await _personRepository.UpdateAsync(_mapper.Map<Person>(entity));
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
}