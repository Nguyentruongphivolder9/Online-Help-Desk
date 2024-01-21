using FluentValidation;

namespace Application.UseCases.Accounts.Commands.Login
{
    internal class LoginCommandValidation : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidation()
        {
            RuleFor(x => x.AccountId)
                .NotEmpty().WithMessage("Email cannot be left blank.")
                .EmailAddress().WithMessage("Please enter the correct Email data type.")
                .MaximumLength(100);
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be left blank.")
                .Must(username => !username.Contains(" ")).WithMessage("Password cannot contain spaces."); ;
        }
    }
}
