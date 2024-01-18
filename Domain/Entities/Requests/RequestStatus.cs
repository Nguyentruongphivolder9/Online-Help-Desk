namespace Domain.Entities.Requests
{
    public class RequestStatus
    {
        public Guid Id { get; set; }
        public string StatusName { get; set; }
        public string ColorCode { get; set; }

        public List<Request>? Requests { get; set; }
    }
}
