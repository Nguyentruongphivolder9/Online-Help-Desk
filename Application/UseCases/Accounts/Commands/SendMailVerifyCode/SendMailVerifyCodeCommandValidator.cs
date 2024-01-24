using FluentValidation;

namespace Application.UseCases.Accounts.Commands.SendMailVerifyCode
{
    internal class SendMailVerifyCodeCommandValidator : AbstractValidator<SendMailVerifyCodeCommand>
    {
        public SendMailVerifyCodeCommandValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be left blank.")
                .EmailAddress().WithMessage("Please enter the correct Email data type.")
                .MaximumLength(100);
        }
    }
}
