using Application.Common.Mapppings;
using Domain.Entities.Accounts;

namespace Application.DTOs.Users
{
    public class UserDTO : IMapForm<Account>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? AvatarImage { get; set; }
        public string? Gender { get; set; }
        public string? Birthday { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string StatusAccount { get; set; }

    }
}
