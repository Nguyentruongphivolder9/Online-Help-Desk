using FluentValidation;

namespace Application.UseCases.Accounts.Commands.Verify
{
    internal class VerifyCommandValidator : AbstractValidator<VerifyCommand>
    {
        public VerifyCommandValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be left blank.")
                .EmailAddress().WithMessage("Please enter the correct Email data type.")
                .MaximumLength(100);
            RuleFor(x => x.VerifyCode)
                .NotEmpty().WithMessage("Code cannot be left blank.")
                .Length(7);
        } 
    }
}
