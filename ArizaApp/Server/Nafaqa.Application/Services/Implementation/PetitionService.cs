using AutoMapper;
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
}