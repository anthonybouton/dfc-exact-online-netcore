using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.Employees.Models;
using DataFunc.Integrations.ExactOnline.Infrastructure.Services;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests.Employees
{
    public class EmployeesTestFixture : BaseTestFixture
    {
        private GenericService<EmployeeListModel, EmployeeDetailModel> GenerateService(HttpClient client)
        {
            return new GenericService<EmployeeListModel, EmployeeDetailModel>(client);
        }

        [Test]
        public async Task EnsureListCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("Employees", "EmployeesListResponse.json"));
            var service =GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.IsNotNull(result.Results);
        }

        [Test]
        public async Task EnsureDetailCanBeParsed()
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("Employees", "EmployeeDetailResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn));

            var result = await service.GetDetail(0, Guid.Parse("b83025c2-4ebb-45ca-811a-e2c05f46e9ee"), CancellationToken.None);
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
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("Employees", "EmployeesListEmptyResponse.json"));
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