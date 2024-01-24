using Application.Common.Mapppings;
using Domain.Entities.Accounts;
using Domain.Entities.Roles;
using System.Text.Json.Serialization;

namespace Application.DTOs
{
    public class LoginResponse : IMapForm<Account>
    {
        public string AccountId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public string? AvatarPhoto { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public bool Enable { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
