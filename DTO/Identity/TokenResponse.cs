using System;

namespace JobHunt.DTO.Identity
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }

    }
}