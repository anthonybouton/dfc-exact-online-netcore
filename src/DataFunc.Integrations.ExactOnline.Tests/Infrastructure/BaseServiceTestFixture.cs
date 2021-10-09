using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.GlClassifications.Models;
using DataFunc.Integrations.ExactOnline.Infrastructure;
using DataFunc.Integrations.ExactOnline.Infrastructure.Services;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests.Infrastructure
{
    [TestFixture]
    public class BaseServiceTestFixture : BaseTestFixture
    {
        private GenericService<GlClassificationListModel, GlClassificationDetailModel> GenerateService(HttpClient client)
        {
            return new GenericService<GlClassificationListModel, GlClassificationDetailModel>(client);
        }

        [Test]
        [TestCase("1.0")]
        [TestCase("2.0")]
        [TestCase("3.0")]
        [TestCase("4.0")]
        public async Task EnsureDataServiceVersionIsSet(string version)
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("GlClassifications", "GlClassificationsListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn, HttpStatusCode.OK, new Dictionary<string, string> { { nameof(ResponseHeaders.DataServiceVersion), version } }));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.AreEqual(version, result.Headers.DataServiceVersion);
        }

        [Test]
        [TestCase(100)]
        [TestCase(300)]
        [TestCase(700)]
        [TestCase(8999)]
        public async Task EnsureRequestLimitIsSet(int limit)
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("GlClassifications", "GlClassificationsListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn, HttpStatusCode.OK, new Dictionary<string, string> { { "X-RateLimit-Limit", limit.ToString() } }));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.AreEqual(limit, result.Headers.RequestLimit);
        }

        [Test]
        [TestCase(100)]
        [TestCase(300)]
        [TestCase(700)]
        [TestCase(0)]
        [TestCase(-1)]
        public async Task EnsureRemainingRequestLimitIsSet(int limit)
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("GlClassifications", "GlClassificationsListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn, HttpStatusCode.OK, new Dictionary<string, string> { { "X-RateLimit-Remaining", limit.ToString() } }));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.AreEqual(limit, result.Headers.RequestRemainingLimit);
        }

        [Test]
        [TestCase(1000000)]
        [TestCase(2000000)]
        [TestCase(3000000)]
        [TestCase(0)]
        public async Task EnsureResetAtIsSet(long milliSecondsSinceEpoch)
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("GlClassifications", "GlClassificationsListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn, HttpStatusCode.OK, new Dictionary<string, string> { { "X-RateLimit-Reset", milliSecondsSinceEpoch.ToString() } }));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.AreEqual(DateTimeOffset.FromUnixTimeMilliseconds(milliSecondsSinceEpoch), result.Headers.RequestLimitResetAt);
        }


        [Test]
        [TestCase(100)]
        [TestCase(300)]
        [TestCase(700)]
        [TestCase(0)]
        [TestCase(-1)]
        public async Task EnsureRemainingMinuteRequestLimitIsSet(int limit)
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("GlClassifications", "GlClassificationsListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn, HttpStatusCode.OK, new Dictionary<string, string> { { "X-RateLimit-Minutely-Remaining", limit.ToString() } }));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.AreEqual(limit, result.Headers.RequestMinuteRemainingLimit);
        }

        [Test]
        [TestCase(100)]
        [TestCase(300)]
        [TestCase(700)]
        [TestCase(0)]
        [TestCase(-1)]
        public async Task EnsureMinuteRequestLimitIsSet(int limit)
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("GlClassifications", "GlClassificationsListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn, HttpStatusCode.OK, new Dictionary<string, string> { { "X-RateLimit-Minutely-Limit", limit.ToString() } }));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.AreEqual(limit, result.Headers.RequestMinuteLimit);
        }

        [Test]
        [TestCase(1000000)]
        [TestCase(2000000)]
        [TestCase(3000000)]
        [TestCase(0)]
        public async Task EnsureMinuteResetAtIsSet(long milliSecondsSinceEpoch)
        {
            var expectedContentsToReturn = await ReadFileContents(Path.Combine("GlClassifications", "GlClassificationsListResponse.json"));
            var service = GenerateService(CreateClientReturningSuccess(expectedContentsToReturn, HttpStatusCode.OK, new Dictionary<string, string> { { "X-RateLimit-Minutely-Reset", milliSecondsSinceEpoch.ToString() } }));

            var result = await service.GetList(0, CancellationToken.None);
            Assert.AreEqual(DateTimeOffset.FromUnixTimeMilliseconds(milliSecondsSinceEpoch), result.Headers.RequestMinuteLimitResetAt);
        }
    }
}