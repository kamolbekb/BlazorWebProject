using FluentValidation;
using Nafaqa.Application.Models.Person;

namespace Nafaqa.Application.Validators.Persons;

public class CreatePersonModelValidator : AbstractValidator<CreatePersonModel>
{
    public CreatePersonModelValidator()
    {
        RuleFor(person => person)
            .NotNull();
        
        RuleFor(person => person.FullName)
            .MaximumLength(50)
            .NotEmpty();
        
        RuleFor(person => person.PassportSeria)
            .MaximumLength(10)
            .NotEmpty();
        
        RuleFor(person => person.PassportNumber)
            .MaximumLength(10)
            .NotEmpty();
    }
}