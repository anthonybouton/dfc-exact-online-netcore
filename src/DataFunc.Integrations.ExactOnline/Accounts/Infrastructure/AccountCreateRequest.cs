namespace DataFunc.Integrations.ExactOnline.Accounts.Infrastructure
{
    public class AccountCreateRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string SearchCode { get; set; }
        public string Language { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
}