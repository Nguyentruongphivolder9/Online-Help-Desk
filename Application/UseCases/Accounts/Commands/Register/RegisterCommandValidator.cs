using FluentValidation;

namespace Application.UseCases.Accounts.Commands.Register
{
    internal class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("FullName cannot be left blank.")
                .MaximumLength(20).WithMessage("FullName must not exceed 20 characters.")
                .Must(username => !username.Contains(" ")).WithMessage("FullName cannot contain spaces.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be left blank.")
                .EmailAddress().WithMessage("Please enter the correct Email data type.")
                .MaximumLength(100);
        }
    }
}
