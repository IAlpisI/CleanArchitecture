using Application.Common.Interface;
using Domain.Entities;
using Domain.Entities.Particapant;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly JWTAuthOptions _options;
        public TokenService(IUserRepository userRepository, IUserService userService, IOptions<JWTAuthOptions> options)
        {
            _userRepository = userRepository;
            _userService = userService;
            _options = options.Value;
        }

        public async Task<string> GetAccessTokenAsync(string userName, string clearTextPassword, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new System.ArgumentException($"'{nameof(userName)}' cannot be null or empty.", nameof(userName));
            }

            if (string.IsNullOrEmpty(clearTextPassword))
            {
                throw new System.ArgumentException($"'{nameof(clearTextPassword)}' cannot be null or empty.", nameof(clearTextPassword));
            }

            var user = await _userService.GetValidUserAsync(userName, clearTextPassword, cancellationToken);

            if(user is null)
            {
                return null;
            }

            var roles = await _userRepository.GetRoles(user.Id);

            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
            };
            foreach (Role role in roles)
            {
                claims.Add(new Claim("Role", role.Name));
            }

            JwtSecurityToken token = new(
                issuer: "saar",
                audience: "saar-audience",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(2),
                signingCredentials: new SigningCredentials(
                    key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret)),
                    algorithm: SecurityAlgorithms.HmacSha256
                )
             );

            return (new JwtSecurityTokenHandler()).WriteToken(token);
        }
    }
}
