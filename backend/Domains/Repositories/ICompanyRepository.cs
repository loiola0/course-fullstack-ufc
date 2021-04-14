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
    }
}