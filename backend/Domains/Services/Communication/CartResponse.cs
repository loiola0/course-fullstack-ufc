using System;
using System.Collections.Generic;
using backend.Domains.Models;

namespace backend.Domains.Services.Communication
{
    public class CartResponse: BaseResponse
    {
        public Cart cart { get; set; }
        
        public CartResponse(string message, bool success, Cart _cart) : base(success, message)
        {
            cart = _cart;
        }

        public CartResponse(Cart _cart) : this(String.Empty,true,_cart)
        {
            
        }

        public CartResponse(string message) : this(message, false, null)
        {
            
        }
        
    }
}