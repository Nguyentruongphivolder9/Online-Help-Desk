namespace Application.DTOs
{
    public class LoginResponse
    {
        public string AccountId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration {  get; set; }
    }
}
