using System;

namespace DataFunc.Integrations.ExactOnline.Documents.Infrastructure
{
    public class DocumentCreateRequest
    {
        public Guid? Account { get; set; }
        public Guid? Category { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string Language { get; set; }
        public string Subject { get; set; }
        public int Type { get; set; }
        public Guid? DocumentFolder { get; set; }
    }
}