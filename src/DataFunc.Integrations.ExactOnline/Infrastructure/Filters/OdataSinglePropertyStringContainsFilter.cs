using System;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Filters
{
    public class OdataSinglePropertyStringContainsFilter : OdataSinglePropertyFilter
    {
        private readonly string _propertyName;
        private readonly string _filterValue;

        public OdataSinglePropertyStringContainsFilter(string propertyName, string filterValue) : base(propertyName, OdataOperator.Equal, filterValue, null)
        {
            _propertyName = propertyName;
            _filterValue = filterValue;
        }

        public OdataSinglePropertyStringContainsFilter(string propertyName, Guid filterValue) : this(propertyName, filterValue.ToString())
        {
        }

        public OdataSinglePropertyStringContainsFilter(string propertyName, int filterValue) : this(propertyName, filterValue.ToString())
        {
        }

        public override string Evaluate()
        {
            return $"contains({_propertyName}, '{_filterValue}')";
        }
    }
}