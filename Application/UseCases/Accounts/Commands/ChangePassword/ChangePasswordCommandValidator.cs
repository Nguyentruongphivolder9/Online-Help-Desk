using FluentValidation;

namespace Application.UseCases.Accounts.Commands.ChangePassword
{
    internal class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be left blank.")
                .EmailAddress().WithMessage("Please enter the correct Email data type.")
                .MaximumLength(100);

            RuleFor(x => x.Newpassword)
                .NotEmpty().WithMessage("New password cannot be left blank.");

            RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm password cannot be left blank.")
            .Equal(x => x.Newpassword).WithMessage("Confirm password must match the new password.");
        }
    }
}
