using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;

namespace backend.Domains.Services
{
    public interface IUserService
    {
        
        Task<IEnumerable<User>> ListAsync();

    }
}