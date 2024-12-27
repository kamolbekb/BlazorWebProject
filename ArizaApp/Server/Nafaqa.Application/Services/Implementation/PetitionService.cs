using AutoMapper;
using Nafaqa.Application.Models;
using Nafaqa.Application.Services;
using Nafaqa.Application.Models.Petition;
using Nafaqa.Core.Entities;
using Nafaqa.DataAccess.Repositories;

namespace Nafaqa.Application.Services.Implementation;

public class PetitionService: IPetitionService
{
    private readonly IMapper _mapper;
    private readonly IPetitionRepository _petitionRepository;

    public PetitionService(IMapper mapper, IPetitionRepository petitionRepository)
    {
        _mapper = mapper;
        _petitionRepository = petitionRepository;
    }

    public async Task<CreatePetitionResponseModel> CreatePetitionAsync(CreatePetitionModel createPetitionModel)
    {
        var petition = _mapper.Map<Petition>(createPetitionModel);
        petition.ApplicationDate = DateOnly.FromDateTime(DateTime.UtcNow);
        var addedPetition = await _petitionRepository.InsertAsync(petition);
        return new CreatePetitionResponseModel
        {
            Id = addedPetition.Id,
        };

    }

    public async Task<PetitionResponseModel> GetPetitionAsync(int petitionId)
    {
        var entity = await _petitionRepository.SelectByIdAsync(petitionId);
        
        if (entity == null)
        {
            return new PetitionResponseModel()
            {
                Id = petitionId,
                Errors = new List<string>{ "There is no such person in the database."}
            };
        }
        
        return _mapper.Map<PetitionResponseModel>(entity);
    }

    public IEnumerable<PetitionResponseModel> GetPersonsPetitions(int personId)
    {
        var entities = _petitionRepository
            .SelectAll()
            .Where(petition => petition.PersonId == personId );
        
        return _mapper.Map<IEnumerable<PetitionResponseModel>>(entities);
    }

    public IEnumerable<PetitionResponseModel> GetAllPetitions()
    {
        var entities = _petitionRepository
            .SelectAll()
            .OrderBy(x => x.Id);
        
        return _mapper.Map<IEnumerable<PetitionResponseModel>>(entities);
    }

    public async Task<BaseResponseModel<int>> UpdatePetitionAsync(int id, UpdatePetitionModel updatePetitionModel)
    {
        var entity = _petitionRepository.
                SelectAll()
                .FirstOrDefault(i=>i.Id == id);
        
        if (entity is null)
        {
            return new BaseResponseModel<int>
            {
                Id = -1,
                Errors = new List<string> { "You are trying to Update a Person that doesn't exist" }
            };        
        }
        
        await _petitionRepository.UpdateAsync(_mapper.Map<Petition>(entity));
        await _petitionRepository.SaveChangesAsync();
        
        return new BaseResponseModel<int>
        {
            Id = id,
            Errors = null
        };
    }

    public async Task<BaseResponseModel<int>> DeletePetitionAsync(int id)
    {
        var entity = await _petitionRepository.SelectByIdAsync(id);
        if (entity is null)
        {
            return new BaseResponseModel<int>
            {
                Id = -1,
                Errors = new List<string> { "You are trying to Delete a Person that doesn't exist" }
            };        
        }
        await _petitionRepository.DeleteAsync(entity);
        await _petitionRepository.SaveChangesAsync();
        return new BaseResponseModel<int>
        {
            Id = id,
            Errors = null
        };
    }
}