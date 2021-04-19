using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using backend.Domains.Helpers;
using backend.Domains.Models;

namespace backend.Resources
{
    public class SavePurchaseResource
    {
        
        [Required]
        public float Value {get;set;}

        [Required]
        public DateTime Date {get;set;}

        [Required]
        public EPaymentFormat PaymentFormat {get;set;}

        [Required]
        public EPurchaseStatus Status {get;set;}

        [Required]
        public string Note {get;set;}

        [Required]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Zip code invalid!")]
        public string Cep { get; set; }

        [Required]
        public string Address {get;set;}
        
        [Required]
        public int IdUser { get; set; }
        [Required]
        public IList<Product> Products { get; set; }


    }
}