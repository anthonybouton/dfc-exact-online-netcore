using System;
using System.Reflection;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.AccountOwners.Models
{
    [ExactOnlineResource("api/v1/{0}/accountancy/AccountOwners")]
    public class AccountOwnerListModel
    {
        public int Division { get; set; }
        /// <summary>ID of the account that is owned</summary>
        public Guid? Account { get; set; }
        /// <summary>Code of the account that is owned</summary>
        public string AccountCode { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>ID of the account who owns specified account</summary>
        public Guid? OwnerAccount { get; set; }
        /// <summary>Code of the account who owns specified account</summary>
        public string OwnerAccountCode { get; set; }
        /// <summary>Percentage of shares that is owned. 1 is 100%, 0.5 is 50%</summary>
        public double? Shares { get; set; }
    }
}