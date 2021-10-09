using System;
using System.Collections.Generic;
using System.Linq;
using DataFunc.Integrations.ExactOnline.Infrastructure;
using DataFunc.Integrations.ExactOnline.Projects.Models;
using Newtonsoft.Json.Linq;

namespace DataFunc.Integrations.ExactOnline.Projects.Infrastructure
{
    public class ProjectListResponse : BaseResponse<IEnumerable<ProjectListModel>>
    {
        internal override IEnumerable<ProjectListModel> Parse(JObject contents)
        {
            return TryParse(contents, Enumerable.Empty<ProjectListModel>(), "d", "results");
        }
    }
}