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
    public class CompanyController : Controller
    {

        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService,IMapper mapper){
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CompanyResource>> GetAllAsync(){
            var companies = await _companyService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Company>,IEnumerable<CompanyResource>>(companies);
            return resources;
        }
        
    }
}