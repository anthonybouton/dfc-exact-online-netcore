using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.SalesEntries.Models
{
    [ExactOnlineResource("/api/v1/{0}/salesentry/SalesEntries")]
    public class SalesEntryListModel
    {
        public Guid? Customer { get; set; }
        public string Description { get; set; }
        /// <summary>The due date for payments. This date is calculated based on the EntryDate and the Paymentcondition</summary>
        public DateTime? DueDate { get; set; }
        /// <summary>The date when the invoice is entered</summary>
        public DateTime? EntryDate { get; set; }
        /// <summary>The unique ID of the entry. Via this ID all transaction lines of a single entry can be retrieved</summary>
        public Guid EntryID { get; set; }
        /// <summary>Entry number</summary>
        public int? EntryNumber { get; set; }
        /// <summary>Assigned at entry or at printing depending on setting. The number assigned is based on the freenumbers as defined for the Journal. When printing the field InvoiceNumber is copied to the fields EntryNumber and InvoiceNumber of the sales entry</summary>
        public int? InvoiceNumber { get; set; }
        /// <summary>The journal code. Every invoice should be linked to a sales journal</summary>
        public string Journal { get; set; }
        /// <summary>The payment condition used for due date and discount calculation</summary>
        public string PaymentCondition { get; set; }
        /// <summary>The payment reference used for bank imports, VAT return and Tax reference</summary>
        public string PaymentReference { get; set; }
        /// <summary>Type: 20 = Sales entry, 21 = Sales credit note</summary>
        public int Type { get; set; }
        /// <summary>The invoice number of the customer</summary>
        public string YourRef { get; set; }
    }
}