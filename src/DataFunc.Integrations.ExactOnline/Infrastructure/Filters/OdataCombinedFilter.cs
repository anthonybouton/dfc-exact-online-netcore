using System.Linq;
using DataFunc.Integrations.ExactOnline.Infrastructure.Extensions;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Filters
{
    public class OdataCombinedFilter : IOdataFilter
    {
        private readonly CombinableOdataOperator _toUseOperator;
        private readonly OdataSinglePropertyFilter[] _toCombineFilters;

        public OdataCombinedFilter(CombinableOdataOperator toUseOperator, params OdataSinglePropertyFilter[] toCombineFilters)

        {
            _toUseOperator = toUseOperator;
            _toCombineFilters = toCombineFilters;
        }


        public string Evaluate()
        {
            return string.Join($" {_toUseOperator.GetCustomAttributeDescription()} ",
                _toCombineFilters.Select(x => x.Evaluate()));
        }
    }
}
