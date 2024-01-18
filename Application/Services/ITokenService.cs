using Application.DTOs;
using System.Security.Claims;

namespace Application.Services
{
    public interface ITokenService
    {
        TokenResponse GetToken(IEnumerable<Claim> claims);
        string GetRefreshToken();
    }
}
