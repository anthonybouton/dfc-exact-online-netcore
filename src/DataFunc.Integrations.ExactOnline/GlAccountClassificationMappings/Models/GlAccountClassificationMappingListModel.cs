using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.GlAccountClassificationMappings.Models
{
    [ExactOnlineResource("api/v1/{0}/financial/GLAccountClassificationMappings")]
    public class GlAccountClassificationMappingListModel
    {
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        public Guid Classification { get; set; }
        public int Division { get; set; }
        public Guid GLAccount { get; set; }
        public Guid GLSchemeID { get; set; }
    }
}