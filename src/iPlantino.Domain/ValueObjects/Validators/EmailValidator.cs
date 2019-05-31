using FluentValidation;

namespace iPlantino.Domain.ValueObjects.Validators
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(x => x.Address)
               .NotEmpty().WithMessage("Please ensure you have entered the Email")
               .EmailAddress().WithMessage("The Email provided is invalid");
        }
    }
}
