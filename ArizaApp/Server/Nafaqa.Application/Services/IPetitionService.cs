using Nafaqa.Application.Models;
using Nafaqa.Application.Models.Petition;

namespace Nafaqa.Application.Services;

public interface IPetitionService
{
    Task<CreatePetitionResponseModel> CreatePetitionAsync(CreatePetitionModel createPetitionModel);
    Task<PetitionResponseModel> GetPetitionAsync(int petitionId);
    public IEnumerable<PetitionResponseModel> GetPersonsPetitions(int personId);

    IEnumerable<PetitionResponseModel> GetAllPetitions();
    // Task<IEnumerable<PetitionResponseModel>> GetAllPetitions(int pageNumber, int elementsPerPage);
    Task<BaseResponseModel<int>> UpdatePetitionAsync(int id, UpdatePetitionModel updatePetitionModel);
    Task<BaseResponseModel<int>> DeletePetitionAsync(int id);
}