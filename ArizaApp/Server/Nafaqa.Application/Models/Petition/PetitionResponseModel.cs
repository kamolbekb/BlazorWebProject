using System.Text.Json.Serialization;
using Nafaqa.Core.Enums;
namespace Nafaqa.Application.Models.Petition;

public class PetitionResponseModel : BaseResponseModel<int>
{
    public int PersonId { get; set; }
    public AllowanceTypes Allowance { get; set; }
    public string? Letter { get; set; }
    public DateOnly ApplicationDate { get; set; }
    [JsonIgnore]
    public Core.Entities.Person? Person { get; set; }
}