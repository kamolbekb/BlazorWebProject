using AutoMapper;
using Nafaqa.Application.Models.Person;
using Nafaqa.Core.Entities;

namespace Nafaqa.Application.MappingProfiles;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<CreatePersonModel, Person>();
        CreateMap<Person, PersonResponseModel>();
        CreateMap<UpdatePersonModel, Person>();
    }
}