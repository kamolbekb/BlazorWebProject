using Nafaqa.Application.Models.Petition;

namespace Nafaqa.Application.Services;

public interface IPetitionService
{
    Task<CreatePetitionResponseModel> CreatePetitionAsync(CreatePetitionModel createPetitionModel);
}