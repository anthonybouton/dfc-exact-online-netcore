using Newtonsoft.Json;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Models
{
    public class ExactOnlineError
    {
        public string Code { get; set; }
        public ExactOnlineErrorMessage Message { get; set; }
    }

    public class ExactOnlineErrorMessage
    {
        [JsonProperty("lang")]
        public string Language { get; set; }

        public string Value { get; set; }
    }
}