using Nafaqa.Core.Common;
using Nafaqa.Core.Enums;

namespace Nafaqa.Core.Entities;

public class Petition : BaseEntity<int>
{
    public string FullName { get; set; }
    public Gender Gender { get; set; }
    public string PassportSeria { get; set; }
    public long PassportNumber { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    
    public int PersonId { get; set; }
    public DateOnly ApplicationDate { get; set; }
    public AllowanceTypes Allowance { get; set; }
    public Person Person { get; set; }
}