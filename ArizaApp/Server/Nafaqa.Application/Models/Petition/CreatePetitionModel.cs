using System.Transactions;
using Nafaqa.Core.Enums;

namespace Nafaqa.Application.Models.Petition;

public class CreatePetitionModel
{
    public int PersonId { get; set; }
    public AllowanceTypes Allowance { get; set; }
    public string? Letter { get; set; }
}

public class CreatePetitionResponseModel : BaseResponseModel<int>
{
}