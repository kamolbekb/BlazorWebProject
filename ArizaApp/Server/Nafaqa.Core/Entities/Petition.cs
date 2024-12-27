using Nafaqa.Core.Common;
using Nafaqa.Core.Enums;

namespace Nafaqa.Core.Entities;

public class Petition : BaseEntity<int>
{
    public int PersonId { get; set; }
    public AllowanceTypes Allowance { get; set; }
    public string? Letter { get; set; }
    public DateOnly ApplicationDate { get; set; }
    public Person Person { get; set; }
}