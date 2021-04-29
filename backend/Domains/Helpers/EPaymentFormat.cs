using System.ComponentModel;
namespace backend.Domains.Helpers
{
    public enum EPaymentFormat
    {
        [Description("CC")]
        CreditCard = 1,
        
        [Description("DC")]
        DebitCard = 2,
        
        [Description("BB")]
        BankingBillet = 3
    }
}