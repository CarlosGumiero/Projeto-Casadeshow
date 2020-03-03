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
    public class GeneroAPIController : ControllerBase
    {
        private readonly Data.ApplicationDbContext database;
        private Hateoas.Hateoas Hateoas;

        public GeneroAPIController(ApplicationDbContext database)
        {
            this.database = database;
            Hateoas = new Hateoas.Hateoas("localhost:5001/casadeshow/v1/GeneroAPI");
            Hateoas.AddAction("GET_INFO", "GET");
            Hateoas.AddAction("DELETE_PRODUCT", "DELETE");
            Hateoas.AddAction("EDIT_PRODUCT", "PATCH");

        }

        [HttpGet]
        public IActionResult Get()
        {
            var genero = database.Genero.ToList();
            List<GeneroContainer> generosHateoas = new List<GeneroContainer>();
            foreach (var gen in genero)
            {
                GeneroContainer generoHateoas = new GeneroContainer();
                generoHateoas.genero = gen;
                generoHateoas.links = Hateoas.GetActions(gen.GeneroId.ToString());
                generosHateoas.Add(generoHateoas);
            }
            return Ok(generosHateoas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Genero genero = database.Genero.First(x => x.GeneroId == id);
                GeneroContainer generoHateoas = new GeneroContainer();
                generoHateoas.genero = genero;
                generoHateoas.links = Hateoas.GetActions(genero.GeneroId.ToString());
                return Ok(generoHateoas);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] GeneroTemp gtemp)
        {
            // validation
            if (gtemp.Nome.Length <= 3)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Nome precisa de mais de 3 caracteres." });
            }

            Genero g = new Genero();

            g.Nome = gtemp.Nome;
            database.Genero.Add(g);
            database.SaveChanges();

            Response.StatusCode = 201;
            return new ObjectResult("");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Genero genero = database.Genero.First(x => x.GeneroId == id);
                database.Genero.Remove(genero);
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
        public IActionResult Patch([FromBody] Genero genero)
        {
            if (genero.GeneroId > 0)
            {
                try
                {
                    var g = database.Genero.First(x => x.GeneroId == genero.GeneroId);

                    if (g != null)
                    {
                        if (genero.Nome.Length <= 3)
                        {
                            Response.StatusCode = 400;
                            return new ObjectResult(new { msg = "Nome precisa de mais de 3 caracteres." });
                        }

                        //Editar
                        g.Nome = genero.Nome != null ? genero.Nome : g.Nome;

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
    }

    public class GeneroTemp
        {
            public int GeneroId { get; set; }
            public string Nome { get; set; }
        }

        public class GeneroContainer
        {
            public Genero genero { get; set; }
            public Link[] links { get; set; }
        }
}