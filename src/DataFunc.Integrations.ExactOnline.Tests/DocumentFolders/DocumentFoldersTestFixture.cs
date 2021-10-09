using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.DocumentFolders.Models;
using DataFunc.Integrations.ExactOnline.Infrastructure.Services;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests.DocumentFolders
{
    public class DocumentFoldersTestFixture : BaseTestFixture
    {

        private GenericService<DocumentFolderListModel, DocumentFolderDetailModel> GenerateService(HttpClient client)
        {
            return new GenericService<DocumentFolderListModel, DocumentFolderDetailModel>(client);
        }

        [Test]
        public async Task EnsureListCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("DocumentFolders", "DocumentFoldersListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.IsNotNull(result.Results);
        }

        [Test]
        public async Task EnsureDetailCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("DocumentFolders", "DocumentFolderDetailResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetDetail(0, Guid.Parse("eef9e316-60b3-4d8c-ab47-98963eb578cc"), CancellationToken.None);
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
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("DocumentFolders", "DocumentFoldersListEmptyResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.IsNotNull(result.Results);
        }

        [Test]
        public async Task EnsureNothingIsReturnedWhenErrorOccurred()
        {
            var service = GenerateService(CreateClientReturningFailure(null, HttpStatusCode.Unauthorized));
            var result = await service.GetDetail(0, Guid.Parse("def9e316-60b3-4d8c-ab47-98963eb578cc"), CancellationToken.None);
            Assert.IsNull(result.Results);
        }
    }
}