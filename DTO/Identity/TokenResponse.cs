using System;

namespace MovieReviews.Models
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public bool IsLoginSuccessful { get; set; }
    }
}