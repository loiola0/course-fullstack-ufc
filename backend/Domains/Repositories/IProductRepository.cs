using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domains.Models;

namespace backend.Domains.Repositories
{
    public interface IProductRepository
    {
         Task<IEnumerable<Product>> ListAsync();
         Task AddAsync(Product product);
    }
}