using System.ComponentModel;
namespace backend.Domains.Helpers
{
    public enum EPurchaseStatus : byte
    {
        [Description("PAID")]
        Paid = 1,
        
        [Description("OPEN")]
        Open = 2,

        [Description("CANCELLED")]
        Cancelled = 3,


    }
}