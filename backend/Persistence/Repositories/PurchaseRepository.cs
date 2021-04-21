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
    public class PurchaseRepository : BaseRepository, IPurchaseRepository
    {
        public PurchaseRepository(AppDbContext context) : base(context){}

        public async Task<IEnumerable<Purchase>> ListAsync(){
            return await _context.Purchases.ToListAsync();
        }

        public async Task AddAsync(Purchase purchase){
            await _context.Purchases.AddAsync(purchase);
        }

        public async Task<Purchase> FindByIdAsync(int id){
            return await _context.Purchases.FindAsync(id);
        }

        public void Update(Purchase purchase){
            _context.Purchases.Update(purchase);
        }

        public void Remove(Purchase purchase){
            _context.Purchases.Remove(purchase);
        }

        
    }
}