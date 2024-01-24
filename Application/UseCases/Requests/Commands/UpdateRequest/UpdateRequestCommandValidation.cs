using Application.UseCases.Requests.Commands.CreateRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Requests.Commands.UpdateRequest
{
    public class UpdateRequestCommandValidation : AbstractValidator<CreateRequestCommand>
    {
        public UpdateRequestCommandValidation()
        {
            RuleFor(aci => aci.AccountId)
                .NotEmpty().WithMessage("Account ID is required to be filled in");
            RuleFor(rid => rid.RoomId)
               .NotEmpty().WithMessage("Room id cannot be blank");

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
