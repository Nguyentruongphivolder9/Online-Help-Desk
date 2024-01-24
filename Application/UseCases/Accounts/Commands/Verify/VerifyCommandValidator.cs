using FluentValidation;

namespace Application.UseCases.Accounts.Commands.Verify
{
    internal class VerifyCommandValidator : AbstractValidator<VerifyCommand>
    {
        public VerifyCommandValidator() 
        {
            RuleFor(x => x.AccountId)
                .NotEmpty().WithMessage("Email cannot be left blank.")
                .Matches("^[a-zA-Z0-9]+$").WithMessage("Account code should only contain letters and numbers.")
                .MaximumLength(100);
            RuleFor(x => x.VerifyCode)
                .NotEmpty().WithMessage("Code cannot be left blank.")
                .Matches("^[0-9]+$").WithMessage("The verification code should contain only numbers.")
                .Length(7);
        } 
    }
}
