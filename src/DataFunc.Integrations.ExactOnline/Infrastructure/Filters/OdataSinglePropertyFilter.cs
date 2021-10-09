using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Extensions;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Filters
{
    public class OdataSinglePropertyFilter : IOdataFilter
    {
        private readonly string _propertyName;
        private readonly OdataOperator _odataOperator;
        private readonly OdataStringFunction? _function;
        private readonly string _filterValue;
        public OdataSinglePropertyFilter(string propertyName, OdataOperator odataOperator, string filterValue, OdataStringFunction? function = null)
        {
            _propertyName = propertyName;
            _odataOperator = odataOperator;
            _function = function;
            _filterValue = $"'{filterValue}'";
        }

        public OdataSinglePropertyFilter(string propertyName, OdataOperator odataOperator, Guid filterValue) : this(propertyName, odataOperator, filterValue.ToString())
        {
            _filterValue = $"guid'{filterValue}'";
        }

        public OdataSinglePropertyFilter(string propertyName, OdataOperator odataOperator, bool filterValue) : this(propertyName, odataOperator, filterValue.ToString())
        {
            _filterValue = filterValue ? "true" : "false";
        }

        public OdataSinglePropertyFilter(string propertyName, OdataOperator odataOperator, int filterValue) : this(propertyName, odataOperator, filterValue.ToString())
        {
            _filterValue = filterValue.ToString();
        }
        public OdataSinglePropertyFilter(string propertyName, OdataOperator odataOperator, long filterValue) : this(propertyName, odataOperator, filterValue.ToString())
        {
            _filterValue = filterValue.ToString();
        }
        public virtual string Evaluate()
        {
            var propertyName = _function.HasValue ? $"{_function.Value.GetCustomAttributeDescription()}({_propertyName})" : _propertyName;
            return $"{propertyName} {_odataOperator.GetCustomAttributeDescription()} {_filterValue}";
        }
    }
}