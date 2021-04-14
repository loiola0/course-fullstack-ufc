using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;

namespace backend.Domains.Services
{
    public interface IProductService
    {
         Task<IEnumerable<Product>> ListAsync();
    }
}