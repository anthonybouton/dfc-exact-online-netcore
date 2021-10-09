using System.ComponentModel;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Filters
{
    public enum OdataStringFunction
    {
        [Description("trim")]
        Trim,
        [Description("toupper")]
        ToUpper,
        [Description("tolower")]
        ToLower,
        [Description("length")]
        Length
        
    }
}