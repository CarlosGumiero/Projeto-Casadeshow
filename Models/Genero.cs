using System.ComponentModel.DataAnnotations;

namespace Casadeshow.Models
{
    public class Genero
    {
        [Required]
        [Key]
        public int GeneroId {get; set;}

        [Required(ErrorMessage="Campo obrigatório.")]
        public string Nome {get; set;}
    }
}