using Nafaqa.Core.Enums;

namespace Nafaqa.Application.Models.Petition;

public class UpdatePetitionModel
{
    public AllowanceTypes Allowance { get; set; }
    public string? Letter { get; set; }
}

public class UpdatePetitionResponseModel : BaseResponseModel<int> { }
