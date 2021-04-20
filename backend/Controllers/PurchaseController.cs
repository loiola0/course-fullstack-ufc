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
    public class PurchaseController : Controller
    {
        public readonly IPurchaseService _purchaseService;
        public readonly IMapper _mapper;

        public PurchaseController(IPurchaseService purchase,IMapper mapper){
            _purchaseService = purchase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PurchaseResource>> GetListAll(){
            var purchases = await _purchaseService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Purchase>,IEnumerable<PurchaseResource>>(purchases);
            return resources;
        }

        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePurchaseResource resource){
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var purchase = _mapper.Map<SavePurchaseResource,Purchase>(resource);
            var result = await _purchaseService.SaveAsync(purchase);

            if(!result.Success)
                return BadRequest(result.Message);

            var purchaseResource = _mapper.Map<Purchase,PurchaseResource>(result.Purchase);
            
            return Ok(purchaseResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id,[FromBody] SavePurchaseResource resource){
            if(!ModelState.IsValid){
                return BadRequest(ModelState.GetErrorMessages());
            }

            var purchase = _mapper.Map<SavePurchaseResource,Purchase>(resource);
            var result = await _purchaseService.UpdateAsync(id,purchase);

            if(!result.Success){
                return BadRequest(result.Message);
            }

            var purchaseResource = _mapper.Map<Purchase,PurchaseResource>(result.Purchase);

            return Ok(purchaseResource);
        }

    }
}