using FluentValidation;
using Nafaqa.Application.Models.Petition;

namespace Nafaqa.Application.Validators.Petitions;

public class UpdatePetitionModelValidator : AbstractValidator<UpdatePetitionModel>
{
    public UpdatePetitionModelValidator()
    {
        RuleFor(petition => petition)
            .NotNull();
        
        RuleFor(petition => petition.Letter)
            .MaximumLength(500)
            .NotNull();
    }
}