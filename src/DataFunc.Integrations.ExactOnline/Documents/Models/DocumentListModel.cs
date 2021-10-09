using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.Documents.Models
{
    [ExactOnlineResource("api/v1/{0}/bulk/Documents/Documents")]
    public class DocumentListModel
    {
        /// <summary>ID of the related account of this document</summary>
        public Guid? Account { get; set; }
        /// <summary>ID of the related contact of this document</summary>
        public Guid? Contact { get; set; }
        /// <summary>Entry date of the incoming document</summary>
        public DateTime? DocumentDate { get; set; }
        /// <summary>Url to view the document</summary>
        public string DocumentViewUrl { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Subject of this document</summary>
        public string Subject { get; set; }
        /// <summary>The document type</summary>
        public int Type { get; set; }
    }
}