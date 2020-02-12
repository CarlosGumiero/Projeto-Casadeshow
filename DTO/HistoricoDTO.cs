using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Casadeshow.DTO
{
    public class HistoricoDTO
    {
        [Required]
        public int HistoricoId {get; set;}
        public int User {get; set;}
        [Required]
        public int Evento {get; set;}
    }
}