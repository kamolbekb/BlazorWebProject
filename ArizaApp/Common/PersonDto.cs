namespace Common;

public class PersonDto{
    public int Id { get; set; }
    public string FullName { get; set; }
    public Gender Gender { get; set; }
    public string PassportSeria { get; set; }
    public string PassportNumber { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public PhotoDto PhotoDto { get; set; }
    public ICollection<PetitionDto> Petitions { get; set; }
}