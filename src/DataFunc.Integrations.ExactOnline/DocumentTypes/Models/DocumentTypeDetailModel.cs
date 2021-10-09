using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.DocumentTypes.Models
{
    [ExactOnlineResource("api/v1/{0}/documents/DocumentTypes")]
    public class DocumentTypeDetailModel
    {
        /// <summary>Creation date</summary>
        public DateTime? Created { get; set; }
        /// <summary>Document type description</summary>
        public string Description { get; set; }
        /// <summary>Indicates if documents of this type can be created</summary>
        public bool DocumentIsCreatable { get; set; }
        /// <summary>Indicates if documents of this type can be deleted</summary>
        public bool DocumentIsDeletable { get; set; }
        /// <summary>Indicates if documents of this type can be updated</summary>
        public bool DocumentIsUpdatable { get; set; }
        /// <summary>Indicates if documents of this type can be retrieved</summary>
        public bool DocumentIsViewable { get; set; }
        [ExactOnlinePrimaryKey]
        /// <summary>Primary key</summary>
        public Int32 ID { get; set; }
        /// <summary>Last modified date</summary>
        public DateTime? Modified { get; set; }
        /// <summary>ID of the document type category</summary>
        public Int32? TypeCategory { get; set; }
    }
}