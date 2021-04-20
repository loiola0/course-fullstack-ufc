using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;
using backend.Domains.Services.Communication;
namespace backend.Domains.Services
{
    public interface IUserService
    {
        
        Task<IEnumerable<User>> ListAsync();

        Task<SaveUserResponse> SaveAsync(User user);

        Task<SaveUserResponse> UpdateAsync(int id,User user);
        

    }
}