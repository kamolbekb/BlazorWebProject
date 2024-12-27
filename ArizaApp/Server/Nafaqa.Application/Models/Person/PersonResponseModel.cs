using Nafaqa.Core.Enums;

namespace Nafaqa.Application.Models.Person;

public class PersonResponseModel : BaseResponseModel<int>
{
    public string FullName { get; set; }
    public Gender Gender { get; set; }
    public string PassportSeria { get; set; }
    public long PassportNumber { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}