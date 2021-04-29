namespace backend.Domains.Models
{
    public class Product
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public float Value {get;set;}
        public string Note {get;set;}
        public int CompanyId {get;set;}
        public Company Company {get;set;}

    }
}