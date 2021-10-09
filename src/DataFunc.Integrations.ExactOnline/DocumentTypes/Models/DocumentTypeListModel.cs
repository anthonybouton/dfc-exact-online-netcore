using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.DocumentTypes.Models
{
    [ExactOnlineResource("api/v1/{0}/documents/DocumentTypes")]
    public class DocumentTypeListModel
    {
        /// <summary>Document type description</summary>
        public string Description { get; set; }
        /// <summary>Primary key</summary>
        public int ID { get; set; }
        /// <summary>ID of the document type category</summary>
        public int? TypeCategory { get; set; }
    }
}