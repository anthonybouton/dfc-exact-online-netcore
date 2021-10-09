using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests
{
    public class BaseTestFixture
    {
        protected string DataFuncTestCode = "696";
        public async Task<string> ReadFileContents(string path)
        {
            var testContext = TestContext.CurrentContext.TestDirectory;
            return await File.ReadAllTextAsync(Path.Combine(testContext, path));
        }

        public HttpClient CreateClientReturningFailure(string contentsToReturn, HttpStatusCode code, Dictionary<string, string> headers = null)
        {
            var client = new HttpClient(new FakeHttpClientHandler(code, contentsToReturn, headers))
            {
                BaseAddress = new Uri("https://start.exactonline.be")
            };
            return client;
        }

        public HttpClient CreateClientReturningSuccess(string contentsToReturn, HttpStatusCode code = HttpStatusCode.OK, Dictionary<string, string> headers = null)
        {
            var client = new HttpClient(new FakeHttpClientHandler(code, contentsToReturn, headers ?? DefaultHeaders()))
            {
                BaseAddress = new Uri("https://start.exactonline.be")
            };
            return client;
        }

        public Dictionary<string, string> DefaultHeaders()
        {
            return new Dictionary<string, string>{

             { "X-RateLimit-Limit", "5000"},
                { "X-RateLimit-Remaining", "4000"},
                { "X-RateLimit-Reset", "1589155200000"},
                { "X-RateLimit-Minutely-Limit", "300"},
                { "X-RateLimit-Minutely-Remaining", "298"},
                { "X-RateLimit-Minutely-Reset", "1589122860000"},
                { "DataServiceVersion", "2.0;"}

        };
        }
    }
}