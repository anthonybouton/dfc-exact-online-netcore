using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.AssetDepreciationMethods.Models;
using DataFunc.Integrations.ExactOnline.Infrastructure.Services;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests.AssetDepreciationMethods
{
    public class AssetDepreciationMethodsTestFixture : BaseTestFixture
    {
        private GenericService<AssetDepreciationMethodListModel, AssetDepreciationMethodDetailModel> GenerateService(HttpClient client)
        {
            return new GenericService<AssetDepreciationMethodListModel, AssetDepreciationMethodDetailModel>(client);
        }
        [Test]
        public async Task EnsureListCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("AssetDepreciationMethods", "AssetDepreciationMethodsListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.IsNotNull(result.Results);
        }

        [Test]
        public async Task EnsureDetailCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("AssetDepreciationMethods", "AssetDepreciationMethodDetailResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetDetail(0, Guid.Parse("a23a4f8e-77bd-4561-b159-1a2c67fc5988"), CancellationToken.None);
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
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("AssetDepreciationMethods", "AssetDepreciationMethodsListEmptyResponse.json"));
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