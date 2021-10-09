using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;
using DataFunc.Integrations.ExactOnline.Infrastructure.Extensions;
using DataFunc.Integrations.ExactOnline.Infrastructure.Filters;
using DataFunc.Integrations.ExactOnline.Users.Models;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Services
{
    public class GenericService<TListModel, TDetailModel> : BaseService
    {
        public async Task<BaseResponse<Me>> Me(CancellationToken token)
        {
            var url = ExtensionMethods.GetEndPoint<ExactOnlineResource, Me>();
            var me = await GetList<Me>(url, token);

            return new BaseResponse<Me>
            {
                Headers = me.Item2,
                Results = me.Item1.FirstOrDefault()
            };
        }
        public async Task<BaseResponse> Delete(int division, Guid primaryKey, CancellationToken token)
        {
            var url = ExtensionMethods.GetEndPoint<ExactOnlineResource, TDetailModel>();
            return new BaseResponse
            {
                Headers = await Delete($"{string.Format(url, division)}(guid'{primaryKey}')", token)
            };
        }
        public async Task<BaseResponse<TDetailModel>> Create(int divisionId, object createRequest, CancellationToken token)
        {
            var response = new BaseResponse<TDetailModel>();
            var (detailModel, responseHeaders) = await Create<TDetailModel>(BuildRequestUrl<TDetailModel>(divisionId, null, false), createRequest, token);

            response.Results = detailModel;
            response.Headers = responseHeaders;

            return response;
        }
        public async Task<BaseResponse> Update(int division, object updateRequest, Guid primaryKey, CancellationToken token)
        {
            var url = ExtensionMethods.GetEndPoint<ExactOnlineResource, TDetailModel>();
            return new BaseResponse
            {
                Headers = await Update($"{string.Format(url, division)}(guid'{primaryKey}')", updateRequest, token)
            };
        }
        public async Task<BaseResponse<TDetailModel>> GetDetail(int division, IOdataFilter filter, CancellationToken token)
        {
            var response = new BaseResponse<TDetailModel>();
            var (detailModel, responseHeaders) = await GetList<TDetailModel>(BuildRequestUrl<TDetailModel>(division, filter), token);

            response.Results = detailModel.FirstOrDefault();
            response.Headers = responseHeaders;

            return response;
        }
        public Task<BaseResponse<TDetailModel>> GetDetail(int division, int primaryKey, CancellationToken token)
        {
            var primaryKeyName = ExtensionMethods.GetPrimaryKeyProperty<TDetailModel>();
            return GetDetail(division, new OdataSinglePropertyFilter(primaryKeyName, OdataOperator.Equal, primaryKey), token);
        }
        public Task<BaseResponse<TDetailModel>> GetDetail(int division, Guid primaryKey, CancellationToken token)
        {
            var primaryKeyName = ExtensionMethods.GetPrimaryKeyProperty<TDetailModel>();
            return GetDetail(division, new OdataSinglePropertyFilter(primaryKeyName, OdataOperator.Equal, primaryKey), token);
        }
        public async Task<BaseResponse<IEnumerable<TListModel>>> GetList(int division, CancellationToken token, IOdataFilter filter = null, int? limit = null)
        {
            var response = new BaseResponse<IEnumerable<TListModel>>();
            var (listModel, responseHeaders) = await GetList<TListModel>(BuildRequestUrl<TListModel>(division, filter, true, limit), token);

            response.Results = listModel;
            response.Headers = responseHeaders;

            return response;
        }
        protected string BuildRequestUrl<T>(int division, IOdataFilter filter = null, bool addQueryParameters = true, int? limit = null)
        {
            var url = ExtensionMethods.GetEndPoint<ExactOnlineResource, T>();
            var selectString = ExtensionMethods.GenerateSelectString<T>();
            var baseUrl = string.Format(url, division);
            if (!addQueryParameters)
                return baseUrl;

            baseUrl += $"?$select={selectString}";

            if (filter != null)
                baseUrl += $"&$filter={filter?.Evaluate()}";

            if (limit.HasValue)
                baseUrl += $"&$top={limit}";

            return baseUrl;
        }

        public GenericService(HttpClient client) : base(client)
        {
        }
    }
}