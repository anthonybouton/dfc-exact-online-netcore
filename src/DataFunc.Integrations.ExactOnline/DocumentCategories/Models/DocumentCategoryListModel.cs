using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.DocumentCategories.Models
{
    [ExactOnlineResource("api/v1/{0}/documents/DocumentCategories")]
    public class DocumentCategoryListModel
    {
        public string Description { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
    }
}