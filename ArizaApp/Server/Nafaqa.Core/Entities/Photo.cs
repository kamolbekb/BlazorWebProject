using Nafaqa.Core.Common;

namespace Nafaqa.Core.Entities;

public class Photo : BaseEntity<int>
{
    public string FilePath { get; set; } = string.Empty;
    public int PersonId { get; set; }
    public Person Person { get; set; }
}