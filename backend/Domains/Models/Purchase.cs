using System;

using backend.Domains.Helpers;

namespace backend.Domains.Models
{
    public class Purchase
    {
        public int Id {get;set;}
        public float Value {get;set;}
        public DateTime date{get;set;}
        public EPaymentFormat paymentFormat {get;set;}
        public EPurchaseStatus Status {get;set;}
        public string Note {get;set;}
        public string Cep {get;set;}
        public string address {get;set;}


    }
}