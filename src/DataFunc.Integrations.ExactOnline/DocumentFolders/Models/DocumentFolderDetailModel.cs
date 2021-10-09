using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.DocumentFolders.Models
{
    [ExactOnlineResource("api/v1/{0}/documents/DocumentFolders")]
    public class DocumentFolderDetailModel
    {
        /// <summary>Document folder code</summary>
        public string Code { get; set; }
        /// <summary>Creation date</summary>
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        public string CreatorFullName { get; set; }
        /// <summary>Document folder description</summary>
        public string Description { get; set; }
        /// <summary>Division code</summary>
        public int Division { get; set; }
        [ExactOnlinePrimaryKey]
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Last modified date</summary>
        public DateTime? Modified { get; set; }
        /// <summary>User ID of modifier</summary>
        public Guid? Modifier { get; set; }
        /// <summary>Name of modifier</summary>
        public string ModifierFullName { get; set; }
        /// <summary>Document folder parent folder ID</summary>
        public Guid? ParentFolder { get; set; }
    }
}