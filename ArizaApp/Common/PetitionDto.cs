namespace Common;

public class PetitionDto{
    public int Id { get; set; }
    public AllowanceType Allowance { get; set; }
    public int PersonId { get; set; }
    public string Letter { get; set; }
    public DateOnly ApplicationDate { get; set; }
    public PersonDto Person { get; set; }
}