using System.Collections.Generic;

namespace backend.Domains.Models
{
    public class Company
    {
        public int Id {get;set;}
        public string FantasyName {get;set;}
        public string CompanyName {get;set;}
        public string Cnpj {get;set;}

        public IList<Product> Products {get;set;}

    }
}