using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.Infrastructure.Services;
using DataFunc.Integrations.ExactOnline.Receivables.Models;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests.Receivables
{
    public class ReceivablesTestFixture : BaseTestFixture
    {

        private GenericService<ReceivableListModel, ReceivableListModel> GenerateService(HttpClient client)
        {
            return new GenericService<ReceivableListModel, ReceivableListModel>(client);
        }

        [Test]
        public async Task EnsureUserListCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("Receivables", "ReceivablesListResponse.json"));
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
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("Receivables", "ReceivablesListEmptyResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.IsNotNull(result.Results);
        }

    }
}