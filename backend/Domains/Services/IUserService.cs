using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;
using backend.Domains.Services.Communication;
namespace backend.Domains.Services
{
    public interface IUserService
    {
        
        Task<IEnumerable<User>> ListAsync();

        Task<IEnumerable<SaveUserResponse>> SaveAsync(User user);

    }
}