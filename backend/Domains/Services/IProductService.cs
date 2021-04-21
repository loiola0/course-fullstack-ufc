using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;
using backend.Domains.Services.Communication;
namespace backend.Domains.Services
{
    public interface IProductService
    {
         Task<IEnumerable<Product>> ListAsync();
         Task<ProductResponse> SaveAsync(Product product);

         Task<ProductResponse> UpdateAsync(int id,Product product);

         
         Task<ProductResponse> DeleteAsync(int id);

    }
}