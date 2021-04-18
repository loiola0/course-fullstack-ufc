using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Domains.Services;
using backend.Domains.Models;
using backend.Resources;
using AutoMapper;

namespace backend.Controllers
{

    [Route("/api/[controller]")]
    
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService user,IMapper mapper){
            _userService = user;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResource>> GetAllAsync(){
            var companies = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>,IEnumerable<UserResource>>(companies);
            return resources;
        }

    }
}