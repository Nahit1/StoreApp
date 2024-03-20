using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StoreApp.Application.Core.DTOs;
using StoreApp.Application.Features.Queries.Accounts.LoginUsers;
using StoreApp.Application.Repositories;
using StoreApp.Domain.Entities;

namespace StoreApp.Persistance.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> _userManager;
        readonly IConfiguration _configuration;

        public AccountRepository(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<DefaultResponse<LoginUsersDto>> LoginUser(
            LoginUsersQuery request,
            CancellationToken cancellationToken
        )
        {
            var user = await _userManager
                .Users.Where(x => x.Email == request.Email)
                .FirstOrDefaultAsync();

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return DefaultResponse<LoginUsersDto>.Failure("Email or password wrong!");

            LoginUsersDto loginUser =
                new()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    PhoneNumber = user.PhoneNumber,
                    UserId = user.Id,
                    Token = GenerateToken(user)
                };

            return DefaultResponse<LoginUsersDto>.Successful(loginUser);
        }

        private TokenDto GenerateToken(AppUser user)
        {
            var tokenExpiration = DateTime.Now.AddHours(12);
            SymmetricSecurityKey securityKey =
                new(Encoding.UTF8.GetBytes(_configuration["TokenKey"]));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken =
                new(
                    expires: tokenExpiration,
                    notBefore: DateTime.Now,
                    signingCredentials: signingCredentials
                );

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDto { Token = token, TokenExpiration = tokenExpiration };

            return tokenDto;
        }
    }
}
