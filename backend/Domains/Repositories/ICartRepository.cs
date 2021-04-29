using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;

namespace backend.Domains.Repositories
{
    public interface ICartRepository
    {
         
        public Task<IEnumerable<Cart>> FindByPurchaseIdAsync(int id);

    }
}