namespace Nafaqa.Web.Models;

public class Petition
{
    public int PersonId { get; set; }
    public AllowanceTypes Allowance { get; set; }
    public string? Letter { get; set; }
    public DateOnly ApplicationDate { get; set; }
    public Person Person { get; set; }
}