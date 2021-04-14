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
    public class PurchaseController : Controller
    {
        public readonly IPurchaseService _purchase;

        public PurchaseController(IPurchaseService purchase){
            _purchase = purchase;
        }

        public async Task<IEnumerable<Purchase>> GetListAll(){
            var purchases = await _purchase.ListAsync();
            return purchases;
        }

    }
}