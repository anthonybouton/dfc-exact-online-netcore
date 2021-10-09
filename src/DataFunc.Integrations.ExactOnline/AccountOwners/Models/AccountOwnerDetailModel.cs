using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.AccountOwners.Models
{
    [ExactOnlineResource("api/v1/{0}/accountancy/AccountOwners")]
    public class AccountOwnerDetailModel
    {
        /// <summary>ID of the account that is owned</summary>
        public Guid? Account { get; set; }
        /// <summary>Code of the account that is owned</summary>
        public string AccountCode { get; set; }
        /// <summary>Name of the account that is owned</summary>
        public string AccountName { get; set; }
        /// <summary>Creation date</summary>
        public DateTime? Created { get; set; }
        /// <summary>User ID of the creator</summary>
        public Guid? Creator { get; set; }
        /// <summary>Name of the creator</summary>
        public string CreatorFullName { get; set; }
        /// <summary>Division code</summary>
        public Int32? Division { get; set; }
        [ExactOnlinePrimaryKey]
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Last modified date</summary>
        public DateTime? Modified { get; set; }
        /// <summary>User ID of the modifier</summary>
        public Guid? Modifier { get; set; }
        /// <summary>Name of the modifier</summary>
        public string ModifierFullName { get; set; }
        /// <summary>ID of the account who owns specified account</summary>
        public Guid? OwnerAccount { get; set; }
        /// <summary>Code of the account who owns specified account</summary>
        public string OwnerAccountCode { get; set; }
        /// <summary>Name of the account who owns specified account</summary>
        public string OwnerAccountName { get; set; }
        /// <summary>Percentage of shares that is owned. 1 is 100%, 0.5 is 50%</summary>
        public double? Shares { get; set; }
    }
}