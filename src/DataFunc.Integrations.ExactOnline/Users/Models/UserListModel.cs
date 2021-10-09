using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.Users.Models
{
    [ExactOnlineResource("/api/v1/{0}/users/Users")]
    public class UserListModel
    {
        public Guid UserID { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}