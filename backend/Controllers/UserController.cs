using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Domains.Services;
using backend.Domains.Models;


namespace backend.Controllers
{

    [Route("/api/[controller]")]
    
    public class UserController : Controller
    {
        private readonly IUserService _user;

        public UserController(IUserService user){
            _user = user;
        }

        public async Task<IEnumerable<User>> GetListAll(){
            var users = await _user.ListAsync();
            return users;
        }

    }
}