using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.Infrastructure.Services;
using DataFunc.Integrations.ExactOnline.SalesEntries.Models;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests.SalesEntries
{
    public class SalesEntriesTestFixture : BaseTestFixture
    {

        private GenericService<SalesEntryListModel, SalesEntryDetailModel> GenerateService(HttpClient client)
        {
            return new GenericService<SalesEntryListModel, SalesEntryDetailModel>(client);
        }

        [Test]
        public async Task EnsureListCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("SalesEntries", "SalesEntriesListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.IsNotNull(result.Results);
        }

        [Test]
        public async Task EnsureDetailCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("SalesEntries", "SalesEntryDetailResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetDetail(0, Guid.Parse("989d85d2-eea9-45bf-95d7-0091d3f0d09c"), CancellationToken.None);
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
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("SalesEntries", "SalesEntriesListEmptyResponse.json"));
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
        public async Task EnsureSalesEntryLinesCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("SalesEntries", "SalesEntryLinesListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetDetail(0,Guid.NewGuid(),  CancellationToken.None);
            Assert.IsNotNull(result.Results);
        }
    }
}