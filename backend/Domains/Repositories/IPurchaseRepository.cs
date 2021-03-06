using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domains.Models;

namespace backend.Domains.Repositories
{
    public interface IPurchaseRepository
    {
         Task<IEnumerable<Purchase>> ListAsync();

         Task AddAsync(Purchase purchase);

         Task<Purchase> FindByIdAsync(int id);

         void Update(Purchase purchase);

         void Remove(Purchase purchase);

    }
}