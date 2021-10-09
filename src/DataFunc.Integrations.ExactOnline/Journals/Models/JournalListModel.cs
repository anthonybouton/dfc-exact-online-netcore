using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.Journals.Models
{
    [ExactOnlineResource("api/v1/{0}/financial/Journals")]
    public class JournalListModel
    {
        /// <summary>Primary key</summary>
        public string Code { get; set; }
        /// <summary>Name of the Journal</summary>
        public string Description { get; set; }
        /// <summary>Primary Key</summary>
        public Guid ID { get; set; }
    }
}