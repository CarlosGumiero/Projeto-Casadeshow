using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Casadeshow.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Casadeshow.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Casadeshow.Models.CasaDeShow> CasaDeShow { get; set; }
        public DbSet<Casadeshow.Models.Evento> Evento { get; set; }
        public DbSet<Casadeshow.Models.Genero> Genero { get; set; }
        public DbSet<Casadeshow.Models.Compra> Compra { get; set; }
    }
}
