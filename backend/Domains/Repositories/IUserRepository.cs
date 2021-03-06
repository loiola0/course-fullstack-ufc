using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domains.Models;


namespace backend.Domains.Repositories
{
    public interface IUserRepository
    {
         Task<IEnumerable<User>> ListAsync();

         Task AddAsync(User user);
         
         Task<User> FindByIdAsync(int id);

         void Update(User user);

         void Remove(User user);

    }
}