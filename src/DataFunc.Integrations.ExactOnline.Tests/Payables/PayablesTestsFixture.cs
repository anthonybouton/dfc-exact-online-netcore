using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.Infrastructure.Services;
using DataFunc.Integrations.ExactOnline.Payables.Models;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests.Payables
{
    public class PayablesTestFixture : BaseTestFixture
    {
        private GenericService<PayableListModel, PayableListModel> GenerateService(HttpClient client)
        {
            return new GenericService<PayableListModel, PayableListModel>(client);
        }
        [Test]
        public async Task EnsureUserListCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("Payables", "PayablesListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.IsNotNull(result.Results);
        }


        [Test]
        public async Task EnsureEmptyListIsReturnedWhenErrorOccurred()
        {
            var service = GenerateService(CreateClientReturningFailure(null, HttpStatusCode.Unauthorized));
            var result = await service.GetList(0, CancellationToken.None);
            Assert.IsNotNull(result.Results);
        }

        [Test]
        public async Task EnsureEmptyListIsReturnedWhenNoResultsWereFound()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("Payables", "PayablesListEmptyResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.IsNotNull(result.Results);
        }

    }
}