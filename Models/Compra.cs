using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Casadeshow.Models
{
    public class Compra
    {
        public int CompraId {get; set;}
        public DateTime Data {get; set;}

        [Range(1, int.MaxValue, ErrorMessage = "Número de ingressos inválido!")]
        public int QtdIngressos {get; set;}
        public float Total {get; set;}
        public Evento Evento {get; set;}
        public IdentityUser IdentityUser {get; set;}
    }
}