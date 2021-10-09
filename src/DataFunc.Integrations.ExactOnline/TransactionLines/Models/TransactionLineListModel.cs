using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.TransactionLines.Models
{
    [ExactOnlineResource("/api/v1/{0}/bulk/Financial/TransactionLines")]
    public class FinancialTransactionLineListModel
    {
        /// <summary>Reference to account</summary>
        public Guid? Account { get; set; }
        /// <summary>Code of the Account</summary>
        public string AccountCode { get; set; }
        /// <summary>Name of the Account</summary>
        public string AccountName { get; set; }
        /// <summary>Amount in the default currency of the company</summary>
        public double AmountDC { get; set; }
        /// <summary>Reference to asset</summary>
        public Guid? Asset { get; set; }
        /// <summary>Date</summary>
        public DateTime? Date { get; set; }
        /// <summary>Description</summary>
        public string Description { get; set; }
        /// <summary>Division code</summary>
        public int Division { get; set; }
        /// <summary>Entry number of the header</summary>
        public int? EntryNumber { get; set; }
        /// <summary>Financial period</summary>
        public short? FinancialPeriod { get; set; }
        /// <summary>Financial year</summary>
        public short? FinancialYear { get; set; }
        /// <summary>General ledger account</summary>
        public Guid? GLAccount { get; set; }
        /// <summary>Code of GLAccount</summary>
        public string GLAccountCode { get; set; }
        [ExactOnlinePrimaryKey]
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Invoice number</summary>
        public int? InvoiceNumber { get; set; }
        /// <summary>Reference to item</summary>
        public Guid? Item { get; set; }
        /// <summary>The journal code</summary>
        public string JournalCode { get; set; }
        /// <summary>Line number</summary>
        public int? LineNumber { get; set; }
        /// <summary>Line type</summary>
        public short LineType { get; set; }
        /// <summary>OffsetID</summary>
        public Guid? OffsetID { get; set; }
        /// <summary>Order number</summary>
        public int? OrderNumber { get; set; }
        /// <summary>Quantity</summary>
        public double? Quantity { get; set; }
        /// <summary>20 = Open, 50 = Processed</summary>
        public short? Status { get; set; }
        public int Type { get; set; }
        /// <summary>Your reference (of customer)</summary>
        public string YourRef { get; set; }
    }
}