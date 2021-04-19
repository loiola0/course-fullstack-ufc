using backend.Domains.Models;

namespace backend.Domains.Services.Communication
{
    public class SavePurchaseResponse : BaseResponse
    {
        
        public Purchase Purchase {get;private set;}

        private SavePurchaseResponse(bool success,string message, Purchase _purchase) : base(success,message){
            Purchase = _purchase;
        }

        public SavePurchaseResponse(Purchase purchase) : this(true,string.Empty,purchase){}

        public SavePurchaseResponse(string message) : this(false,message,null){}



    }
}