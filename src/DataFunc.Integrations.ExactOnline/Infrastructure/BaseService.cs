using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using DataFunc.Integrations.ExactOnline.Infrastructure.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataFunc.Integrations.ExactOnline.Infrastructure
{
    public abstract class BaseService
    {
        private readonly HttpClient _client;
        protected BaseService(HttpClient client)
        {
            _client = client;
        }

        protected async Task<(IEnumerable<T>, ResponseHeaders)> GetList<T>(string url, CancellationToken token)
        {
            ResponseHeaders headers;
            var result = new List<T>();
            var pagingUrl = url;
            do
            {
                var response = await _client.SendAsync(new HttpRequestMessage(HttpMethod.Get, pagingUrl), token);

                headers = response.ParseHeaders();

                var jsonContents = await response.ParseResponse();

                result.AddRange(TryParse(jsonContents, Enumerable.Empty<T>(), "d", "results"));

                var newPagingUrl = TryParse<string>(jsonContents, null, "d", "__next");
                if (!string.IsNullOrWhiteSpace(newPagingUrl) && newPagingUrl != pagingUrl)
                    pagingUrl = newPagingUrl;
                else
                    pagingUrl = null;

            } while (!string.IsNullOrWhiteSpace(pagingUrl));

            return (result, headers);
        }

        protected async Task<(T, ResponseHeaders)> Create<T>(string url, object body, CancellationToken token)
        {
            var response = await _client.SendAsync(new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
            }, token);

            var headers = response.ParseHeaders();

            var jsonContents = await response.ParseResponse();

            var result = TryParse<T>(jsonContents, default, "d");

            return (result, headers);
        }

        protected async Task<ResponseHeaders> Update(string url, object body, CancellationToken token)
        {
            var response = await _client.SendAsync(new HttpRequestMessage(HttpMethod.Put, url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
            }, token);

            return response.ParseHeaders();
        }
        protected async Task<ResponseHeaders> Delete(string url,CancellationToken token)
        {
            var response = await _client.SendAsync(new HttpRequestMessage(HttpMethod.Delete, url), token);
            return response.ParseHeaders();
        }



        private TY TryParse<TY>(JToken contents, TY defaultValue, params string[] nodes)
        {
            if (!contents.HasValues)
                return defaultValue;

            var toVisitToken = contents;

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