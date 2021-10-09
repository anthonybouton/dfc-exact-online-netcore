using System;
using DataFunc.Integrations.ExactOnline.TimeTransactions.Models;

namespace DataFunc.Integrations.ExactOnline.TimeTransactions.Infrastructure
{
    public class TimeTransactionCreateRequest
    {
  
        public Guid Employee { get; set; }
        public Guid Item { get; set; }
        public Guid Project { get; set; }
        public double? Quantity { get; set; }
        public int HourStatus { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; internal set; }
        public DateTime? EndTime { get; internal set; }
        public string Notes { get; set; }


        /// <summary>
        /// Sets the start and endtime and calculated the quantity based on the difference
        /// This method does not modify the date property
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void RegisterTime(DateTime start, DateTime end)
        {
            StartTime = start;
            EndTime = end;

            var differenceInMinutes = Math.Abs((start - end).TotalMinutes);
            var rounded = $"{Math.Round(differenceInMinutes / 60,2, MidpointRounding.AwayFromZero):0.00}";
            Quantity = Convert.ToDouble(rounded);
        }

    }
}