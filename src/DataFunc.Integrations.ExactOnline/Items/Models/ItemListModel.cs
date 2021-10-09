using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.Items.Models
{
    [ExactOnlineResource("api/v1/{0}/logistics/Items")]
    public class ItemListModel
    {
        /// <summary>Item code</summary>
        public string Code { get; set; }
        /// <summary>Description of the item</summary>
        public string Description { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Indicates if the item is a time unit item (for example a labor hour item)</summary>
        public byte IsTime { get; set; }
        /// <summary>GUID of Item group of the item</summary>
        public Guid? ItemGroup { get; set; }
        /// <summary>The standard unit of this item</summary>
        public string Unit { get; set; }
        /// <summary>Type of unit: A=Area, L=Length, O=Other, T=Time, V=Volume, W=Weight</summary>
        public string UnitType { get; set; }
    }
}