using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BmesRestApi.Infrastructure;
using BmesRestApi.Messages.Request.User;
using BmesRestApi.Messages.Response.User;
using BmesRestApi.Models.Shared;
using BmesRestApi.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BmesRestApi.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly AuthSettings _authSettings;
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository, IOptions<AuthSettings> authSettings)
        {
            _authRepository = authRepository;
            _authSettings = authSettings.Value;
        }

        public async Task<FindUserByEmailResponse> FindAsync(FindUserByEmailRequest request, CancellationToken cancellationToken)
        {
            var user = await _authRepository.FindAsync(request.Email, cancellationToken);

            var findByEmailResponse = new FindUserByEmailResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return findByEmailResponse;
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken)
        {
            var messages = new List<string>();

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                UserName = request.Email
            };

            var result = await _authRepository.RegisterAsync(user, request.Password, cancellationToken);

            if (result.Succeeded)
            {
                messages.Add("User Registered");

                var registerResponse = new RegisterResponse
                {
                    Name = request.Name,
                    Email = request.Email,
                    StatusCode = HttpStatusCode.Created,
                    Messages = messages
                };

                return registerResponse;
            }
            else
            {

                foreach (var error in result.Errors)
                {
                    messages.Add(error.Description);
                }

                var registerResponse = new RegisterResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Messages = messages
                };

                return registerResponse;
            }
        }

        public async Task<LogInResponse> LogInAsync(LogInRequest request, CancellationToken cancellationToken)
        {
            var messages = new List<string>();

            var result = await _authRepository.LogInAsync(request.Email, request.Password, cancellationToken);

            if (result)
            {
                messages.Add("Logged in successfully");

                var roles = await _authRepository.FindUserRolesAsync(request.Email, cancellationToken);

                var logInResponse = new LogInResponse
                {
                    Token = GenerateJwtToken(request, roles),
                    StatusCode = HttpStatusCode.OK,
                    Messages = messages
                };

                return logInResponse;
            }
            else
            {
                messages.Add("You Email address or password is not valid. Please try again with valid credentials");

                var logInResponse = new LogInResponse
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Messages = messages
                };

                return logInResponse;
            }
        }

        private string GenerateJwtToken(LogInRequest request, IList<string> roles)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Email, request.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authSettings.Key);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddMinutes(_authSettings.ExpirationInMinutes)
            };

            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }
    }
}
