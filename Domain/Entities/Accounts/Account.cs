﻿using Domain.Entities.Requests;
using Domain.Entities.Roles;
using System.Text.Json.Serialization;

namespace Domain.Entities.Accounts
{
    public class Account
    {
        public string AccountId { get; set; }
        public Guid RoleId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? AvatarPhoto { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? VerifyCode { get; set; }
        public DateTime? VerifyRefreshExpiry { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }
        public bool Enable { get; set; }
        public string StatusAccount { get; set; }

        [JsonIgnore]
        public Role? Role { get; set; }
        public List<Request>? Requests { get; set; }
        public List<Remark>? Remarks { get; set; }
        public List<ProcessByAssignees>? ProcessByAssignees { get; set; }
    }
}
