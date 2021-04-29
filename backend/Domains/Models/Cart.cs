namespace backend.Domains.Models
{
    public class Cart
    {
        public int Id {get;set;}
        public int Quantity {get;set;}

        public virtual Product Product {get;set;}
        public int ProductId {get;set;}

        public Purchase Purchase {get;set;}

        public int PurchaseId {get;set;}

    }
}