using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Policies
{
    public class TooManyRequestsPolicy
    {
        public static AsyncRetryPolicy<HttpResponseMessage> Create()
        {
            return Policy
                .HandleResult<HttpResponseMessage>(x => x.StatusCode == HttpStatusCode.TooManyRequests)
                .WaitAndRetryAsync(3, retryCount => TimeSpan.FromSeconds(5 * Math.Pow(2, retryCount)));
        }
    }
}