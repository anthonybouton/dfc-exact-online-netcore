using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.AccountOwners.Models;
using DataFunc.Integrations.ExactOnline.Accounts.Models;
using DataFunc.Integrations.ExactOnline.AssetDepreciationMethods.Models;
using DataFunc.Integrations.ExactOnline.AssetGroups.Models;
using DataFunc.Integrations.ExactOnline.Assets.Models;
using DataFunc.Integrations.ExactOnline.Divisions.Models;
using DataFunc.Integrations.ExactOnline.DocumentAttachments.Models;
using DataFunc.Integrations.ExactOnline.DocumentCategories.Models;
using DataFunc.Integrations.ExactOnline.DocumentFolders.Models;
using DataFunc.Integrations.ExactOnline.Documents.Models;
using DataFunc.Integrations.ExactOnline.DocumentTypes.Models;
using DataFunc.Integrations.ExactOnline.Employees.Models;
using DataFunc.Integrations.ExactOnline.FinancialPeriods.Models;
using DataFunc.Integrations.ExactOnline.GlAccountClassificationMappings.Models;
using DataFunc.Integrations.ExactOnline.GlAccounts.Models;
using DataFunc.Integrations.ExactOnline.GlAccountSchemas.Models;
using DataFunc.Integrations.ExactOnline.GlClassifications.Models;
using DataFunc.Integrations.ExactOnline.Infrastructure.Interfaces;
using DataFunc.Integrations.ExactOnline.Infrastructure.Models;
using DataFunc.Integrations.ExactOnline.ItemGroups.Models;
using DataFunc.Integrations.ExactOnline.Items.Models;
using DataFunc.Integrations.ExactOnline.Journals.Models;
using DataFunc.Integrations.ExactOnline.OAuth2.Infrastructure;
using DataFunc.Integrations.ExactOnline.Payables.Models;
using DataFunc.Integrations.ExactOnline.Projects.Models;
using DataFunc.Integrations.ExactOnline.Receivables.Models;
using DataFunc.Integrations.ExactOnline.SalesEntries.Models;
using DataFunc.Integrations.ExactOnline.SalesEntryLines.Models;
using DataFunc.Integrations.ExactOnline.TimeTransactions.Models;
using DataFunc.Integrations.ExactOnline.TransactionLines.Models;
using DataFunc.Integrations.ExactOnline.Users.Models;
using Newtonsoft.Json;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Services
{
    public class ExactOnlineService : IDisposable
    {
        private readonly HttpClient _client;

        private GenericService<DivisionListModel, DivisionDetailModel> _divisions;
        private GenericService<UserListModel, UserDetailModel> _users;
        private GenericService<ProjectListModel, ProjectDetailModel> _projects;
        private GenericService<AccountListModel, AccountDetailModel> _accounts;
        private GenericService<JournalListModel, JournalDetailModel> _journals;
        private GenericService<GlAccountListModel, GlAccountDetailModel> _glAccounts;
        private GenericService<DocumentListModel, DocumentDetailModel> _documents;
        private GenericService<DocumentTypeListModel, DocumentTypeDetailModel> _documentTypes;
        private GenericService<SalesEntryListModel, SalesEntryDetailModel> _salesEntries;
        private GenericService<TimeTransactionsListModel, TimeTransactionsDetailModel> _timeTransactions;
        private GenericService<ItemListModel, ItemDetailModel> _items;
        private GenericService<EmployeeListModel, EmployeeDetailModel> _employees;
        private GenericService<DocumentFolderListModel, DocumentFolderDetailModel> _documentFolders;
        private GenericService<DocumentCategoryListModel, DocumentCategoryDetailModel> _documentCategories;
        private GenericService<DocumentAttachmentListModel, DocumentAttachmentDetailModel> _documentAttachments;
        private GenericService<AccountOwnerListModel, AccountOwnerDetailModel> _accountOwners;
        private GenericService<AssetDepreciationMethodListModel, AssetDepreciationMethodDetailModel> _assetDepreciationMethods;
        private GenericService<AssetGroupListModel, AssetGroupDetailModel> _assetGroups;
        private GenericService<AssetListModel, AssetDetailModel> _assets;
        private GenericService<FinancialPeriodListModel, FinancialPeriodDetailModel> _financialPeriods;
        private GenericService<PayableListModel, PayableListModel> _payables;
        private GenericService<ReceivableListModel, ReceivableListModel> _receivables;
        private GenericService<GlClassificationListModel, GlClassificationDetailModel> _glClassifications;
        private GenericService<GlAccountSchemaListModel, GlAccountSchemaDetailModel> _glAccountSchemas;
        private GenericService<GlAccountClassificationMappingListModel, GlAccountClassificationMappingDetailModel> _glAccountClassificationMappings;
        private GenericService<SalesEntryDetailLineModel, SalesEntryDetailLineModel> _salesEntryLines;
        private GenericService<FinancialTransactionLineListModel, FinancialTransactionLineListModel> _transationLines;
        private GenericService<ItemGroupListModel, ItemGroupDetailModel> _itemGroups;

        public ExactOnlineService(ITokenStorage tokenService, ExactOnlineContext context, IWebProxy proxy = null)
        {
            _client = new HttpClient(new ExactOnlineHttpHandler(tokenService, context, proxy), true)
            {
                BaseAddress = new Uri(context.ExactOnlineUrl)
            };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add(nameof(context.CustomDescriptionLanguage), context.CustomDescriptionLanguage);
            _client.DefaultRequestHeaders.ExpectContinue = false;
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        
        public GenericService<FinancialTransactionLineListModel, FinancialTransactionLineListModel> TransactionLines => _transationLines ??= new GenericService<FinancialTransactionLineListModel, FinancialTransactionLineListModel>(_client);
        public GenericService<DivisionListModel, DivisionDetailModel> Divisions => _divisions ??= new GenericService<DivisionListModel, DivisionDetailModel>(_client);
        public GenericService<AssetDepreciationMethodListModel, AssetDepreciationMethodDetailModel> AssetDepreciationMethods => _assetDepreciationMethods ??= new GenericService<AssetDepreciationMethodListModel, AssetDepreciationMethodDetailModel>(_client);
        public GenericService<AccountOwnerListModel, AccountOwnerDetailModel> AccountOwners => _accountOwners ??= new GenericService<AccountOwnerListModel, AccountOwnerDetailModel>(_client);
        public GenericService<AccountListModel, AccountDetailModel> Accounts => _accounts ??= new GenericService<AccountListModel, AccountDetailModel>(_client);
        public GenericService<AssetGroupListModel, AssetGroupDetailModel> AssetGroups => _assetGroups ??= new GenericService<AssetGroupListModel, AssetGroupDetailModel>(_client);
        public GenericService<AssetListModel, AssetDetailModel> Assets => _assets ??= new GenericService<AssetListModel, AssetDetailModel>(_client);
        public GenericService<UserListModel, UserDetailModel> Users => _users ??= new GenericService<UserListModel, UserDetailModel>(_client);
        public GenericService<JournalListModel, JournalDetailModel> Journals => _journals ??= new GenericService<JournalListModel, JournalDetailModel>(_client);
        public GenericService<ProjectListModel, ProjectDetailModel> Projects => _projects ??= new GenericService<ProjectListModel, ProjectDetailModel>(_client);
        public GenericService<GlAccountListModel, GlAccountDetailModel> GlAccounts => _glAccounts ??= new GenericService<GlAccountListModel, GlAccountDetailModel>(_client);
        public GenericService<DocumentListModel, DocumentDetailModel> Documents => _documents ??= new GenericService<DocumentListModel, DocumentDetailModel>(_client);
        public GenericService<SalesEntryListModel, SalesEntryDetailModel> SalesEntries => _salesEntries ??= new GenericService<SalesEntryListModel, SalesEntryDetailModel>(_client);
        public GenericService<SalesEntryDetailLineModel, SalesEntryDetailLineModel> SalesEntryLines => _salesEntryLines ??= new GenericService<SalesEntryDetailLineModel, SalesEntryDetailLineModel>(_client);
        public GenericService<ItemListModel, ItemDetailModel> Items => _items ??= new GenericService<ItemListModel, ItemDetailModel>(_client);
        public GenericService<EmployeeListModel, EmployeeDetailModel> Employees => _employees ??= new GenericService<EmployeeListModel, EmployeeDetailModel>(_client);
        public GenericService<DocumentTypeListModel, DocumentTypeDetailModel> DocumentTypes => _documentTypes ??= new GenericService<DocumentTypeListModel, DocumentTypeDetailModel>(_client);
        public GenericService<DocumentFolderListModel, DocumentFolderDetailModel> DocumentFolders => _documentFolders ??= new GenericService<DocumentFolderListModel, DocumentFolderDetailModel>(_client);
        public GenericService<DocumentCategoryListModel, DocumentCategoryDetailModel> DocumentCategories => _documentCategories ??= new GenericService<DocumentCategoryListModel, DocumentCategoryDetailModel>(_client);
        public GenericService<DocumentAttachmentListModel, DocumentAttachmentDetailModel> DocumentAttachments => _documentAttachments ??= new GenericService<DocumentAttachmentListModel, DocumentAttachmentDetailModel>(_client);
        public GenericService<TimeTransactionsListModel, TimeTransactionsDetailModel> TimeTransactions => _timeTransactions ??= new GenericService<TimeTransactionsListModel, TimeTransactionsDetailModel>(_client);
        public GenericService<FinancialPeriodListModel, FinancialPeriodDetailModel> FinancialPeriods => _financialPeriods ??= new GenericService<FinancialPeriodListModel, FinancialPeriodDetailModel>(_client);
        public GenericService<PayableListModel, PayableListModel> Payables => _payables ??= new GenericService<PayableListModel, PayableListModel>(_client);
        public GenericService<ReceivableListModel, ReceivableListModel> Receivables => _receivables ??= new GenericService<ReceivableListModel, ReceivableListModel>(_client);
        public GenericService<GlClassificationListModel, GlClassificationDetailModel> GlClassifications => _glClassifications ??= new GenericService<GlClassificationListModel, GlClassificationDetailModel>(_client);
        public GenericService<GlAccountSchemaListModel, GlAccountSchemaDetailModel> GlAccountSchemes => _glAccountSchemas ??= new GenericService<GlAccountSchemaListModel, GlAccountSchemaDetailModel>(_client);
        public GenericService<GlAccountClassificationMappingListModel, GlAccountClassificationMappingDetailModel> GlAccountClassificationMappings => _glAccountClassificationMappings ??= new GenericService<GlAccountClassificationMappingListModel, GlAccountClassificationMappingDetailModel>(_client);
        public GenericService<ItemGroupListModel, ItemGroupDetailModel> ItemGroups => _itemGroups ??= new GenericService<ItemGroupListModel, ItemGroupDetailModel>(_client);

        public async Task<TokenModel> GetAccessTokenFromCallBack(ExactOnlineContext context, string code, CancellationToken token)
        {
            using (var client = new HttpClient())
            {
                var request = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("code", code),
                    new KeyValuePair<string, string>("redirect_uri", context.RedirectUri),
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("client_id", context.ClientId.ToLower()),
                    new KeyValuePair<string, string>("client_secret", context.ClientSecret)
                });

                var response = await client.PostAsync($"{context.ExactOnlineUrl.TrimEnd('/')}/api/oauth2/token", request, token);
                var stringContent = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    throw new Exception(stringContent);

                var result = JsonConvert.DeserializeObject<RefreshTokenResponse>(stringContent);

                return new TokenModel
                {
                    AccessToken = result.AccessToken,
                    AccessTokenExpirationDate = DateTime.Now.AddSeconds(result.ExpiresIn),
                    RefreshTokenExpirationDate = DateTime.Now.AddMonths(1),
                    RefreshToken = result.RefreshToken
                };
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}