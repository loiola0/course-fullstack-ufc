using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Resources
{
    public class SaveCompanyResource
    {
        [Required]
        [MaxLength(60)]
        public string CompanyName {get;set;}

        [Required]
        [MaxLength(60)]
        public string FantasyName {get;set;}

        [RegularExpression(@"^[0-9]{14}$",ErrorMessage = "Number of document invalid!.")]
        public string Cnpj {get;set;}
        
    }
}