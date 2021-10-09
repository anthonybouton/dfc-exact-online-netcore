using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.Payables.Models
{
    [ExactOnlineResource("api/v1/{0}/read/financial/PayablesList")]
    public class PayableListModel
    {
        /// <summary>Reference to the account</summary>
        public Guid AccountId { get; set; }
        /// <summary>Amount</summary>
        public double Amount { get; set; }
        [ExactOnlinePrimaryKey]
        /// <summary>Primary key, human readable ID</summary>
        public long HID { get; set; }
        /// <summary>Invoice date</summary>
        public DateTime InvoiceDate { get; set; }
        /// <summary>Invoice number. The value is 0 when the invoice number of the linked transaction is empty.</summary>
        public int InvoiceNumber { get; set; }
    }
}