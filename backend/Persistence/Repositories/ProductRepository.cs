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
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context){}

        public async Task<IEnumerable<Product>> ListAsync(){
            return await _context.Products.ToListAsync();
        }

        public async Task AddAsync(Product product){
            await _context.Products.AddAsync(product);
        }

        public async Task<Product> FindByIdAsync(int id){
            return await _context.Products.FindAsync(id);
        }

        public void Update(Product product){
            _context.Products.Update(product);
        }

    }
}