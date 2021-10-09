using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.Employees.Models
{
    [ExactOnlineResource("api/v1/{0}/payroll/Employees")]
    public class EmployeeListModel
    {
       /// <summary>Code of the employee</summary>
        public string Code { get; set; }
        /// <summary>Email address</summary>
        public string Email { get; set; }
        /// <summary>Full name of the employee</summary>
        public string FullName { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>IsActive</summary>
        public bool IsActive { get; set; }
    }
}