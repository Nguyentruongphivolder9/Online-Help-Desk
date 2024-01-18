using System.Text.Encodings.Web;

namespace Domain.Entities
{
    public class HelpAbout
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
