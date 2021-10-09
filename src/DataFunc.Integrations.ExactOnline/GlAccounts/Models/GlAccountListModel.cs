using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.GlAccounts.Models
{
    [ExactOnlineResource("api/v1/{0}/bulk/Financial/GLAccounts")]
    public class GlAccountListModel
    {
        /// <summary>Unique Code of the G/L account</summary>
        public string Code { get; set; }
        /// <summary>Name of the G/L account</summary>
        public string Description { get; set; }
        /// <summary>Primary Key</summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 	Indicate if this G/L account should be shown as compressed without the details in the CRW report of G/L history
        /// </summary>
        public bool Compress { get; set; }
        public double? VATNonDeductiblePercentage { get; set; }
        public double? ExpenseNonDeductiblePercentage { get; set; }
        // The following values are supported: D (Debit) C (Credit)
        public string BalanceSide { get; set; }
        public int Division { get; set; }
    }
}