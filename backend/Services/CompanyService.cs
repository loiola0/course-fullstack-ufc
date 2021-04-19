using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;
using backend.Domains.Services;

namespace backend.Services
{
    public class CompanyService : ICompanyService
    {

        public readonly ICompanyService _companyService;

        public CompanyService(ICompanyService companyService){
            _companyService = companyService;
        }

        public async Task<IEnumerable<Company>> ListAsync(){
            return await _companyService.ListAsync();
        }
        
    }
}