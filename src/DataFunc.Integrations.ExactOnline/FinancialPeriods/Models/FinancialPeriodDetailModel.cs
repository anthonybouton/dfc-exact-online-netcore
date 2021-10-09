using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.FinancialPeriods.Models
{
    [ExactOnlineResource("api/v1/{0}/financial/FinancialPeriods")]
    public class FinancialPeriodDetailModel
    {
        public int Division { get; set; }
        public DateTime EndDate { get; set; }
        public int FinPeriod { get; set; }
        public int FinYear { get; set; }
        [ExactOnlinePrimaryKey]
        public Guid ID { get; set; }
        public DateTime StartDate { get; set; }
    }
}