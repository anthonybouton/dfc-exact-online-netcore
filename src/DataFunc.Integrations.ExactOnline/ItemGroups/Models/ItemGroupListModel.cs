using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.ItemGroups.Models
{
    [ExactOnlineResource("/api/v1/{0}/logistics/ItemGroups")]
    public class ItemGroupListModel
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Division { get; set; }
    }
}