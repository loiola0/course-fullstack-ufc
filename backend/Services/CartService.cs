using System.Threading.Tasks;
using System.Collections.Generic;
using backend.Domains.Services;
using backend.Domains.Repositories;
using backend.Domains.Models;

namespace backend.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
  

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
            
        }
        
        public async Task<IEnumerable<Cart>> FindByPurchaseIdAsync(int id)
        {
            return await _cartRepository.FindByPurchaseIdAsync(id);
        }
    }
}