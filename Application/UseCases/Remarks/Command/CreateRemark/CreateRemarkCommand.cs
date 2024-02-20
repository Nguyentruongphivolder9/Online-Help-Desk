﻿using Application.Common.Messaging;
using Application.DTOs.Remarks;
using Domain.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Remarks.Command.CreateRemark
{

    public record class CreateRemarkCommand(string accountId, string requestId, string comment, bool? Enable) : ICommand<RemarkDTO>
    {
    }
}
