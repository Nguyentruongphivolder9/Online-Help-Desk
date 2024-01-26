using Application.Common.Messaging;
using Application.DTOs;
using Application.Services;
using AutoMapper;
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
            var user = await _repo.accountRepo.GetByAccountId(request.AccountId);
            var errorLogin = new Error("Error.Login", "Client errors");
            if (user == null)
                return Result.Failure<LoginResponse>(errorLogin, "Login faild! Incorrect Account code or Password.");

            var checkPassword = _encryptService.DecryptString(request.Password, user.Password);
            if (!checkPassword)
                return Result.Failure<LoginResponse>(errorLogin, "Login faild! Incorrect Account code or Password.");

            if(user.StatusAccount == StaticVariables.StatusAccountUser[0] ||
                user.StatusAccount == StaticVariables.StatusAccountUser[1])
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Sid, user.AccountId),
                        new Claim(ClaimTypes.Name, user.FullName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role!.RoleTypes!.RoleTypeName),
                        new Claim("RoleName", user.Role!.RoleName),
                    };

                var token = _tokenService.GetToken(claims);
                var refreshToken = _tokenService.GetRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
                _repo.accountRepo.Update(user);

                try
                {
                    await _repo.SaveChangesAsync(cancellationToken);

                    var loginResponse = new LoginResponse
                    {
                        AccountId = user.AccountId,
                        FullName = user.FullName,
                        Email = user.Email,
                        RoleName = user.Role.RoleName,
                        RoleTypeName = user.Role.RoleTypes.RoleTypeName,
                        AvatarPhoto = user.AvatarPhoto,
                        Address = user.Address,
                        PhoneNumber = user.PhoneNumber,
                        Gender = user.Gender,
                        Birthday = user.Birthday,
                        Enable = user.Enable,
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
            }

            if(user.StatusAccount == StaticVariables.StatusAccountUser[2])
                return Result.Failure<LoginResponse>(errorLogin, "Your account is temporarily banned from logging in.");
            
            if(user.StatusAccount == StaticVariables.StatusAccountUser[3])
                return Result.Failure<LoginResponse>(errorLogin, "Your account has been banned from logging in.");

            return Result.Failure<LoginResponse>(errorLogin, "Login faild! Incorrect Account code or Password.");
        }
    }
}
