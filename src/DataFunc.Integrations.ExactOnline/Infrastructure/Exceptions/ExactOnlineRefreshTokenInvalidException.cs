using System;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Exceptions
{
    public class ExactOnlineRefreshTokenInvalidException : Exception
    {
        public ExactOnlineRefreshTokenInvalidException() : base("The provided refresh token was invalid or expired")
        {
        }
    }
}