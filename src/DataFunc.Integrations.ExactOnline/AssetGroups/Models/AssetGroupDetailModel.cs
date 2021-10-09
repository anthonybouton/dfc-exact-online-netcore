using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.AssetGroups.Models
{
    [ExactOnlineResource("api/v1/{0}/assets/AssetGroups")]
    public class AssetGroupDetailModel
    {
        /// <summary>Code of the asset group</summary>
        public string Code { get; set; }
        /// <summary>Creation date</summary>
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        public string CreatorFullName { get; set; }
        /// <summary>Default depreciation method of the assets in this asset group</summary>
        public Guid? DepreciationMethod { get; set; }
        /// <summary>Code of the depreciation method</summary>
        public string DepreciationMethodCode { get; set; }
        /// <summary>Description of the depreciation method</summary>
        public string DepreciationMethodDescription { get; set; }
        /// <summary>Description of the asset group</summary>
        public string Description { get; set; }
        /// <summary>Division code</summary>
        public Int32? Division { get; set; }
        /// <summary>GLAccount for the assets</summary>
        public Guid? GLAccountAssets { get; set; }
        /// <summary>Code of the GLAccount for the assets</summary>
        public string GLAccountAssetsCode { get; set; }
        /// <summary>Description of the GLAccount for the assets</summary>
        public string GLAccountAssetsDescription { get; set; }
        /// <summary>GLAccount for depreciation (Balance sheet)</summary>
        public Guid? GLAccountDepreciationBS { get; set; }
        /// <summary>Code of the GLAccount for depreciation (Balance sheet)</summary>
        public string GLAccountDepreciationBSCode { get; set; }
        /// <summary>Description of the GLAccount for depreciation (Balance sheet)</summary>
        public string GLAccountDepreciationBSDescription { get; set; }
        /// <summary>GLAccount for depreciation (Profit &amp; Loss)</summary>
        public Guid? GLAccountDepreciationPL { get; set; }
        /// <summary>Code of the GLAccount for depreciation (Profit &amp; Loss)</summary>
        public string GLAccountDepreciationPLCode { get; set; }
        /// <summary>Description of the GLAccount for depreciation (Profit &amp; Loss)</summary>
        public string GLAccountDepreciationPLDescription { get; set; }
        /// <summary>GLAccount for revaluation (Balance sheet)</summary>
        public Guid? GLAccountRevaluationBS { get; set; }
        /// <summary>Code of the GLAccount for revaluation (Balance sheet)</summary>
        public string GLAccountRevaluationBSCode { get; set; }
        /// <summary>Description of the GLAccount for revaluation (Balance sheet)</summary>
        public string GLAccountRevaluationBSDescription { get; set; }
        [ExactOnlinePrimaryKey]
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Last modified date</summary>
        public DateTime? Modified { get; set; }
        /// <summary>User ID of modifier</summary>
        public Guid? Modifier { get; set; }
        /// <summary>Name of modifier</summary>
        public string ModifierFullName { get; set; }
        /// <summary>Notes</summary>
        public string Notes { get; set; }
    }
}