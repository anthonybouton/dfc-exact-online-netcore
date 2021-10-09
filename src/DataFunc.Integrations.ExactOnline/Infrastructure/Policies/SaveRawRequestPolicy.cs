using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using DataFunc.Integrations.ExactOnline.Infrastructure.Interfaces;
using DataFunc.Integrations.ExactOnline.Infrastructure.Models;
using DataFunc.Integrations.ExactOnline.OAuth2.Infrastructure;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Policies
{
    public class SaveRawRequestPolicy
    {
        public static AsyncPolicy<HttpResponseMessage> Create()
        {
            return Policy
                     .HandleResult<HttpResponseMessage>(x => x.IsSuccessStatusCode)
                     .RetryAsync(1, async (result, retryCount, context) =>
                     {
                         var rawResponse = await result.Result.Content.ReadAsStringAsync();
                         await File.WriteAllTextAsync($"response.json", rawResponse);
                     });
        }
    }
}