using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Domains.Services;
using backend.Domains.Models;
using backend.Resources;
using backend.Extensions;
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

        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync(){
            var companies = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>,IEnumerable<UserResource>>(companies);
            return resources;
        }

        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource){
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUserResource,User>(resource);
            var result = await _userService.SaveAsync(user);

            if(!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User,UserResource>(result.User);
            
            return Ok(userResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id,[FromBody] SaveUserResource resource){
            if(!ModelState.IsValid){
                return BadRequest(ModelState.GetErrorMessages());
            }

            var user = _mapper.Map<SaveUserResource,User>(resource);
            var result = await _userService.UpdateAsync(id,user);

            if(!result.Sucess){
                return BadRequest(result.Message);
            }

            var userResource = _mapper.Map<User,UserResource>(result.User);

            return Ok(userResource);
        }

        

    }
}