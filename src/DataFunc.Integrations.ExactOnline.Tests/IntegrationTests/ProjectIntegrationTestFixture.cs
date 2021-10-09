using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.Infrastructure.DefaultTokenStorages;
using DataFunc.Integrations.ExactOnline.Infrastructure.Filters;
using DataFunc.Integrations.ExactOnline.Infrastructure.Models;
using DataFunc.Integrations.ExactOnline.Infrastructure.Services;
using DataFunc.Integrations.ExactOnline.Projects.Infrastructure;
using DataFunc.Integrations.ExactOnline.Projects.Models;
using DataFunc.Integrations.ExactOnline.TimeTransactions.Infrastructure;
using DataFunc.Integrations.ExactOnline.TimeTransactions.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests.IntegrationTests
{
    [TestFixture]
  //  [Ignore("created prod resources")]
    public class ProjectIntegrationTestFixture : BaseTestFixture
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
        public async Task EnsureSingleProjectCanBeCreated()
        {
            var jsonContents = await ReadFileContents("Projects/CreateProjectRequest.json");
            var request = JsonConvert.DeserializeObject<ProjectCreateRequest>(jsonContents);
            var response = await _service.Projects.Create(66385, request, CancellationToken.None);
            Assert.IsTrue(response.Headers.StatusCode == HttpStatusCode.Created);
        }


        [Test]
        [Order(10)]
        public async Task EnsureTimeTransactionsPerProjectCanBeRequested()
        {
            var allProjectsResponses = await _service.Projects.GetList(66385, CancellationToken.None, new OdataSinglePropertyFilter(nameof(ProjectDetailModel.AccountCode), OdataOperator.Equal, DataFuncTestCode, OdataStringFunction.Trim));
            foreach (var projectListModel in allProjectsResponses.Results)
            {
                var response = await _service.TimeTransactions.GetList(66385, CancellationToken.None, new OdataSinglePropertyFilter(nameof(TimeTransactionsDetailModel.Project), OdataOperator.Equal, projectListModel.ID));
                Assert.IsTrue(response.Headers.StatusCode == HttpStatusCode.OK);
            }
        }

        [Test]
        [Order(11)]
        public async Task EnsureTimeTransactionsPerProjectCanBeCreatedBasedOnQuantity()
        {
            var jsonContents = await ReadFileContents("TimeTransactions/CreateTimeTransactionRequest.json");
            var request = JsonConvert.DeserializeObject<TimeTransactionCreateRequest>(jsonContents);
            var allProjectsResponses = await _service.Projects.GetList(66385, CancellationToken.None, new OdataSinglePropertyFilter(nameof(ProjectDetailModel.AccountCode), OdataOperator.Equal, DataFuncTestCode, OdataStringFunction.Trim));

            foreach (var projectListModel in allProjectsResponses.Results)
            {

                request.Project = projectListModel.ID;
                request.Quantity = 1;
                request.Date = DateTime.Now;

                var response = await _service.TimeTransactions.Create(66385, request, CancellationToken.None);
                Assert.IsTrue(response.Headers.StatusCode == HttpStatusCode.Created);
            }
        }


        [Test]
        [Order(11)]
        public async Task EnsureTimeTransactionsPerProjectCanBeCreatedBasedOnTime()
        {
            var jsonContents = await ReadFileContents("TimeTransactions/CreateTimeTransactionRequest.json");
            var request = JsonConvert.DeserializeObject<TimeTransactionCreateRequest>(jsonContents);
            var allProjectsResponses = await _service.Projects.GetList(66385, CancellationToken.None, new OdataSinglePropertyFilter(nameof(ProjectDetailModel.AccountCode), OdataOperator.Equal, DataFuncTestCode, OdataStringFunction.Trim));

            foreach (var projectListModel in allProjectsResponses.Results)
            {

                request.Project = projectListModel.ID;
                request.Date = DateTime.Now;
                request.RegisterTime(DateTime.Now, DateTime.Now.AddMinutes(15));

                var response = await _service.TimeTransactions.Create(66385, request, CancellationToken.None);
                Assert.IsTrue(response.Headers.StatusCode == HttpStatusCode.Created);
            }
        }


        [Test]
        [Order(20)]
        public async Task EnsureTimeTransactionsPerProjectCanBeDeleted()
        {
            var allProjectsResponses = await _service.Projects.GetList(66385, CancellationToken.None, new OdataSinglePropertyFilter(nameof(ProjectDetailModel.AccountCode), OdataOperator.Equal, DataFuncTestCode, OdataStringFunction.Trim));
            foreach (var projectListModel in allProjectsResponses.Results)
            {
                var timeTransactionsResponse = await _service.TimeTransactions.GetList(66385, CancellationToken.None, new OdataSinglePropertyFilter(nameof(TimeTransactionsDetailModel.Project), OdataOperator.Equal, projectListModel.ID));
                foreach (var timeResult in timeTransactionsResponse.Results)
                {
                    var response = await _service.TimeTransactions.Delete(66385, timeResult.ID, CancellationToken.None);
                    Assert.IsTrue(response.Headers.StatusCode == HttpStatusCode.NoContent);
                }
            }
        }


        [Test]
        [Order(30)]
        public async Task EnsureProjectsCanBeDeleted()
        {
            var allProjectsResponses = await _service.Projects.GetList(66385, CancellationToken.None, new OdataSinglePropertyFilter(nameof(ProjectDetailModel.AccountCode), OdataOperator.Equal, DataFuncTestCode, OdataStringFunction.Trim));
            // this is a test in product, only ever delete max one
            Assert.LessOrEqual(allProjectsResponses.Results.Count(), 1);
            foreach (var projectListModel in allProjectsResponses.Results)
            {
                var response = await _service.Projects.Delete(66385, projectListModel.ID, CancellationToken.None);
                Assert.IsTrue(response.Headers.StatusCode == HttpStatusCode.NoContent);
            }
        }
    }
}