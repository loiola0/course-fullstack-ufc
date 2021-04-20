using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Domains.Services;
using backend.Domains.Models;
using backend.Resources;
using backend.Extensions;
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


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource){
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<SaveProductResource,Product>(resource);
            var result = await _productService.SaveAsync(product);

            if(!result.Success)
                return BadRequest(result.Message);

            var productResource = _mapper.Map<Product,ProductResource>(result.Product);
            
            return Ok(productResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id,[FromBody] SaveProductResource resource){
            if(!ModelState.IsValid){
                return BadRequest(ModelState.GetErrorMessages());
            }

            var product = _mapper.Map<SaveProductResource,Product>(resource);
            var result = await _productService.UpdateAsync(id,product);

            if(!result.Sucess){
                return BadRequest(result.Message);
            }

            var productResource = _mapper.Map<Product,ProductResource>(result.Product);

            return Ok(productResource);
        }
        
    }
}