using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;
using DataFunc.Integrations.ExactOnline.Infrastructure.Interfaces;
using DataFunc.Integrations.ExactOnline.Infrastructure.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Extensions
{
    internal static class ExtensionMethods
    {
        internal static string GetCustomAttributeDescription<T>(this T enumValue) where T : Enum
        {
            var type = enumValue.GetType();
            var memInfo = type.GetMember(enumValue.ToString());
            var attribute = memInfo[0].GetCustomAttribute<DescriptionAttribute>(false);
            return attribute?.Description;
        }
        internal static string GenerateSelectString<T>()
        {
            var eligibleProperties = typeof(T).GetProperties()
                .Where(x => x.CanRead && x.CanWrite)
                .Where(x => !x.PropertyType.IsClass || x.PropertyType == typeof(string))
                .OrderBy(x => x.Name);

            return string.Join(",", eligibleProperties.Select(x => x.Name));

        }
        internal static string GetPrimaryKeyProperty<TModel>()
        {
            return typeof(TModel).GetProperties().Single(x => x.GetCustomAttribute<ExactOnlinePrimaryKeyAttribute>() != null).Name;
        }
        internal static string GetEndPoint<T, TModel>() where T : Attribute, IExactOnlineEndPoint
        {
            var attribute = typeof(TModel).GetCustomAttribute<T>();
            return attribute?.EndPoint;
        }
        internal static async Task<JObject> ParseResponse(this HttpResponseMessage response)
        {
            var jsonContents = new JObject();
            if (!response.IsSuccessStatusCode || response.Content == null)
                return jsonContents;

            var contents = await response.Content.ReadAsStringAsync();
            jsonContents = JObject.Parse(contents);
            return jsonContents;
        }
        internal static ResponseHeaders ParseHeaders(this HttpResponseMessage response)
        {
            var result = new ResponseHeaders();

            result.StatusCode = response.StatusCode;

            if (response.Headers.TryGetValues(nameof(result.DataServiceVersion), out var dataServiceVersionHeaders))
                result.DataServiceVersion = string.Join(";", dataServiceVersionHeaders);

            if (response.Headers.TryGetValues("X-RateLimit-Limit", out var rateLimitHeaders))
                result.RequestLimit = int.Parse(rateLimitHeaders.FirstOrDefault() ?? "0");

            if (response.Headers.TryGetValues("X-RateLimit-Remaining", out var rateLimitRemainingHeaders))
                result.RequestRemainingLimit = int.Parse(rateLimitRemainingHeaders.FirstOrDefault() ?? "0");

            if (response.Headers.TryGetValues("X-RateLimit-Reset", out var rateLimitResetHeaders))
                result.RequestLimitResetAt = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(rateLimitResetHeaders.FirstOrDefault() ?? "0"));

            if (response.Headers.TryGetValues("X-RateLimit-Minutely-Limit", out var rateLimitMinuteHeader))
                result.RequestMinuteLimit = int.Parse(rateLimitMinuteHeader.FirstOrDefault() ?? "0");

            if (response.Headers.TryGetValues("X-RateLimit-Minutely-Remaining", out var rateLimitMinuteRemainingHeader))
                result.RequestMinuteRemainingLimit = int.Parse(rateLimitMinuteRemainingHeader.FirstOrDefault() ?? "0");

            if (response.Headers.TryGetValues("X-RateLimit-Minutely-Reset", out var rateLimitMinuteResetHeader))
                result.RequestMinuteLimitResetAt = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(rateLimitMinuteResetHeader.FirstOrDefault() ?? "0"));


            if (result.StatusCode == HttpStatusCode.InternalServerError)
            {
                result.ErrorMessage = JToken.Parse(response.Content.ReadAsStringAsync().Result)["error"]?["message"]?["value"]?.ToString();
            }

            return result;
        }
    }
}