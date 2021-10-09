using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.Accounts.Models
{
    [ExactOnlineResource("api/v1/{0}/bulk/crm/Accounts")]
    public class AccountListModel
    {
        public string Code { get; set; }
        /// <summary>E-Mail address of the account</summary>
        public string Email { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Account name</summary>
        public string Name { get; set; }
        public string VATNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string City{ get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public int Division { get; set; }
        public Guid? ActivitySector { get; set; }
        public string Status { get; set; }
        public bool? IsSupplier { get; set; }
    }
}