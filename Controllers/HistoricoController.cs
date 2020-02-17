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
    public class HistoricoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistoricoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Evento = _context.Evento.ToList();

            return View(await _context.Historico.ToListAsync());
        }

        [HttpPost]
        public IActionResult Create(Historico hist)
        {
            hist.Evento = _context.Evento.First(cs => cs.EventoId == hist.Evento.EventoId);
            _context.Historico.Add(hist);
            ViewBag.Evento = _context.Evento.ToList();

            return View();
        }


        private bool HistoricoExists(int id)
        {
            return _context.Historico.Any(e => e.HistoricoId == id);
        }
    }
}
