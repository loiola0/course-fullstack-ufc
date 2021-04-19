using System.ComponentModel.DataAnnotations;

namespace backend.Resources
{
    public class SaveProductResource
    {

        [Required]
        [MaxLength(60)]
        public string Name {get;set;}

        [Required]
        public string Description {get;set;}

        [Required]
        public float Value {get;set;}

        [Required]
        public string Note {get;set;}

        [Required]
        public int IdCompany {get;set;}
        
    }
}