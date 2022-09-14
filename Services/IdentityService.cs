
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MovieReviews.Configurations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BooksBot.API.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtSettings _jwtSettings;

        public IdentityService(
            UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings;
        }


        public async Task<string> Login(string email, string password)
        {

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return string.Empty;


            var passwordValid = await _userManager.CheckPasswordAsync(user, password);
            if (!passwordValid)
                return string.Empty;


            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
                                                {
                                                new Claim(ClaimTypes.Name, user.UserName),
                                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                                };
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }
}