using System;

namespace Casadeshow.Models
{
    public class Saida
    {
        public int SaidaId {get; set;}
        public Evento Evento {get; set;}
        public float ValorDaVenda {get; set;}
        public DateTime Data {get; set;}
    }
}