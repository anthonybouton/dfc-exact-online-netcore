using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.Accounts.Infrastructure;
using DataFunc.Integrations.ExactOnline.Accounts.Models;
using DataFunc.Integrations.ExactOnline.DocumentAttachments.Infrastructure;
using DataFunc.Integrations.ExactOnline.Documents.Infrastructure;
using DataFunc.Integrations.ExactOnline.Infrastructure.DefaultTokenStorages;
using DataFunc.Integrations.ExactOnline.Infrastructure.Filters;
using DataFunc.Integrations.ExactOnline.Infrastructure.Models;
using DataFunc.Integrations.ExactOnline.Infrastructure.Services;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests.IntegrationTests
{
    [TestFixture]
    public class IntegrationTestsFixture : BaseTestFixture
    {
        private ExactOnlineService _service;
        private LocalFileTokenStorage _storage;

        [SetUp]
        public void Setup()
        {
            var context = new ExactOnlineContext
            {
                ClientId = "43cc4887-726d-438d-8de9-72d98990e7e9",
                ClientSecret = "PNi33o4Ds0Gp",
                ExactOnlineUrl = "https://start.exactonline.be",
                CustomDescriptionLanguage = "NL"
            };
            _storage = new LocalFileTokenStorage("c:\\temp\\json-web-token.txt");
            _service = new ExactOnlineService(_storage, context);
        }

        [Test]

        public async Task EnsureCustomersCanBeRequestedFromLiveApi()
        {
            var response = await _service.Users.GetList(295665, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        [Parallelizable]
        public async Task EnsureSingleUserCanBeRequested()
        {
            var response = await _service.Users.GetDetail(295665, Guid.Parse("ffed34d3-6f71-43c9-a452-2c8b7861d2cf"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        [Parallelizable]
        public async Task EnsureSingleProjectCanBeRequested()
        {
            var response = await _service.Projects.GetDetail(295665, Guid.Parse("db092e6d-f171-4aec-a3f5-002f297f0bd5"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        [Parallelizable]
        public async Task EnsureProjectsCanBeRequested()
        {
            var response = await _service.Projects.GetList(295665, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        [Parallelizable]
        public async Task EnsureAccountsCanBeRetrieved()
        {
            var response = await _service.Accounts.GetList(295665, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        [Parallelizable]
        public async Task EnsureSingleAccountCanBeRetrieved()
        {
            var response = await _service.Accounts.GetDetail(295665, Guid.Parse("008a1675-f336-40ad-a97c-da6bbd4e2ffb"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        [Parallelizable]
        public async Task EnsureJournalsCanBeRetrieved()
        {
            var response = await _service.Journals.GetList(295665, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        [Parallelizable]
        public async Task EnsureSingleJournalsCanBeRetrieved()
        {
            var response = await _service.Journals.GetDetail(295665, Guid.Parse("2ff4957d-5418-4624-b72d-f91144a8c210"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        [Parallelizable]
        public async Task EnsureGlAccountsCanBeRetrieved()
        {
            var response = await _service.GlAccounts.GetList(295665, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        [Parallelizable]
        public async Task EnsureSingleGlAccountCanBeRetrieved()
        {
            var response = await _service.GlAccounts.GetDetail(295665, Guid.Parse("5c412344-0391-4aa2-8d4f-02cfb2d89154"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        [Parallelizable]
        public async Task EnsureDocumentsCanBeRetrieved()
        {
            var response = await _service.Documents.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        [Parallelizable]
        public async Task EnsureSingleDocumentsCanBeRetrieved()
        {
            var response = await _service.Documents.GetDetail(66385, Guid.Parse("4b6eeaa5-0056-4f21-b312-2e8a7a47bda9"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        [Parallelizable]
        public async Task EnsureDocumentAttachmentsCanBeRetrieved()
        {
            var response = await _service.DocumentAttachments.GetList(66385, CancellationToken.None,null,10);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        [Parallelizable]
        public async Task EnsureSalesEntriesCanBeRetrieved()
        {
            var response = await _service.SalesEntries.GetList(66385, CancellationToken.None, null, 10);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        [Parallelizable]
        public async Task EnsureSingleSalesEntryCanBeRetrieved()
        {
            var response = await _service.SalesEntries.GetDetail(66385, Guid.Parse("989d85d2-eea9-45bf-95d7-0091d3f0d09c"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSalesEntryLinesCanBeRetrieved()
        {
            var response = await _service.SalesEntryLines.GetList(66385, CancellationToken.None, new OdataSinglePropertyFilter("EntryID", OdataOperator.Equal, Guid.Parse("989d85d2-eea9-45bf-95d7-0091d3f0d09c")));
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureTimeTransactionsCanBeRetrieved()
        {
            var response = await _service.TimeTransactions.GetList(66385, CancellationToken.None,null,10);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSingleTimeTransactionCanBeRetrieved()
        {
            var response = await _service.TimeTransactions.GetDetail(66385, Guid.Parse("a64deb2d-6d5e-48ed-a7d0-011906c523d1"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }


        [Test]
        [Order(2)]
        [TestCase("696")]
        [TestCase("143")]
        [TestCase("221")]
        public async Task EnsureSingleAccountSearchCanBeRetrieved(string code)
        {
            var filter = new OdataSinglePropertyFilter(nameof(AccountDetailModel.Code), OdataOperator.Equal, code, OdataStringFunction.Trim);
            var response = await _service.Accounts.GetDetail(66385, filter, CancellationToken.None );
            Assert.IsTrue(response.Results.Code.Trim() == code);
        }


        [Test]
        [Order(2)]
        public async Task EnsureItemsCanBeRetrieved()
        {
            var response = await _service.Items.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureItemDetailCanBeRetrieved()
        {
            var response = await _service.Items.GetDetail(66385, Guid.Parse("11b678eb-6b7b-4fe6-82e4-001ca904b968"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureEmployeesCanBeRetrieved()
        {
            var response = await _service.Employees.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSingleEmployeeCanBeRetrieved()
        {
            var response = await _service.Employees.GetDetail(66385, Guid.Parse("b83025c2-4ebb-45ca-811a-e2c05f46e9ee"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureDocumentTypesCanBeRequested()
        {
            var response = await _service.DocumentTypes.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSingleDocumentTypeCanBeRequested()
        {
            var response = await _service.DocumentTypes.GetDetail(66385, 148, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureDocumentFoldersCanBeRequested()
        {
            var response = await _service.DocumentFolders.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSingleDocumentFoldersCanBeRequested()
        {
            var response = await _service.DocumentFolders.GetDetail(66385, Guid.Parse("eef9e316-60b3-4d8c-ab47-98963eb578cc"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }


        [Test]
        [Order(2)]
        public async Task EnsureDocumentCategoriesCanBeRequested()
        {
            var response = await _service.DocumentCategories.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSingleDocumentCategoryCanBeRequested()
        {
            var response = await _service.DocumentCategories.GetDetail(66385, Guid.Parse("cf507b3a-cfea-45d8-9695-4d49964ddada"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }


        [Test]
        [Order(2)]
        public async Task EnsureSingleDocumentAttachmentsCanBeRequested()
        {
            var response = await _service.DocumentAttachments.GetDetail(295665, Guid.Parse("db401abe-3329-4a66-bb22-e2615369a08e"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSingleDocumentCanBeCreated()
        {
            var jsonContents = await ReadFileContents("Documents/CreateDocumentRequest.json");
            var request = JsonConvert.DeserializeObject<DocumentCreateRequest>(jsonContents);
            var response = await _service.Documents.Create(66385, request, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.Created, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSingleDocumentAttachmentCanBeCreated()
        {
            var jsonContents = await ReadFileContents("DocumentAttachments/CreateDocumentAttachmentRequest.json");
            var request = JsonConvert.DeserializeObject<DocumentAttachmentCreateRequest>(jsonContents);
            request.Attachment = await File.ReadAllBytesAsync(Path.Combine(TestContext.CurrentContext.TestDirectory, "DocumentAttachments", "test-attachment.png"));

            var response = await _service.DocumentAttachments.Create(66385, request, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.Created, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureAccountOwnersCanBeRequested()
        {
            var response = await _service.AccountOwners.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSingleAccountOwnerCanBeRequested()
        {
            var response = await _service.AccountOwners.GetDetail(66385, Guid.Parse("47c9f05a-678f-4a97-9d6f-fe2db6cac668"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureAssetDepreciationMethodsCanBeRequested()
        {
            var response = await _service.AssetDepreciationMethods.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSingleAssetDepreciationMethodCanBeRequested()
        {
            var response = await _service.AssetDepreciationMethods.GetDetail(66385, Guid.Parse("a23a4f8e-77bd-4561-b159-1a2c67fc5988"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureAssetGroupsCanBeRequested()
        {
            var response = await _service.AssetGroups.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSingleAssetGroupCanBeRequested()
        {
            var response = await _service.AssetGroups.GetDetail(66385, Guid.Parse("0b47b892-a680-40a0-8c83-ec08b557db56"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureAssetsCanBeRequested()
        {
            var response = await _service.Assets.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSingleAssetCanBeRequested()
        {
            var response = await _service.Assets.GetDetail(66385, Guid.Parse("b471235b-f88a-4f95-a10c-f64a01fea9af"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureFinancialPeriodsCanBeRequested()
        {
            var response = await _service.FinancialPeriods.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSingleFinancialPeriodsCanBeRequested()
        {
            var response = await _service.FinancialPeriods.GetDetail(66385, Guid.Parse("55883746-8faa-4446-a740-110781c3cad8"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsurePayablesCanBeRequested()
        {
            var response = await _service.Payables.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureReceivablesCanBeRequested()
        {
            var response = await _service.Receivables.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureGlClassificationsCanBeRequested()
        {
            var response = await _service.GlClassifications.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSingleGlClassificationsCanBeRequested()
        {
            var response = await _service.GlClassifications.GetDetail(66385, Guid.Parse("7e0372ad-1fe2-42fb-8b69-414e1659279c"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureGlSchemasCanBeRequested()
        {
            var response = await _service.GlAccountSchemes.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSingleGlSchemasCanBeRequested()
        {
            var response = await _service.GlAccountSchemes.GetDetail(66385, Guid.Parse("2a1da37f-95d3-4b38-ad59-1e62ac746190"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureGlClassificationMappingsCanBeRequested()
        {
            var response = await _service.GlAccountClassificationMappings.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureAccountCanBeUpdated()
        {
            var response = await _service.Accounts.GetDetail(66385, new OdataSinglePropertyFilter(nameof(AccountListModel.Code), OdataOperator.Equal, DataFuncTestCode, OdataStringFunction.Trim),  CancellationToken.None);
            var request = new AccountUpdateRequest
            {
                AddressLine1 = response.Results.AddressLine1,
                City = response.Results.City,
                Language = response.Results.Language,
                Name = response.Results.Name,
                Postcode = response.Results.Postcode,
                SearchCode = response.Results.SearchCode,
                Status = response.Results.Status,
                Remarks = $"Unittest {DateTime.Now:dd/MM/yyyy HH:mm:ss}"
            };
            var updatedResponse = await _service.Accounts.Update(66385, request, response.Results.ID, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.NoContent, updatedResponse.Headers.StatusCode);
        }

        [Test]
        [Order(2)]
        public async Task EnsureSingleGlClassificationMappingsCanBeRequested()
        {
            var response = await _service.GlAccountClassificationMappings.GetDetail(66385, Guid.Parse("cff9a173-cb52-4093-b7e2-0d460932db02"), CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }

        [Test]
        public async Task EnsureItemsCanBeRequested()
        {
            var response = await _service.Items.GetList(66385, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.Headers.StatusCode);
        }
    }
}