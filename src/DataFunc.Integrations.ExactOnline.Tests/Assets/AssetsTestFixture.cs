using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.Assets.Models;
using DataFunc.Integrations.ExactOnline.Infrastructure.Services;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests.Assets
{
    public class AssetsTestFixture : BaseTestFixture
    {
        private GenericService<AssetListModel, AssetDetailModel> GenerateService(HttpClient client)
        {
            return new GenericService<AssetListModel, AssetDetailModel>(client);
        }
        [Test]
        public async Task EnsureListCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("Assets", "AssetsListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.IsNotNull(result.Results);
        }

        [Test]
        public async Task EnsureDetailCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("Assets", "AssetDetailResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetDetail(0, Guid.Parse("b471235b-f88a-4f95-a10c-f64a01fea9af"), CancellationToken.None);
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
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("Assets", "AssetsListEmptyResponse.json"));
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