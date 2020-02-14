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

        public IActionResult Create()
        {
            ViewBag.Evento = _context.Evento.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         public  async Task<IActionResult> Create(int id, [Bind("HistoricoId,EventoId")] Historico ht)
        {
            if (ModelState.IsValid)
            {
                Historico hist = new Historico();
                hist.HistoricoId = ht.HistoricoId;
                // hist.Evento = _context.Evento.First(cs => cs.EventoId == ht.Evento);

                _context.Add(hist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.Evento = _context.Evento.ToList();

            return View(ht);
        }



        private bool HistoricoExists(int id)
        {
            return _context.Historico.Any(e => e.HistoricoId == id);
        }
    }
}
