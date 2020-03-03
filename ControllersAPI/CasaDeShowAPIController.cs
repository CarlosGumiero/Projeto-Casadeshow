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
    public class CasaDeShowAPIController : ControllerBase
    {
        private readonly Data.ApplicationDbContext database;
        private Hateoas.Hateoas Hateoas;

        public CasaDeShowAPIController(ApplicationDbContext database)
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
            var casadeshows = database.CasaDeShow.ToList();
            List<CasaDeShowContainer> casadeshowsHateoas = new List<CasaDeShowContainer>();
            foreach (var casa in casadeshows)
            {
                CasaDeShowContainer casaHateoas = new CasaDeShowContainer();
                casaHateoas.casadeshow = casa;
                casaHateoas.links = Hateoas.GetActions(casa.CasaDeShowId.ToString());
                casadeshowsHateoas.Add(casaHateoas);
            }
            return Ok(casadeshowsHateoas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                CasaDeShow casadeshow = database.CasaDeShow.First(x => x.CasaDeShowId == id);
                CasaDeShowContainer casadeshowHateoas = new CasaDeShowContainer();
                casadeshowHateoas.casadeshow = casadeshow;
                casadeshowHateoas.links = Hateoas.GetActions(casadeshow.CasaDeShowId.ToString());
                return Ok(casadeshowHateoas);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CasaTemp ctemp)
        {
            // validation
            if (ctemp.Nome.Length <= 3)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Nome precisa de mais de 3 caracteres." });
            }

            if (ctemp.Endereco.Length <= 3)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Endereço precisa de mais de 3 caracteres." });
            }

            CasaDeShow c = new CasaDeShow();

            c.Nome = ctemp.Nome;
            c.Endereco = ctemp.Endereco;
            database.CasaDeShow.Add(c);
            database.SaveChanges();

            Response.StatusCode = 201;
            return new ObjectResult("");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                CasaDeShow casadeshow = database.CasaDeShow.First(x => x.CasaDeShowId == id);
                database.CasaDeShow.Remove(casadeshow);
                database.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] CasaDeShow casadeshow)
        {
            if (casadeshow.CasaDeShowId > 0)
            {
                try
                {
                    var c = database.CasaDeShow.First(x => x.CasaDeShowId == casadeshow.CasaDeShowId);

                    if (c != null)
                    {
                        if (casadeshow.Nome.Length <= 3)
                        {
                            Response.StatusCode = 400;
                            return new ObjectResult(new { msg = "Nome precisa de mais de 3 caracteres." });
                        }

                        if (casadeshow.Endereco.Length <= 3)
                        {
                            Response.StatusCode = 400;
                            return new ObjectResult(new { msg = "Endereço precisa de mais de 3 caracteres." });
                        }
                        //Editar
                        c.Nome = casadeshow.Nome != null ? casadeshow.Nome : c.Nome;
                        c.Endereco = casadeshow.Endereco != null ? casadeshow.Endereco : c.Endereco;

                        database.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        Response.StatusCode = 400;
                        return new ObjectResult(new { msg = "Produto não encontrado" });
                    }
                }
                catch
                {
                    Response.StatusCode = 400;
                    return new ObjectResult(new { msg = "Produto não encontrado" });
                }
            }
            else
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Id do produto é inválido" });
            }
        }

        public class CasaTemp
        {
            public int CasaDeShowId { get; set; }
            public string Nome { get; set; }
            public string Endereco { get; set; }
        }

        public class CasaDeShowContainer
        {
            public CasaDeShow casadeshow { get; set; }
            public Link[] links { get; set; }
        }
    }
}