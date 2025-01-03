using System.Text.Json.Serialization;
using Nafaqa.Core.Common;
using Nafaqa.Core.Enums;

namespace Nafaqa.Core.Entities;

public class Person : BaseEntity<int>
{
    public string FullName { get; set; }
    public Gender Gender { get; set; }
    public string PassportSeria { get; set; }
    public long PassportNumber { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Photo> Photos { get; set; }
    [JsonIgnore]
    public ICollection<Petition> Petitions { get; set; }

   
}