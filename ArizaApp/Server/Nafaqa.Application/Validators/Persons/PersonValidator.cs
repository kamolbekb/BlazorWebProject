using FluentValidation;
using Nafaqa.Core.Entities;

namespace Nafaqa.Application.Validators.Persons;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(person => person)
            .NotNull();
    }
}