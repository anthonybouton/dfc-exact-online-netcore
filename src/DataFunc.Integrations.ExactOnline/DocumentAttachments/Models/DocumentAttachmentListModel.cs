using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.DocumentAttachments.Models
{
    [ExactOnlineResource("api/v1/{0}/documents/DocumentAttachments")]
    public class DocumentAttachmentListModel
    {
        /// <summary>Filename of the attachment</summary>
        public string FileName { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Url of the attachment. To get the file in its original format (xml, jpg, pdf, etc.) append &lt;b&gt;&amp;Download=1&lt;/b&gt; to the url.</summary>
        public string Url { get; set; }
    }
}