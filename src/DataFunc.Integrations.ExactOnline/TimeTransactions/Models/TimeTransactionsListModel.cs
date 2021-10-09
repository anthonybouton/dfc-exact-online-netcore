using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Attributes;

namespace DataFunc.Integrations.ExactOnline.TimeTransactions.Models
{
    [ExactOnlineResource("/api/v1/{0}/project/TimeTransactions")]
    public class TimeTransactionsListModel
    {
        /// <summary>Account linked to the transaction</summary>
        public Guid? Account { get; set; }
        /// <summary>Date</summary>
        public DateTime? Date { get; set; }
        /// <summary>Employee linked to the transaction</summary>
        public Guid? Employee { get; set; }
        /// <summary>End time of the transaction</summary>
        public DateTime? EndTime { get; set; }
        /// <summary>Status of the transaction</summary>
        public short? HourStatus { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Item linked to the transaction. Items of type &apos;time&apos; are linked to time transactions. Items of other types are linked to cost transactions</summary>
        public Guid? Item { get; set; }
        /// <summary>Project linked to the transaction</summary>
        public Guid? Project { get; set; }
        /// <summary>Start time of the transaction</summary>
        public DateTime? StartTime { get; set; }
        /// <summary>Subscription linked to the transaction</summary>
        /// <summary>Type of the transaction</summary>
        public short? Type { get; set; }
    }
}