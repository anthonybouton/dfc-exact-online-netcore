using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataFunc.Integrations.ExactOnline.Tests
{
    public class FakeHttpClientHandler : HttpClientHandler
    {
        private readonly HttpStatusCode _expectedStatusCode;
        private readonly string _expectedContents;
        private readonly Dictionary<string, string> _headers;

        public FakeHttpClientHandler(HttpStatusCode expectedStatusCode, string expectedContents, Dictionary<string, string> headers)
        {
            _expectedStatusCode = expectedStatusCode;
            _expectedContents = expectedContents;
            _headers = headers;
        }


        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(_expectedStatusCode);

            if (!string.IsNullOrWhiteSpace(_expectedContents))
                response.Content = new StringContent(_expectedContents, Encoding.UTF8, "application/json");
            
            foreach (var (key, value) in _headers ?? new Dictionary<string, string>())
            {
                response.Headers.Add(key, value);
            }

            return Task.FromResult(response);
        }
    }
}