using System;
using System.Linq;
using Casadeshow.Data;
using Casadeshow.Models;
using Microsoft.AspNetCore.Mvc;
using Casadeshow.Hateoas;
using System.Collections.Generic;

namespace Casadeshow.ControllersAPI
{
    [Route("casadeshow/v1/[controller]")]
    [ApiController]
    public class EventoAPIController : ControllerBase
    {
        private readonly Data.ApplicationDbContext database;
        private Hateoas.Hateoas Hateoas;

        public EventoAPIController(ApplicationDbContext database)
        {
            this.database = database;
            Hateoas = new Hateoas.Hateoas("localhost:5001/casadeshow/v1/CasaDeShowAPI");
            Hateoas.AddAction("GET_INFO", "GET");
            Hateoas.AddAction("DELETE_PRODUCT", "DELETE");
            Hateoas.AddAction("EDIT_PRODUCT", "PATCH");

        }

        [HttpGet]
        public IActionResult Get()
        {
            database.CasaDeShow.ToList();
            database.Genero.ToList();
            var eventos = database.Evento.ToList();

            List<EventoContainer> eventosHateoas = new List<EventoContainer>();

            foreach (var eve in eventos)
            {
                EventoContainer eventoHateoas = new EventoContainer();
                eventoHateoas.evento = eve;
                eventoHateoas.links = Hateoas.GetActions(eve.EventoId.ToString());
                eventosHateoas.Add(eventoHateoas);
            }
            return Ok(eventosHateoas);
        }
    }

    public class EventoTemp
    {
        public int EventoId { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public float PrecoIngresso { get; set; }
        public CasaDeShow CasaDeShow { get; set; }
        public DateTime Data { get; set; }
        public int QtdIngresso { get; set; }
        public Genero Genero { get; set; }
        public byte[] Foto { get; set; }

    }

    public class EventoContainer
    {
        public Evento evento { get; set; }
        public Link[] links { get; set; }
    }
}