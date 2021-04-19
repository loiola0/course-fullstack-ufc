using System.ComponentModel.DataAnnotations;


namespace backend.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(60)]
        public string Name {get;set;}

        [Required]
        [MaxLength(100)]
        public string Email {get;set;}

        [Required]
        public string Password {get;set;}

        [Required]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Number of document invalid!.")]
        public string Cpf {get;set;}
        
    }
}