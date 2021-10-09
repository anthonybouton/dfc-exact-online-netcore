using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.Users.Models
{
    [ExactOnlineResource("/api/v1/current/Me")]
    public class Me
    {
        public int CurrentDivision { get; set; }
    }
}