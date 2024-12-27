using FluentValidation;
using Nafaqa.Application.Models.Person;

namespace Nafaqa.Application.Validators.Persons;

public class UpdatePersonModelValidator : AbstractValidator<UpdatePersonModel>
{
    public UpdatePersonModelValidator()
    {
        RuleFor(person => person)
            .NotNull();
    }
}