﻿using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.Users.Models
{
    [ExactOnlineResource("/api/v1/{0}/users/Users")]
    public class UserDetailModel
    {
        /// <summary>Birth date</summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>Birth name</summary>
        public string BirthName { get; set; }
        /// <summary>Creation date</summary>
        public DateTime? Created { get; set; }
        /// <summary>User ID of the creator</summary>
        public Guid? Creator { get; set; }
        /// <summary>Name of the creator</summary>
        public string CreatorFullName { get; set; }
        /// <summary>Customer the user belongs to</summary>
        public Guid Customer { get; set; }
        /// <summary>Name of Customer</summary>
        public string CustomerName { get; set; }
        /// <summary>Email address of the user</summary>
        public string Email { get; set; }
        /// <summary>Date after which the user login is disabled. NULL means no enddate</summary>
        public DateTime? EndDate { get; set; }
        /// <summary>First name</summary>
        public string FirstName { get; set; }
        /// <summary>Full name of the user</summary>
        public string FullName { get; set; }
        /// <summary>Gender: M=Male, V=Female, O=Unknown</summary>
        public string Gender { get; set; }
        /// <summary>User has completed registration of Two-Step verification</summary>
        public bool HasRegisteredForTwoStepVerification { get; set; }
        /// <summary>User must use Two-Step verification to log in</summary>
        public bool HasTwoStepVerification { get; set; }
        /// <summary>Initials</summary>
        public string Initials { get; set; }
        /// <summary>Language (culture) that is used in Exact Online</summary>
        public string Language { get; set; }
        /// <summary>The last time this user logged in</summary>
        public DateTime? LastLogin { get; set; }
        /// <summary>Last name</summary>
        public string LastName { get; set; }
        /// <summary>Middle name</summary>
        public string MiddleName { get; set; }
        /// <summary>Mobile phone</summary>
        public string Mobile { get; set; }
        /// <summary>Last modified date</summary>
        public DateTime? Modified { get; set; }
        /// <summary>User ID of the last modifier</summary>
        public Guid? Modifier { get; set; }
        /// <summary>Name of the last modifier</summary>
        public string ModifierFullName { get; set; }
        /// <summary>Nationality</summary>
        public string Nationality { get; set; }
        /// <summary>Remarks</summary>
        public string Notes { get; set; }
        /// <summary>Phone number</summary>
        public string Phone { get; set; }
        /// <summary>Phone number extension</summary>
        public string PhoneExtension { get; set; }
        /// <summary>Profile code</summary>
        public string ProfileCode { get; set; }
        /// <summary>Startdate after which the login is allowed. If the start date is NULL the login is allowed as well</summary>
        public DateTime? StartDate { get; set; }
        /// <summary>Start Division</summary>
        public int StartDivision { get; set; }
        /// <summary>Title</summary>
        public string Title { get; set; }
        /// <summary>Primary key</summary>
        [ExactOnlinePrimaryKey]
        public Guid UserID { get; set; }
        /// <summary>Login name of the user</summary>
        public string UserName { get; set; }
    }
}