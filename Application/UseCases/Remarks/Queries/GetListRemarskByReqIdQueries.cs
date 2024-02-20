using Application.Common.Messaging;
using Application.DTOs.Remarks;
using Application.DTOs.Requests;
using Domain.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Remarks.Queries
{
    public class GetListRemarskByReqIdQueries : IQuery<List<RemarkDTO>>
    {
        public string? RequestId { get; set; }
    }
}
