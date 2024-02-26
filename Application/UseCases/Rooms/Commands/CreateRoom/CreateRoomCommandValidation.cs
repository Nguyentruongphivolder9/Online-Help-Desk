﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Rooms.Commands.CreateRoom
{
    internal class CreateRoomCommandValidation: AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidation() 
        {
            RuleFor(r => r.RoomNumber)
                .NotEmpty().WithMessage("Room number cannot be blank");
            RuleFor(rs => rs.DepartmentId)
                .NotEmpty().WithMessage("Department Id cannot be blank");
        }    
    }
}
