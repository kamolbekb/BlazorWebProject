using FluentValidation;
using Nafaqa.Application.Models.Petition;

namespace Nafaqa.Application.Validators.Petitions;

public class CreatePetitionModelValidator : AbstractValidator<CreatePetitionModel>
{
    public CreatePetitionModelValidator()
    {
        RuleFor(petition => petition)
            .NotNull();
        
        RuleFor(petition => petition.Letter)
            .MaximumLength(500)
            .NotNull();

        RuleFor(petition => petition.PersonId)
            .NotEmpty();
    }
}