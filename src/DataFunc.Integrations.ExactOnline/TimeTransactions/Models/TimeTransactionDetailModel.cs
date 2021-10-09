﻿using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.TimeTransactions.Models
{
    [ExactOnlineResource("/api/v1/{0}/project/TimeTransactions")]
    public class TimeTransactionsDetailModel
    {
        /// <summary>Account linked to the transaction</summary>
        public Guid? Account { get; set; }
        /// <summary>Name of Account</summary>
        public string AccountName { get; set; }
        /// <summary>Reference to ProjectWBS (work breakdown structure)</summary>
        public Guid? Activity { get; set; }
        /// <summary>Description of ProjectWBS</summary>
        public string ActivityDescription { get; set; }
        /// <summary>This property is obsolete. Use property &apos;AmountFC&apos; instead.</summary>
        public double? Amount { get; set; }
        /// <summary>Amount in the currency of the transaction of the transaction</summary>
        public double? AmountFC { get; set; }
        /// <summary>Date</summary>
        public DateTime? Date { get; set; }
        /// <summary>Division code</summary>
        public int? Division { get; set; }
        /// <summary>Description of Division</summary>
        public string DivisionDescription { get; set; }
        /// <summary>Employee linked to the transaction</summary>
        public Guid? Employee { get; set; }
        /// <summary>End time of the transaction</summary>
        public DateTime? EndTime { get; set; }
        /// <summary>Entrynumber</summary>
        public int? EntryNumber { get; set; }
        /// <summary>Errortext, used for the backgroundjobs</summary>
        public string ErrorText { get; set; }
        /// <summary>Status of the transaction</summary>
        public short? HourStatus { get; set; }
        [ExactOnlinePrimaryKey]
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Item linked to the transaction. Items of type &apos;time&apos; are linked to time transactions. Items of other types are linked to cost transactions</summary>
        public Guid? Item { get; set; }
        /// <summary>Description of Item</summary>
        public string ItemDescription { get; set; }
        /// <summary>True if you can use decimals for item quantity</summary>
        public bool? ItemDivisable { get; set; }
        /// <summary>Notes linked to the transaction</summary>
        public string Notes { get; set; }
        /// <summary>This property is obsolete. Use property &apos;PriceFC&apos; instead.</summary>
        public double? Price { get; set; }
        /// <summary>PriceFC (AmountFC = Quantity * PriceFC)</summary>
        public double? PriceFC { get; set; }
        /// <summary>Project linked to the transaction</summary>
        public Guid? Project { get; set; }
        /// <summary>Reference to project account</summary>
        public Guid? ProjectAccount { get; set; }
        /// <summary>Project account code</summary>
        public string ProjectAccountCode { get; set; }
        /// <summary>Project account name</summary>
        public string ProjectAccountName { get; set; }
        /// <summary>Code of Project</summary>
        public string ProjectCode { get; set; }
        /// <summary>Description of Project</summary>
        public string ProjectDescription { get; set; }
        /// <summary>Quantity of the transaction</summary>
        public double? Quantity { get; set; }
        /// <summary>Skip validation</summary>
        public bool SkipValidation { get; set; }
        /// <summary>Start time of the transaction</summary>
        public DateTime? StartTime { get; set; }
        /// <summary>Subscription linked to the transaction</summary>
        public Guid? Subscription { get; set; }
        /// <summary>Account linked to the subscription</summary>
        public Guid? SubscriptionAccount { get; set; }
        /// <summary>Subscription account code</summary>
        public string SubscriptionAccountCode { get; set; }
        /// <summary>Subscription account name</summary>
        public string SubscriptionAccountName { get; set; }
        /// <summary>Description of the subscription</summary>
        public string SubscriptionDescription { get; set; }
        /// <summary>Subscription number</summary>
        public int? SubscriptionNumber { get; set; }
        /// <summary>Type of the transaction</summary>
        public short? Type { get; set; }
    }
}