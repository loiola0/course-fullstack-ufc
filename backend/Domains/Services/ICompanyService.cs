using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;
using backend.Domains.Services.Communication;


namespace backend.Domains.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> ListAsync();

        Task<SaveCompanyResponse> SaveAsync(Company company);
        
    }
}