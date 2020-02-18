using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Casadeshow.Data;
using Casadeshow.Models;
using Casadeshow.DTO;

namespace Casadeshow.Controllers
{
    public class CompraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompraController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Compra(int? id)
        {
            var evento = _context.Evento.ToList();

            Compra buy = new Compra();
            buy.Evento = _context.Evento.First(c => c.EventoId == id);

            return View(buy);
        }


    }
}