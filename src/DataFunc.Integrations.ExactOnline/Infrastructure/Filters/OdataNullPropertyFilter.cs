using DataFunc.Integrations.ExactOnline.Infrastructure.Extensions;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Filters
{
    public class OdataNullPropertyFilter : OdataSinglePropertyFilter
    {
        private readonly string _propertyName;
        private readonly OdataOperator _odataOperator;

        private OdataNullPropertyFilter(string propertyName, OdataOperator odataOperator) : base(propertyName, odataOperator,null)
        {
            _propertyName = propertyName;
            _odataOperator = odataOperator;
        }
        public static OdataNullPropertyFilter NotNull(string propertyName)
        {
            return new OdataNullPropertyFilter(propertyName, OdataOperator.NotEqual);
        }
        public static OdataNullPropertyFilter Null(string propertyName)
        {
            return new OdataNullPropertyFilter(propertyName, OdataOperator.Equal);
        }
        public override string Evaluate()
        {
            return $"{_propertyName} {_odataOperator.GetCustomAttributeDescription()} null";
        }

    }
}