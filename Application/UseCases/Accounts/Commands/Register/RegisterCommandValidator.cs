using FluentValidation;

namespace Application.UseCases.Accounts.Commands.Register
{
    internal class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.AccountId)
                .NotEmpty().WithMessage("AccountId cannot be left blank.")
                .MaximumLength(15).WithMessage("AccountId must not exceed 15 characters.")
                .Must(accountId => !accountId.Contains(" ")).WithMessage("AccountId cannot contain spaces.");
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("FullName cannot be left blank.")
                .MaximumLength(20).WithMessage("FullName must not exceed 20 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be left blank.")
                .EmailAddress().WithMessage("Please enter the correct Email data type.")
                .MaximumLength(100).WithMessage("Up to 100 characters");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address cannot be left blank.")
                .MaximumLength(100).WithMessage("Up to 100 characters");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber cannot be left blank.")
                .Must(phoneNumber => phoneNumber.All(char.IsDigit)).WithMessage("PhoneNumber must contain only digits.")
                .Length(10, 11).WithMessage("PhoneNumber must have between 10 and 11 digits.");
            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender cannot be left blank.")
                .Must(gender => gender == "Male" || gender == "Female" || gender == "Other")
                    .WithMessage("Invalid value for Gender. Allowed values are 'Male', 'Female', or 'Other'.");
            RuleFor(x => x.Birthday)
                .NotEmpty().WithMessage("Birthday cannot be left blank.")
                .Matches(@"^\d{2}/\d{2}/\d{4}$").WithMessage("Invalid date format. Please use MM/dd/yyyy.");

        }
    }
}
