using System;
using System.Net;
using System.Web;
using Newtonsoft.Json.Linq;

namespace DataFunc.Integrations.ExactOnline.Infrastructure
{
    public class BaseResponse
    {
        public ResponseHeaders Headers { get; set; }
    }

    public class ResponseHeaders
    {
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public int RequestLimit { get; set; }
        public int RequestRemainingLimit { get; set; }
        public DateTimeOffset RequestLimitResetAt { get; set; }
        public int RequestMinuteLimit { get; set; }
        public int RequestMinuteRemainingLimit { get; set; }
        public DateTimeOffset RequestMinuteLimitResetAt { get; set; }
        public string DataServiceVersion { get; set; }
    }

    public  class BaseResponse<T> : BaseResponse
    {

        public string SkipToken { get; set; }
        public T Results { get; set; }

        internal virtual T Parse(JObject contents)
        {
            throw new Exception();
        }

        internal string ParseSkipToken(JObject contents)
        {
            var url = TryParse<string>(contents, null, "d", "__next");
            if (string.IsNullOrWhiteSpace(url))
                return null;

            var queryParameters = HttpUtility.ParseQueryString(url);
            if (queryParameters.HasKeys() && queryParameters["$skipToken"] != null)
                return queryParameters["$skipToken"];

            return null;
        }

        protected TY TryParse<TY>(JObject contents, TY defaultValue, params string[] nodes)
        {
            if (!contents.HasValues)
                return defaultValue;

            JToken toVisitToken = contents;

            foreach (var node in nodes)
            {
                toVisitToken = toVisitToken.SelectToken($"$.{node}");
                if (toVisitToken == null)
                    return defaultValue;
            }

            return toVisitToken == null ? defaultValue : toVisitToken.ToObject<TY>();
        }
    }
}