using System;
using System.ComponentModel.DataAnnotations;
using backend.Resources;

namespace backend.Resources
{
    public class SaveCartResource
    {

        [Required]
        public int Quantity {get;set;}
        [Required]
        public ProductResource Product {get;set;}
    }
}