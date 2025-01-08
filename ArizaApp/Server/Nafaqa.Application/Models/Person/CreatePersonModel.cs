using Nafaqa.Core.Enums;

namespace Nafaqa.Application.Models.Person;

public class CreatePersonModel
{
    public string FullName { get; set; }
    public Gender Gender { get; set; }
    public string PassportSeria { get; set; }
    public string PassportNumber { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}

public class CreatePersonResponseModel : BaseResponseModel<int>
{ }