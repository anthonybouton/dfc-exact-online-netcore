using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.GlAccountSchemas.Models
{
    [ExactOnlineResource("api/v1/{0}/financial/GLSchemes")]
    public class GlAccountSchemaListModel 
    {
        public string Code { get; set; }
        /// <summary>Description text</summary>
        public string Description { get; set; }
        /// <summary>Division is optional for this table. For taxonomies of Taxonomies.Type = 0 (general taxonomies), the Division is empty. For division specific taxonomies it is mandatory</summary>
        public int? Division { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
    }
}