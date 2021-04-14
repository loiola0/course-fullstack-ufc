using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;
using backend.Domains.Services;

namespace backend.Services
{
    public class PurchaseService : IPurchaseService
    {

        public readonly IPurchaseService _purchaseService;

        public PurchaseService(IPurchaseService purchaseService){
            _purchaseService = purchaseService;
        }

        public async Task<IEnumerable<Purchase>> ListAsync(){
            return await _purchaseService.ListAsync();
        }
    }
}