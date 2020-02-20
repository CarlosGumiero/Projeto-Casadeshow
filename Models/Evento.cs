using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Casadeshow.Models
{
    public class Evento
    {
        [Required]
        [Key]
        public int EventoId {get; set;}
        
        [Required(ErrorMessage="Campo obrigatório.")]
        public string Nome {get; set;}
        public int Capacidade {get; set;}
        public float PrecoIngresso {get; set;}
        public CasaDeShow CasaDeShow {get; set;}

        [DisplayFormat (DataFormatString="{0:dd/mm/yyyy HH:mm}")]
        public DateTime Data {get; set;}
        public int QtdIngresso {get; set;}
        public Genero Genero {get; set;}
        public byte[] Foto {get; set;}

    }
}