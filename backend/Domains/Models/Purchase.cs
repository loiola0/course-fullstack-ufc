using System;

using backend.Domains.Helpers;

namespace backend.Domains.Models
{
    public class Purchase
    {
        public int Id {get;set;}
        public float Value {get;set;}
        public DateTime Date{get;set;}
        public EPaymentFormat PaymentFormat {get;set;}
        public EPurchaseStatus Status {get;set;}
        public string Note {get;set;}
        public string Cep {get;set;}
        public string Address {get;set;}
        public string UserId {get;set;}


    }
}