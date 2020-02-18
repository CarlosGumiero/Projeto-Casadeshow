using System;
using System.ComponentModel.DataAnnotations;

namespace Casadeshow.Models
{
    public class Compra
    {
        public int CompraId {get; set;}
        public DateTime Data {get; set;}
        public int QtdIngressos {get; set;}
        public float Total {get; set;}
        public Evento Evento {get; set;}
    }
}