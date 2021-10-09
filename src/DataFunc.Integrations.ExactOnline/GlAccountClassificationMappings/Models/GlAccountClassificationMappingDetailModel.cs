using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.GlAccountClassificationMappings.Models
{
    [ExactOnlineResource("api/v1/{0}/financial/GLAccountClassificationMappings")]
    public class GlAccountClassificationMappingDetailModel 
    {
        [ExactOnlinePrimaryKey]
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }

        public Guid Classification { get; set; }
        public string ClassificationCode { get; set; }
        public string ClassificationDescription { get; set; }
        public int Division { get; set; }
        public Guid GLAccount { get; set; }
        public string GLAccountCode { get; set; }
        public string GLAccountDescription { get; set; }
        public string GLSchemeCode { get; set; }
        public string GLSchemeDescription { get; set; }
        public Guid GLSchemeID { get; set; }
    }
}