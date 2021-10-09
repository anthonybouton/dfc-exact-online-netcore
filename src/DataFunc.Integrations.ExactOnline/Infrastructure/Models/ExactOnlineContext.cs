namespace DataFunc.Integrations.ExactOnline.Infrastructure.Models
{
    public class ExactOnlineContext
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ExactOnlineUrl { get; set; }
        public string RedirectUri { get; set; }
        public string CustomDescriptionLanguage { get; set; }
    }
}