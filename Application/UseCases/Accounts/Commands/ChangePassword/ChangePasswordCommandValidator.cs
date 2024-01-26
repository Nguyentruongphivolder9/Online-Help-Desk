using FluentValidation;

namespace Application.UseCases.Accounts.Commands.ChangePassword
{
    internal class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator() 
        {
            RuleFor(x => x.AccountId)
                .NotEmpty().WithMessage("Email cannot be left blank.")
                .MaximumLength(100);

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New password cannot be left blank.");

            RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm password cannot be left blank.")
            .Equal(x => x.NewPassword).WithMessage("Confirm password must match the new password.");
        }
    }
}
