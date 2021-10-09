using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.DocumentCategories.Models
{
    [ExactOnlineResource("api/v1/{0}/documents/DocumentCategories")]
    public class DocumentCategoryDetailModel
    {
        /// <summary>Creation date</summary>
        public DateTime? Created { get; set; }
        public string Description { get; set; }
        [ExactOnlinePrimaryKey]
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Last modified date</summary>
        public DateTime? Modified { get; set; }
    }
}