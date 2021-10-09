using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.Infrastructure.Interfaces;
using DataFunc.Integrations.ExactOnline.Infrastructure.Models;
using DataFunc.Integrations.ExactOnline.Infrastructure.Policies;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Services
{
    internal class ExactOnlineHttpHandler : HttpClientHandler
    {
        private readonly ITokenStorage _tokenStorage;
        private readonly ExactOnlineContext _context;

        internal ExactOnlineHttpHandler(ITokenStorage tokenStorage, ExactOnlineContext context, IWebProxy proxy)
        {
            _tokenStorage = tokenStorage;
            _context = context;
            Proxy = proxy;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var toExecutePolicies = RefreshAccessTokenPolicy.Create(_tokenStorage)
                .WrapAsync(TooManyRequestsPolicy.Create());

            return await toExecutePolicies.ExecuteAsync(async context =>
            {
                var accessToken = context[nameof(TokenModel)] as TokenModel;

                if (!string.IsNullOrWhiteSpace(accessToken?.AccessToken))
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.AccessToken);

                return await base.SendAsync(request, cancellationToken);

            }, new Dictionary<string, object>
           {
               {nameof(HttpRequestMessage.RequestUri), request.RequestUri.ToString()},
                {nameof(TokenModel), await _tokenStorage.Retrieve(_context, cancellationToken)},
                {nameof(ExactOnlineContext), _context}
           });

        }
    }
}