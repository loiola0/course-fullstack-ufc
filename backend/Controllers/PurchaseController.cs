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
    public class PurchaseController : Controller
    {
        public readonly IPurchaseService _purchaseService;
        public readonly IMapper _mapper;

        public PurchaseController(IPurchaseService purchase,IMapper mapper){
            _purchaseService = purchase;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PurchaseResource>> GetListAll(){
            var purchases = await _purchaseService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Purchase>,IEnumerable<PurchaseResource>>(purchases);
            return resources;
        }

    }
}