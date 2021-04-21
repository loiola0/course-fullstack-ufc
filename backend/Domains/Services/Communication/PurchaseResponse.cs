using backend.Domains.Models;

namespace backend.Domains.Services.Communication
{
    public class PurchaseResponse : BaseResponse
    {
        
        public Purchase Purchase {get;private set;}

        private PurchaseResponse(bool success,string message, Purchase _purchase) : base(success,message){
            Purchase = _purchase;
        }

        public PurchaseResponse(Purchase purchase) : this(true,string.Empty,purchase){}

        public PurchaseResponse(string message) : this(false,message,null){}



    }
}