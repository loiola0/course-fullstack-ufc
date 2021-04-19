using backend.Domains.Models;

namespace backend.Domains.Services.Communication
{
    public class SaveProductResponse : BaseResponse
    {
        
        public Product Product {get;private set;}

        private SaveProductResponse(bool success,string message, Product _product) : base(success,message){
            Product = _product;
        }

        public SaveProductResponse(Product product) : this(true,string.Empty,product){}

        public SaveProductResponse(string message) : this(false,message,null){}



    }
}