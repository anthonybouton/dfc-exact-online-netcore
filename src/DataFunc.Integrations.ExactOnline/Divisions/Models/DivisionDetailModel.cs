using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.Divisions.Models
{
    [ExactOnlineResource("/api/v1/{0}/system/Divisions")]
    public class DivisionDetailModel
    {
        [ExactOnlinePrimaryKey]
        public int Code { get; set; }
        public string BusinessTypeCode { get; set; }
        public string BusinessTypeDescription { get; set; }
        public string Website { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string VATNumber { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Postcode { get; set; }
        public int Status { get; set; }
        public long Hid { get; set; }

    }
}