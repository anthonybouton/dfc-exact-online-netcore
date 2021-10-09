using System;
using System.Collections.Generic;
using DataFunc.Integrations.ExactOnline.SalesEntryLines.Infrastructure;

namespace DataFunc.Integrations.ExactOnline.SalesEntries.Infrastructure
{
    public class SalesEntryCreateRequest
    {
        public SalesEntryCreateRequest()
        {
            SalesEntryLines = new List<SalesEntryLineCreateRequest>();
        }
        public Guid Customer { get; set; }
        public string Journal { get; set; }
        public Guid? Document { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string PaymentCondition { get; set; }
        public int? ReportingYear { get; set; }
        public int? ReportingPeriod { get; set; }
        public int? EntryNumber { get; set; }
        public string PaymentReference { get; set; }
        public int Type { get; set; }
        public string YourRef { get; set; }
        public List<SalesEntryLineCreateRequest> SalesEntryLines { get; set; }
    }
}
