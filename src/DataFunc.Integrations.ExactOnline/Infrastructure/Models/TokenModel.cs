using System;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Models
{
    public class TokenModel
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public DateTime RefreshTokenExpirationDate { get; set; }
        public DateTime AccessTokenExpirationDate { get; set; }
    }
}