using Application.Common.Mapppings;
using Application.DTOs.Accounts;
using Application.DTOs.Requests;
using Domain.Entities.Requests;

namespace Application.DTOs.Remarks
{
    public class RemarkDTO : IMapForm<Remark>
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public string AccountId { get; set; }
        public string Comment { get; set; }
        public DateTime CreateAt { get; set; }
        public bool Enable { get; set; }
        public AccountResponse? Account { get; set; }
        public RequestDTO? Request { get; set; }
    }
}
