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
         public  async Task<IActionResult> Create(int id, [Bind("HistoricoId,EventoId")] HistoricoDTO histTemp)
        {
            if (id != histTemp.HistoricoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Historico hist = new Historico();
                hist.HistoricoId = histTemp.HistoricoId;
                hist.Evento = _context.Evento.First(cs => cs.EventoId == histTemp.Evento);

                    _context.Update(hist);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricoExists(histTemp.HistoricoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewBag.Casadeshow = _context.CasaDeShow.ToList();
            ViewBag.Genero = _context.Genero.ToList();
            return View(histTemp);
        }



        private bool HistoricoExists(int id)
        {
            return _context.Historico.Any(e => e.HistoricoId == id);
        }
    }
}
