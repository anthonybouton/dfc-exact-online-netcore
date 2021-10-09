using System;

namespace DataFunc.Integrations.ExactOnline.SalesEntryLines.Infrastructure
{
    public class SalesEntryLineCreateRequest
    {
        public decimal AmountFC { get; set; }
        public string Description { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public Guid GLAccount { get; set; }
        public decimal? Quantity { get; set; }
        public string VATCode { get; set; }
    }
}