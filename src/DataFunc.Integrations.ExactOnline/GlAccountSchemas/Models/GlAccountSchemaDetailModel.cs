using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.GlAccountSchemas.Models
{
    [ExactOnlineResource("api/v1/{0}/financial/GLSchemes")]
    public class GlAccountSchemaDetailModel
    {
        public string Code { get; set; }
        /// <summary>Creation date</summary>
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        public string CreatorFullName { get; set; }
        /// <summary>Description text</summary>
        public string Description { get; set; }
        /// <summary>Division is optional for this table. For taxonomies of Taxonomies.Type = 0 (general taxonomies), the Division is empty. For division specific taxonomies it is mandatory</summary>
        public int? Division { get; set; }
        [ExactOnlinePrimaryKey]
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Only used for reporting schemes = division specific taxonomynamespaces. In this case, main = 1 denotes the main or default reporting scheme</summary>
        public byte Main { get; set; }
        /// <summary>Last modified date</summary>
        public DateTime? Modified { get; set; }
        /// <summary>User ID of modifier</summary>
        public Guid? Modifier { get; set; }
        /// <summary>Name of modifier</summary>
        public string ModifierFullName { get; set; }
        /// <summary>URI, which is the unique identifier of the namespace</summary>
        public string TargetNamespace { get; set; }
    }
}