using Application.UseCases.Accounts.Commands.Register;
using FluentValidation;

namespace Application.UseCases.Accounts.Commands.UpdateAccount
{
    internal class UpdateAccountCommandValidator : AbstractValidator<RegisterCommand>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("FullName cannot be left blank.")
                .MaximumLength(30).WithMessage("FullName must not exceed 20 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be left blank.")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithMessage("Please enter a valid email address.");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address cannot be left blank.")
                .MaximumLength(200).WithMessage("Up to 100 characters");
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
                .Matches(@"^\d{4}/\d{2}/\d{2}$").WithMessage("Invalid date format. Please use MM/dd/yyyy.");

        }
    }
}
