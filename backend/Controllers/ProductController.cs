using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Domains.Services;
using backend.Domains.Models;
using backend.Resources;
using AutoMapper;

namespace backend.Controllers
{

    [Route("/api/[controller]")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,IMapper mapper){
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllAsync(){
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>,IEnumerable<ProductResource>>(products);
            return resources;
        }
        
    }
}