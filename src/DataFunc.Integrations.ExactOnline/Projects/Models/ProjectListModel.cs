using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.Projects.Models
{
    [ExactOnlineResource("api/v1/{0}/project/Projects")]
    public class ProjectListModel
    {
        /// <summary>The account for this project</summary>
        public Guid? Account { get; set; }
        /// <summary>Code of Account</summary>
        public string AccountCode { get; set; }
        /// <summary>Contact person of Account</summary>
        public string AccountName { get; set; }
        /// <summary>Code</summary>
        public string Code { get; set; }
        /// <summary>Description of the project</summary>
        public string Description { get; set; }
        /// <summary>Division code</summary>
        public int? Division { get; set; }
        /// <summary>Name of Division</summary>
        public string DivisionName { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>End date of the project. In combination with the start date the status is determined</summary>
        public DateTime? EndDate { get; set; }
        /// <summary>Start date of a project. In combination with the end date the status is determined</summary>
        public DateTime? StartDate { get; set; }
    }
}