using FluentValidation;

namespace Application.UseCases.Accounts.Commands.SendMailVerifyCode
{
    internal class SendMailVerifyCodeCommandValidator : AbstractValidator<SendMailVerifyCodeCommand>
    {
        public SendMailVerifyCodeCommandValidator() 
        {
            RuleFor(x => x.AccountId)
                .NotEmpty().WithMessage("Account code cannot be left blank.")
                .Matches("^[a-zA-Z0-9]+$").WithMessage("Account code should only contain letters and numbers.")
                .MaximumLength(20);
        }
    }
}
