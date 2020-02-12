using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Casadeshow.DTO
{
    public class EventoDTO
    {
        [Required]
        public int EventoId {get; set;}
        
        [Required(ErrorMessage="Campo obrigatório.")]
        public string Nome {get; set;}

        [Required]
        public int Capacidade {get; set;}

        [Required]
        public float PrecoIngresso {get; set;}

        [Required]
        public int CasaDeShow {get; set;}

        [Required]
        [DisplayFormat (DataFormatString="{0:dd/mm/yyyy HH:mm}")]
        public DateTime Data {get; set;}

        [Required]
        public int QtdIngresso {get; set;}

        [Required]
        public int Genero {get; set;}
    }
}