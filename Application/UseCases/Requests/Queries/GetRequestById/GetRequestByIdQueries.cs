using Application.Common.Messaging;
using Application.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Requests.Queries.GetRequestById
{
    public sealed record GetRequestByIdQueries : IQuery<RequestResponse>
    {
        public Guid Id { get; set; }
        public string Something2 { get; set; }
    }
}
