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
    public class EventoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Casadeshow = _context.CasaDeShow.ToList();
            ViewBag.Genero = _context.Genero.ToList();
            return View(await _context.Evento.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Casadeshow = _context.CasaDeShow.ToList();
            ViewBag.Genero = _context.Genero.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("EventoId,Nome,Capacidade,PrecoIngresso,Data,QtdIngresso,CasaDeShow,Genero")] EventoDTO eventotemp)
        {
            
            if (ModelState.IsValid)
            {
                Evento evento = new Evento();
                evento.EventoId = eventotemp.EventoId;
                evento.Nome = eventotemp.Nome;
                evento.Capacidade = eventotemp.Capacidade;
                evento.PrecoIngresso = eventotemp.PrecoIngresso;
                evento.Data = eventotemp.Data;
                evento.QtdIngresso = eventotemp.QtdIngresso;
                evento.CasaDeShow = _context.CasaDeShow.First(cs => cs.CasaDeShowId == eventotemp.CasaDeShow);
                evento.Genero = _context.Genero.First(cs => cs.GeneroId == eventotemp.Genero);

                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.Casadeshow = _context.CasaDeShow.ToList();
            ViewBag.Genero = _context.Genero.ToList();

            return View(eventotemp);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Casadeshow = _context.CasaDeShow.ToList();
            ViewBag.Genero = _context.Genero.ToList();

            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento.Include(g => g.CasaDeShow).Include(g => g.Genero).SingleOrDefaultAsync(g => g.EventoId == id);

            if (evento == null)
            {
                return NotFound();
            }

            EventoDTO dto = new EventoDTO();
            dto.EventoId = evento.EventoId;
            dto.Nome = evento.Nome;
            dto.Capacidade = evento.Capacidade;
            dto.PrecoIngresso = evento.PrecoIngresso;
            dto.Data = evento.Data;
            dto.QtdIngresso = evento.QtdIngresso;
            dto.CasaDeShow = evento.CasaDeShow.CasaDeShowId;
            dto.Genero = evento.Genero.GeneroId;


            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventoId,Nome,Capacidade,PrecoIngresso,Data,QtdIngresso,CasaDeShow,Genero")] EventoDTO eventotemp)
        {
            if (id != eventotemp.EventoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Evento evento = new Evento();
                    evento.EventoId = eventotemp.EventoId;
                    evento.Nome = eventotemp.Nome;
                    evento.Capacidade = eventotemp.Capacidade;
                    evento.PrecoIngresso = eventotemp.PrecoIngresso;
                    evento.Data = eventotemp.Data;
                    evento.QtdIngresso = eventotemp.QtdIngresso;
                    evento.CasaDeShow = _context.CasaDeShow.First(cs => cs.CasaDeShowId == eventotemp.CasaDeShow);
                    evento.Genero = _context.Genero.First(cs => cs.GeneroId == eventotemp.Genero);

                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(eventotemp.EventoId))
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
            return View(eventotemp);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento
                .FirstOrDefaultAsync(m => m.EventoId == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Evento.FindAsync(id);
            _context.Evento.Remove(evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Evento.Any(e => e.EventoId == id);
        }
    }
}
