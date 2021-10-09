using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.FinancialPeriods.Models;
using DataFunc.Integrations.ExactOnline.Infrastructure.Services;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests.FinancialPeriods
{
    public class FinancialPeriodsTestFixture : BaseTestFixture
    {

        private GenericService<FinancialPeriodListModel, FinancialPeriodDetailModel> GenerateService(HttpClient client)
        {
            return new GenericService<FinancialPeriodListModel, FinancialPeriodDetailModel>(client);
        }


        [Test]
        public async Task EnsureListCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("FinancialPeriods", "FinancialPeriodsListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.IsNotNull(result.Results);
        }

        [Test]
        public async Task EnsureDetailCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("FinancialPeriods", "FinancialPeriodDetailResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetDetail(0, Guid.Parse("55883746-8faa-4446-a740-110781c3cad8"), CancellationToken.None);
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
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("FinancialPeriods", "FinancialPeriodsListEmptyResponse.json"));
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
    }
}