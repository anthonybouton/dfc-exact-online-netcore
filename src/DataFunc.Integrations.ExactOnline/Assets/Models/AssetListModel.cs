using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.Assets.Models
{
    [ExactOnlineResource("/api/v1/{0}/assets/Assets")]
    public class AssetListModel
    {
        /// <summary>In case of a transfer or a split, the original asset ID is saved in this field. This is done to provide tracability of the Asset</summary>
        public Guid? AssetFrom { get; set; }
        /// <summary>Asset group identifies GLAccounts to be used for Asset transactions</summary>
        public Guid? AssetGroup { get; set; }
        public string Code { get; set; }
        /// <summary>This is the description of the Asset</summary>
        public string Description { get; set; }
        /// <summary>Division code</summary>
        public int? Division { get; set; }
        /// <summary>Asset EndDate is filled when asset is Sold or Inactive</summary>
        public DateTime? EndDate { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Investment amount in the default currency of the company</summary>
        public double? InvestmentAmountDC { get; set; }
        /// <summary>Refers to the original date when the asset was bought</summary>
        public DateTime? InvestmentDate { get; set; }
        /// <summary>First method of depreciation. Currently, it is the only one used</summary>
        public Guid? PrimaryMethod { get; set; }
        /// <summary>Asset Depreciation StartDate</summary>
        public DateTime? StartDate { get; set; }
        /// <summary>Identifies the status of the Asset. (see AssetStatus table to see the possibilities)</summary>
        public short? Status { get; set; }
        /// <summary>Entry number of transaction</summary>
        public int? TransactionEntryNo { get; set; }

        public decimal? DeductionPercentage { get; set; }
    }
}