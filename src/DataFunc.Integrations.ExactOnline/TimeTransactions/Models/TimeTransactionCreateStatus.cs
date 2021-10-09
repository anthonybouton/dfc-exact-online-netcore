namespace DataFunc.Integrations.ExactOnline.TimeTransactions.Models
{
    public enum TimeTransactionCreateStatus
    {
    Draft = 1, 
    Rejected = 2,
    Submitted = 10,
    Processing = 16,
    Failed = 19,
    Final = 20
    }
}