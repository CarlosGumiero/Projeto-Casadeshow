using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Casadeshow.Models
{
    public class Historico
    {
        [Required]
        [Key]
        public int HistoricoId {get; set;}
        public IdentityUser User {get; set;}
        public Compra Compra {get; set;}
    }
}