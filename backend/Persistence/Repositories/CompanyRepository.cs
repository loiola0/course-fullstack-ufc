using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Domains.Repositories;
using backend.Persistence.Contexts;
using backend.Domains.Models;


namespace backend.Persistence.Repositories
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context){}

        public async Task<IEnumerable<Company>> ListAsync(){
            return await _context.Companys.ToListAsync();
        }

        public async Task AddAsync(Company company){
            await _context.Companys.AddAsync(company);
        }

        public async Task<Company> FindByIdAsync(int id){
            return await _context.Companys.FindAsync(id);
        }

        public void Update(Company company){
            _context.Companys.Update(company);
        }

        public void Remove(Company company){
            _context.Companys.Remove(company);
        }

    }
}