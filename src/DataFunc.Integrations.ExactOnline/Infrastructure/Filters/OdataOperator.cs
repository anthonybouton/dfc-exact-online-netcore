using System.ComponentModel;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Filters
{
    public enum OdataOperator
    {
        [Description("eq")]
        Equal,
        [Description("ne")]
        NotEqual,
        [Description("gt")]
        GreaterThan,
        [Description("ge")]
        GreaterThanOrEqual,
        [Description("lt")]
        LessThan,
        [Description("le")]
        LessThanOrEqual,
        [Description("not")]
        Not
    }

    public enum CombinableOdataOperator
    {
        [Description("and")]
        And,
        [Description("rr")]
        Or
    }
}