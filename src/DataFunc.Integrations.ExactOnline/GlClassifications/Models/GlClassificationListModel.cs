using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.GlClassifications.Models
{
    [ExactOnlineResource("api/v1/{0}/financial/GLClassifications")]
    public class GlClassificationListModel
    {
        /// <summary>The Code is unique</summary>
        public string Code { get; set; }
        /// <summary>Description of the element. Note that this description is only used for division-specific taxonomies (or reporting schemes). For general taxonomies, the descriptions are stored in the TaxonomyLabels table</summary>
        public string Description { get; set; }
        /// <summary>Division is optional. For taxonomies of Taxonomies.Type = 0 (general taxonomies), the Division is empty. For division specific taxonomies it is mandatory</summary>
        public int? Division { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>The Name is unique in the namespace</summary>
        public string Name { get; set; }
        /// <summary>Parent element for reporting schemes. In a reporting scheme, an element can have only one parent. This column is only used for reporting schemes. Note that in a real taxonomy, elements can have multiple parents.</summary>
        public Guid? Parent { get; set; }
        /// <summary>Namespace of the element</summary>
        public Guid? TaxonomyNamespace { get; set; }
    }
}