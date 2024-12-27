using FluentValidation;
using Nafaqa.Application.Models.Petition;
using Nafaqa.Core.Entities;

namespace Nafaqa.Application.Validators.Petitions;

public class PetitionValidator : AbstractValidator<Petition>
{
    public PetitionValidator()
    {
        RuleFor(petition => petition)
            .NotNull();
    }
}