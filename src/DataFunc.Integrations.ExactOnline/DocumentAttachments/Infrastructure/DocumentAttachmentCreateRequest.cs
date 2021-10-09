using System;

namespace DataFunc.Integrations.ExactOnline.DocumentAttachments.Infrastructure
{
    public class DocumentAttachmentCreateRequest
    {
        public Guid Document { get; set; }
        public string FileName { get; set; }
        public byte[] Attachment { get; set; }
    }
}