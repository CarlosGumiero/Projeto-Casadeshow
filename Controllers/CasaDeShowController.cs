using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Casadeshow.Data;
using Casadeshow.Models;

namespace Casadeshow.Controllers
{
    public class CasaDeShowController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CasaDeShowController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CasaDeShow.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CasaDeShowId,Nome,Endereco")] CasaDeShow casaDeShow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casaDeShow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casaDeShow);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casaDeShow = await _context.CasaDeShow.FindAsync(id);
            if (casaDeShow == null)
            {
                return NotFound();
            }
            return View(casaDeShow);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CasaDeShowId,Nome,Endereco")] CasaDeShow casaDeShow)
        {
            if (id != casaDeShow.CasaDeShowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casaDeShow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasaDeShowExists(casaDeShow.CasaDeShowId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(casaDeShow);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casaDeShow = await _context.CasaDeShow
                .FirstOrDefaultAsync(m => m.CasaDeShowId == id);
            if (casaDeShow == null)
            {
                return NotFound();
            }

            return View(casaDeShow);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casaDeShow = await _context.CasaDeShow.FindAsync(id);
            _context.CasaDeShow.Remove(casaDeShow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasaDeShowExists(int id)
        {
            return _context.CasaDeShow.Any(e => e.CasaDeShowId == id);
        }
    }
}
