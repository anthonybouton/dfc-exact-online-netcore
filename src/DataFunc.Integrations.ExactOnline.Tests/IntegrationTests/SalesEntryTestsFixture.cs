using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.Infrastructure.DefaultTokenStorages;
using DataFunc.Integrations.ExactOnline.Infrastructure.Models;
using DataFunc.Integrations.ExactOnline.Infrastructure.Services;
using DataFunc.Integrations.ExactOnline.SalesEntries.Infrastructure;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests.IntegrationTests
{
    [TestFixture]
    [Ignore("created prod resources")]
    public class SalesEntryTestsFixture : BaseTestFixture
    {
        private ExactOnlineService _service;
        private LocalFileTokenStorage _storage;

        [SetUp]
        public void Setup()
        {
            var context = new ExactOnlineContext
            {
                ClientId = "43cc4887-726d-438d-8de9-72d98990e7e9",
                ClientSecret = "PNi33o4Ds0Gp",
                ExactOnlineUrl = "https://start.exactonline.be"
            };
            _storage = new LocalFileTokenStorage("c:\\temp\\json-web-token.txt");
            _service = new ExactOnlineService(_storage, context);
        }


        [Test]
        [Order(0)]
        public async Task EnsureSalesEntryLinesCanBeRetrieved()
        {
            var response = await _service.SalesEntries.GetList(295665, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(0)]
        public async Task EnsureSalesEntryLinesCanBeCreated()
        {
            var contentRequests = await ReadFileContents(Path.Combine("SalesEntries", "CreateSalesEntryRequest.json"));
            var request = JsonConvert.DeserializeObject<SalesEntryCreateRequest>(contentRequests);
            var response = await _service.SalesEntries.Create(295665, request, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.Created, response.Headers.StatusCode);
        }

    }
}