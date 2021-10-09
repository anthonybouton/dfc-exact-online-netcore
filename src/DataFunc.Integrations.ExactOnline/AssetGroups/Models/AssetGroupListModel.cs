using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.AssetGroups.Models
{
    [ExactOnlineResource("api/v1/{0}/assets/AssetGroups")]
    public class AssetGroupListModel
    {
        /// <summary>Code of the asset group</summary>
        public string Code { get; set; }
        /// <summary>Description of the asset group</summary>
        public string Description { get; set; }
        /// <summary>Division code</summary>
        public int? Division { get; set; }
        /// <summary>GLAccount for the assets</summary>
        public Guid? GLAccountAssets { get; set; }
        /// <summary>GLAccount for depreciation (Balance sheet)</summary>
        public Guid? GLAccountDepreciationBS { get; set; }
        /// <summary>GLAccount for depreciation (Profit &amp; Loss)</summary>
        public Guid? GLAccountDepreciationPL { get; set; }
        /// <summary>GLAccount for revaluation (Balance sheet)</summary>
        public Guid? GLAccountRevaluationBS { get; set; }
        [ExactOnlinePrimaryKey]
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
    }
}