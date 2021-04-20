using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;
using backend.Domains.Services.Communication;
namespace backend.Domains.Services
{
    public interface IPurchaseService
    {
         Task<IEnumerable<Purchase>> ListAsync();

         Task<SavePurchaseResponse> SaveAsync(Purchase purchase);

         

    }
}