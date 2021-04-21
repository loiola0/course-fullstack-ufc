using backend.Domains.Models;

namespace backend.Domains.Services.Communication
{
    public class ProductResponse : BaseResponse
    {
        
        public Product Product {get;private set;}

        private ProductResponse(bool success,string message, Product _product) : base(success,message){
            Product = _product;
        }

        public ProductResponse(Product product) : this(true,string.Empty,product){}

        public ProductResponse(string message) : this(false,message,null){}



    }
}