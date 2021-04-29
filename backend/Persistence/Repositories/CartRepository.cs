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
    public class CartRepository : BaseRepository,ICartRepository
    {
        public CartRepository(AppDbContext context) : base(context){}

        public async Task<IEnumerable<Cart>> FindByPurchaseIdAsync(int id)
        {
            var itemsByPurchase = _context.Carts.Include(p => p.Product).AsNoTracking();
            var items = await itemsByPurchase.ToListAsync();
            return items.FindAll(p => p.PurchaseId == id);
        }

    }
}