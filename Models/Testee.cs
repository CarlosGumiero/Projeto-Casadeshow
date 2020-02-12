using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Casadeshow.Models
{
    public class Testee    
    {
        [Key]
        [Required]
        public int ImajId {get; set;}
        public string Nome {get; set;}
        public byte[] Foto {get; set;}
    }
}