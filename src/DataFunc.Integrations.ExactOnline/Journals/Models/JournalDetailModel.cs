using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.Journals.Models
{
    [ExactOnlineResource("api/v1/{0}/financial/Journals")]
    public class JournalDetailModel
    {
        /// <summary>Indicates if the journal allows the use of VAT in the financial entry. Especially true for general journals</summary>
        public bool? AllowVAT { get; set; }
        /// <summary>Primary key</summary>
        public string Code { get; set; }
        /// <summary>Default Currency of the Journal. If AllowVariableCurrency is false this is the only currency that can be used</summary>
        public string Currency { get; set; }
        /// <summary>Description of Currency</summary>
        public string CurrencyDescription { get; set; }
        /// <summary>Name of the Journal</summary>
        public string Description { get; set; }
        /// <summary>Division code</summary>
        public int? Division { get; set; }
        /// <summary>Suspense general ledger account</summary>
        public Guid? GLAccount { get; set; }
        /// <summary>Code of GLAccount</summary>
        public string GLAccountCode { get; set; }
        /// <summary>Description of GLAccount</summary>
        public string GLAccountDescription { get; set; }
        /// <summary>Type of GLAccount</summary>
        public int? GLAccountType { get; set; }
        [ExactOnlinePrimaryKey]
        /// <summary>Primary Key</summary>
        public Guid ID { get; set; }
        /// <summary>Type of Journal. The following values are supported: 10 (Cash) 12 (Bank) 16 (Payment service) 20 (Sales) 21 (Return invoice) 22 (Purchase) 23 (Received return invoice) 90 (General journal)</summary>
        public int? Type { get; set; }
    }
}