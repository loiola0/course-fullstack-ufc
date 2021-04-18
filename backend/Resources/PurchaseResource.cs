using System;

namespace backend.Resources
{
    public class PurchaseResource
    {
        public int Id {get;set;}
        public float value {get;set;}
        public DateTime Date {get;set;}
        public string Note {get;set;}
        public string Cep {get;set;}
        public string Address {get;set;}
        public string PaymentFormat {get;set;}
        public string Status {get;set;}
    }
}