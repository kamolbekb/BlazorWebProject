using AutoMapper;
using Nafaqa.Application.Models;
using Nafaqa.Application.Models.Person;
using Nafaqa.Core.Entities;

namespace Nafaqa.Application.MappingProfiles;

public class BaseProfile : Profile
{
    public BaseProfile()
    {
        CreateMap<Person, BaseResponseModel<int>>();
        CreateMap<Petition, BaseResponseModel<int>>();
    }
}