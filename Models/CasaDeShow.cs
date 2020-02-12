using System.ComponentModel.DataAnnotations;

namespace Casadeshow.Models
{
    public class CasaDeShow
    {
        [Required]
        [Key]
        public int CasaDeShowId {get; set;}

        [Required(ErrorMessage="Campo obrigatório.")]
        [StringLength(100, ErrorMessage="Nome excede o limite de 100 caracteres.")]
        [MinLength(2, ErrorMessage="Endereço nao possui o mínimo de 2 caracteres.")]
        public string Nome {get; set;}

        [Required(ErrorMessage="Campo obrigatório.")]
        [StringLength(100, ErrorMessage="Endereço excede o limite de 100 caracteres.")]
        [MinLength(2, ErrorMessage="Endereço nao possui o mínimo de 2 caracteres.")]
        public string Endereco {get; set;}
    }
}