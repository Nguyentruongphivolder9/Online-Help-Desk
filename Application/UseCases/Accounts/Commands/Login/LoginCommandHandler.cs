using Application.Common.Messaging;
using Application.DTOs;
using Application.Services;
using Domain.Repositories;
using SharedKernel;
using System.Security.Claims;

namespace Application.UseCases.Accounts.Commands.Login
{
    public sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IBCryptService _encryptService;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(
            IUnitOfWorkRepository repo,
            IBCryptService encryptService,
            ITokenService tokenService)
        {
            _repo = repo;
            _encryptService = encryptService;
            _tokenService = tokenService;
        }

        public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _repo.accountRepo.GetByEmail(request.AccountId);
            var errorLogin = new Error("Error.Login", "Client errors");
            if (user == null)
                return Result.Failure<LoginResponse>(errorLogin, "Login faild! Incorrect Email or Password.");

            var checkPassword = _encryptService.DecryptString(request.Password, user.Password);
            if (!checkPassword)
                return Result.Failure<LoginResponse>(errorLogin, "Login faild! Incorrect Email or Password.");

            switch (user.StatusAccount)
            {
                case string value when value == StaticVariables.StatusAccountUser[0]:
                    return Result.Failure<LoginResponse>(errorLogin, "Login faild! Incorrect Email or Password.");

                case string value when value == StaticVariables.StatusAccountUser[1]:
                    //var userRoles = await _repo.userRoleRepository.GetRoleByUserId(user.Id);

                    /*if (!userRoles.Any())
                        return Result.Failure<LoginResponse>(errorLogin, "Login faild! Something went wrong! Please try again later.");
*/
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.FullName),
                        new Claim(ClaimTypes.Email, user.Email),
                        //new Claim(ClaimTypes.Role, role.RoleName)
                    };

                    var token = _tokenService.GetToken(claims);
                    var refreshToken = _tokenService.GetRefreshToken();

                    user.RefreshToken = refreshToken;
                    user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
                    //_repo.authRepository.Update(user);

                    try
                    {
                        await _repo.SaveChangesAsync(cancellationToken);

                        var loginResponse = new LoginResponse
                        {
                            AccountId = user.AccountId,
                            FullName = user.FullName,
                            Email = user.Email,
                            Token = token.TokenString!,
                            RefreshToken = refreshToken,
                            Expiration = token.ValidTo
                        };

                        return Result.Success(loginResponse, "Login Successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Error error = new("Error.LoginCommandHandler", "There is an error saving data!");
                        return Result.Failure<LoginResponse>(error, "Login failed!");
                    }


                case string value when value == StaticVariables.StatusAccountUser[2]:
                    return Result.Failure<LoginResponse>(errorLogin, "Your account is temporarily banned from logging in.");

                case string value when value == StaticVariables.StatusAccountUser[3]:
                    return Result.Failure<LoginResponse>(errorLogin, "Your account has been banned from logging in.");
                default:
                    return Result.Failure<LoginResponse>(errorLogin, "Login faild! Incorrect Email or Password.");
            }
        }
    }
}
