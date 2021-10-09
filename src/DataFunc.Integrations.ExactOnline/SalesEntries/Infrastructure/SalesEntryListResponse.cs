using System.Collections.Generic;
using System.Linq;
using DataFunc.Integrations.ExactOnline.Infrastructure;
using DataFunc.Integrations.ExactOnline.SalesEntries.Models;
using Newtonsoft.Json.Linq;

namespace DataFunc.Integrations.ExactOnline.SalesEntries.Infrastructure
{
    public class SalesEntryListResponse : BaseResponse<IEnumerable<SalesEntryListModel>>
    {
        internal override IEnumerable<SalesEntryListModel> Parse(JObject contents)
        {
            return TryParse(contents, Enumerable.Empty<SalesEntryListModel>(), "d", "results");
        }
    }
}