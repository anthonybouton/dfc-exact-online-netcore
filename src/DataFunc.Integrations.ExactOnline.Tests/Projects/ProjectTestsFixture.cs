using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.Infrastructure.Services;
using DataFunc.Integrations.ExactOnline.Projects.Models;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests.Projects
{
    public class ProjectTestsFixture : BaseTestFixture
    {
        private GenericService<ProjectListModel, ProjectDetailModel> GenerateService(HttpClient client)
        {
            return new GenericService<ProjectListModel, ProjectDetailModel>(client);
        }


        [Test]
        public async Task EnsureUserListCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("Projects", "ProjectsListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.IsNotNull(result.Results);
        }

        [Test]
        public async Task EnsureUserDetailCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("Projects", "ProjectDetailResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetDetail(0, Guid.Parse("ffed34d3-6f71-43c9-a452-2c8b7861d2cf"), CancellationToken.None);
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
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("Projects", "ProjectsListEmptyResponse.json"));
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