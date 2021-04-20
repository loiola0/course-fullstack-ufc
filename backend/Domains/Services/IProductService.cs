using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;
using backend.Domains.Services.Communication;
namespace backend.Domains.Services
{
    public interface IProductService
    {
         Task<IEnumerable<Product>> ListAsync();
         Task<SaveProductResponse> SaveAsync(Product product);

         Task<SaveProductResponse> UpdateAsync(int id,Product product);

         
    }
}