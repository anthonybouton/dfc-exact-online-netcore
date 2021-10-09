using DataFunc.Integrations.ExactOnline.Infrastructure.Filters;
using DataFunc.Integrations.ExactOnline.Projects.Models;
using NUnit.Framework;

namespace DataFunc.Integrations.ExactOnline.Tests.Filters
{
    [TestFixture]
    public class StringFilterTestFixture
    {

        [Test]
        [TestCase("ID", OdataOperator.Equal, "HEY", "ID eq 'HEY'")]
        [TestCase("UserID", OdataOperator.NotEqual, "HEY", "UserID ne 'HEY'")]
        public void EnsureFilterIsCorrectlyAdded(string propertyName, OdataOperator toUseOperator, string propertyValue, string expectedFilter)
        {
            var filter = new OdataSinglePropertyFilter(propertyName, toUseOperator, propertyValue);
            Assert.AreEqual(expectedFilter, filter.Evaluate());
        }

        [Test]
        [TestCase("ID", OdataOperator.Equal, "HEY", "trim(ID) eq 'HEY'", OdataStringFunction.Trim)]
        [TestCase("UserID", OdataOperator.NotEqual, "HEY", "toupper(UserID) ne 'HEY'", OdataStringFunction.ToUpper)]
        public void EnsureFunctionIsCorrectlyAdded(string propertyName, OdataOperator toUseOperator, string propertyValue, string expectedFilter, OdataStringFunction function)
        {
            var filter = new OdataSinglePropertyFilter(propertyName, toUseOperator, propertyValue, function);
            Assert.AreEqual(expectedFilter, filter.Evaluate());
        }

    }
}