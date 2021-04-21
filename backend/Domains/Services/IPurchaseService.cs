using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;
using backend.Domains.Services.Communication;
namespace backend.Domains.Services
{
    public interface IPurchaseService
    {
         Task<IEnumerable<Purchase>> ListAsync();

         Task<PurchaseResponse> SaveAsync(Purchase purchase);

         Task<PurchaseResponse> UpdateAsync(int id,Purchase purchase);

        Task<PurchaseResponse> DeleteAsync(int id);     

    }
}