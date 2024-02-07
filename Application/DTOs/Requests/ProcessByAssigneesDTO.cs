using Application.Common.Mapppings;
using Domain.Entities.Requests;

namespace Application.DTOs.Requests
{
    public class ProcessByAssigneesDTO : IMapForm<ProcessByAssignees>
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public string AccountId { get; set; }
        public AccountDTO Account { get; set; }
    }
}

