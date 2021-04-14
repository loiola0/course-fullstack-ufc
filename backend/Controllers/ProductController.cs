using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Domains.Services;
using backend.Domains.Models;


namespace backend.Controllers
{

    [Route("/api/[controller]")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService){
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetListAll(){
            var products = await _productService.ListAsync();
            return products;
        }
        
    }
}