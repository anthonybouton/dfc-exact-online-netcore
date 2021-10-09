using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.Infrastructure.Services;
using DataFunc.Integrations.ExactOnline.TimeTransactions.Infrastructure;
using DataFunc.Integrations.ExactOnline.TimeTransactions.Models;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests.TimeTransactions
{
    [TestFixture]
    public class TimeTransactionTestsFixture : BaseTestFixture
    {
        private GenericService<TimeTransactionsListModel, TimeTransactionsDetailModel> GenerateService(HttpClient client)
        {
            return new GenericService<TimeTransactionsListModel, TimeTransactionsDetailModel>(client);
        }


        [Test]
        public async Task EnsureUserListCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("TimeTransactions", "TimeTransactionsListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.IsNotNull(result.Results);
        }

        [Test]
        public async Task EnsureUserDetailCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("TimeTransactions", "TimeTransactionDetailResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetDetail(0, Guid.Parse("a64deb2d-6d5e-48ed-a7d0-011906c523d1"), CancellationToken.None);
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
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("TimeTransactions", "TimeTransactionsListEmptyResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.IsNotNull(result.Results);
        }

        [Test]
        public async Task EnsureNothingIsReturnedWhenErrorOccurred()
        {
            var service = GenerateService(CreateClientReturningFailure(null, HttpStatusCode.Unauthorized));
            var result = await service.GetDetail(0, Guid.Parse("ffed34d3-6f71-43c9-a452-2c8b7861d2cf"), CancellationToken.None);
            Assert.IsNull(result.Results);
        }


        [Test]
        [TestCase(100, 1.67)]
        [TestCase(40, 0.67)]
        [TestCase(30, 0.5)]
        [TestCase(15, 0.25)]
        [TestCase(10, 0.17)]
        [TestCase(5, 0.08)]

        public void EnsureWhenCreatingByDatesMinutesAreCalculatedCorrectly(int differenceInMinutes, double expectedQuantity)
        {
            var request = new TimeTransactionCreateRequest();
            var start = DateTime.Now;
            var end = start.AddMinutes(differenceInMinutes);
            request.RegisterTime(start, end);

            Assert.AreEqual(expectedQuantity, request.Quantity);
        }


    }
}