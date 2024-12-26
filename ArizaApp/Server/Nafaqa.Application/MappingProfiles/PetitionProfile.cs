using AutoMapper;
using Nafaqa.Application.Models.Petition;
using Nafaqa.Core.Entities;

namespace Nafaqa.Application.MappingProfiles;

public class PetitionProfile : Profile
{
    public PetitionProfile()
    {
        CreateMap<CreatePetitionModel, Petition>();
        CreateMap<Petition, PetitionResponseModel>();
    }
}