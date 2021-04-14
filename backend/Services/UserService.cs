using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;
using backend.Domains.Services;

namespace backend.Services
{
    public class UserService : IUserService
    {

        public readonly IUserService _userService;

        public UserService(IUserService userService){
            _userService = userService;
        }

        public async Task<IEnumerable<User>> ListAsync(){
            return await _userService.ListAsync();
        }
    }
}