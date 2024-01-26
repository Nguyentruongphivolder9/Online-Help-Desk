using FluentValidation;

namespace Application.UseCases.Requests.Commands.CreateRequest
{
    public class CreateRequestCommandValidator : AbstractValidator<CreateRequestCommand>
    {
        public CreateRequestCommandValidator()
        {
            RuleFor(aci => aci.AccountId)
                .NotEmpty().WithMessage("Account ID is required to be filled in");
            RuleFor(rid => rid.RoomId)
               .NotEmpty().WithMessage("Room cannot be blank");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be left blank.")
                .MaximumLength(100).WithMessage("Description does not exceed 100 characters.")
                .Matches("^[a-zA-Z0-9]+$").WithMessage("Description is not following pattern");
            RuleFor(x => x.SeveralLevel)
                .NotEmpty().WithMessage("SeveralLevel cannot be blank.")
                .MaximumLength(20).WithMessage("SeveralLevel does not exceed 20 characters ");
            RuleFor(r => r.Reason)
               .MaximumLength(50).WithMessage("Reason does not exceed 50 characters");
        }

    }
}
