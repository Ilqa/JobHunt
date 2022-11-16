﻿using JobHunt.Configurations;
using JobHunt.Database.Entities;
using JobHunt.DTO.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobHunt.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserType> _roleManager;
       // private readonly JwtSettings _jwtSettings;

        public IdentityService(
            UserManager<User> userManager, RoleManager<UserType> roleManager) //, JwtSettings jwtSettings
        {
            _userManager = userManager;
            _roleManager = roleManager;
            //_jwtSettings = jwtSettings;
        }


        public async Task<TokenResponse> Login(TokenRequest model)
        {
            TokenResponse response = new();
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                response.Message = "User Not Found.";
                return response;
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                response.Message = "Invalid Credentials.";
                return response;
            }

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
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("S0M3RAN0MS3CR3T!1!MAG1C!1!")); //_jwtSettings.Key
            var token = new JwtSecurityToken(
            issuer: "JobHunt.Api", //_jwtSettings.Issuer,
            audience: "JobHunt.Api", // _jwtSettings.Audience,
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new TokenResponse { Token = new JwtSecurityTokenHandler().WriteToken(token), IsLoginSuccessful = true, UserId = user.Id };


        }
    }
}