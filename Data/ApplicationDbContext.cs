using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Casadeshow.Models;

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
        public DbSet<Casadeshow.Models.Historico> Historico { get; set; }

    }
}
