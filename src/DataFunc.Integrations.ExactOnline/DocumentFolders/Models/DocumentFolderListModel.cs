using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.DocumentFolders.Models
{
    [ExactOnlineResource("api/v1/{0}/documents/DocumentFolders")]
    public class DocumentFolderListModel
    {
        /// <summary>Document folder code</summary>
        public string Code { get; set; }
        /// <summary>Document folder description</summary>
        public string Description { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Document folder parent folder ID</summary>
        public Guid? ParentFolder { get; set; }
    }
}