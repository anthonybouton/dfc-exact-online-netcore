using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.AssetDepreciationMethods.Models
{
    [ExactOnlineResource("api/v1/{0}/assets/DepreciationMethods")]
    public class AssetDepreciationMethodListModel
    {
        /// <summary>Code of the depreciation method</summary>
        public string Code { get; set; }
        /// <summary>Description of the method</summary>
        public string Description { get; set; }
        /// <summary>Division code</summary>
        public int? Division { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Degressive percentage for methods: 10 - Degressive to linear, 11 - Degressive (fixed perc. of book value), 12 - Degressive to linear (Belgium &amp; Luxembourg only). And interest percentage for method: 40 - Normal annuity method. On import: Can not be modified if depreciation method is already linked to an asset. For Belgium &amp; Luxembourg the degressive percentage is calculated as double of the linear percentage</summary>
        public double? Percentage { get; set; }
        /// <summary>Linear percentage for methods: 10 - Degressive to linear, 3 - Linear depreciation (Belgium &amp; Luxembourg only), 12 - Degressive to linear (Belgium &amp; Luxembourg only). On import: Can not be modified if depreciation method is already linked to an asset</summary>
        public double? Percentage2 { get; set; }
        /// <summary>The total number of periods for the depreciation method. Used in combination with depreciation interval: only used when interval is periodic</summary>
        public short? Periods { get; set; }
        /// <summary>The actual type of deprecation, such as lineair or degressive. The periodic amounts are based on this type, in combination with other fields, such as the interval and the periods</summary>
        public int? Type { get; set; }
        /// <summary>Description of Type</summary>
        public string TypeDescription { get; set; }
        /// <summary>Determines the total number of years for the depreciation method. Used in combination with depreciation interval: only used when interval is yearly</summary>
        public short? Years { get; set; }
        /// <summary>
        /// Describes the periodic interval
        /// </summary>
        public string DepreciationInterval { get; set; }
    }
}