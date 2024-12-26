namespace Nafaqa.Web.Models;

public class Petition
{
    public string FullName { get; set; }
    public Gender Gender { get; set; }
    public string PassportSeria { get; set; }
    public long PassportNumber { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    
    public DateOnly ApplicationDate { get; set; }
    public AllowanceTypes Allowance { get; set; }
}