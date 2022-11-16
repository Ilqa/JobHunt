using System;

namespace JobHunt.DTO.Identity
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public bool IsLoginSuccessful { get; set; }
        public int UserId { get; set; }
    }
}