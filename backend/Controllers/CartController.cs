using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.Domains.Models;
using backend.Domains.Services;
using backend.Resources;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("/api/[controller]")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public CartController(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var items = await _cartService.FindByPurchaseIdAsync(id);
            var resource = _mapper.Map<IEnumerable<Cart>, IEnumerable<CartResource>>(items);
            return Ok(resource);
        }
    }
}