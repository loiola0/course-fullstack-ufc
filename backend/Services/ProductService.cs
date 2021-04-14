using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;
using backend.Domains.Services;

namespace backend.Services
{
    public class ProductService : IProductService
    {

        public readonly IProductService _productService;

        public ProductService(IProductService productService){
            _productService = productService;
        }

        public async Task<IEnumerable<Product>> ListAsync(){
            return await _productService.ListAsync();
        }
    }
}