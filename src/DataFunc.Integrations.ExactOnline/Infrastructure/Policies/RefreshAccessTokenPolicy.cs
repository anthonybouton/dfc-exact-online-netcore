using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using DataFunc.Integrations.ExactOnline.Infrastructure.Interfaces;
using DataFunc.Integrations.ExactOnline.Infrastructure.Models;
using DataFunc.Integrations.ExactOnline.OAuth2.Infrastructure;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Policies
{
    public class RefreshAccessTokenPolicy
    {
        public static AsyncRetryPolicy<HttpResponseMessage> Create(ITokenStorage tokenStorage)
        {
            return Policy
                     .HandleResult<HttpResponseMessage>(x => x.StatusCode == HttpStatusCode.Unauthorized)
                     .RetryAsync(2, async (result, retryCount, context) =>
                     {

                         var currentTokenModel = context[nameof(TokenModel)] as TokenModel;
                         var currentExactOnlineContext = context[nameof(ExactOnlineContext)] as ExactOnlineContext;

                         var request = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                         {
                        new KeyValuePair<string, string>("refresh_token", currentTokenModel.RefreshToken),
                        new KeyValuePair<string, string>("grant_type", "refresh_token"),
                        new KeyValuePair<string, string>("client_id", currentExactOnlineContext.ClientId.ToLower()),
                        new KeyValuePair<string, string>("client_secret", currentExactOnlineContext.ClientSecret)
                         });

                         using (var httpClient = new HttpClient())
                         {
                             var response = await httpClient.SendAsync(
                                 new HttpRequestMessage(HttpMethod.Post, $"{currentExactOnlineContext.ExactOnlineUrl}/api/oauth2/token")
                                 {
                                     Content = request
                                 });

                             if (response.IsSuccessStatusCode)
                             {
                                 var stringContent = await response.Content.ReadAsStringAsync();
                                 var contents = JsonConvert.DeserializeObject<RefreshTokenResponse>(stringContent);
                                 var tokenResult = new TokenModel
                                 {
                                     AccessToken = contents.AccessToken,
                                     AccessTokenExpirationDate = DateTime.Now.AddSeconds(contents.ExpiresIn),
                                     RefreshTokenExpirationDate = DateTime.Now.AddMonths(1),
                                     RefreshToken = contents.RefreshToken
                                 };
                                 context[nameof(TokenModel)] = tokenResult;

                                 await tokenStorage.Save(tokenResult, currentExactOnlineContext, CancellationToken.None);
                             }
                         }
                     });
        }
    }
}