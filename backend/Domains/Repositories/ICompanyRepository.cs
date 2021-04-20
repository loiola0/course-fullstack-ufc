using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domains.Models;

namespace backend.Domains.Repositories
{
    public interface ICompanyRepository
    {
         Task<IEnumerable<Company>> ListAsync();

         Task AddAsync(Company company);

         Task<Company> FindByIdAsync(int id);

         void Update(Company company);

    }
}