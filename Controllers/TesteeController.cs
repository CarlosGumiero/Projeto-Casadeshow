using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Casadeshow.Data;
using Casadeshow.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Casadeshow.Controllers
{
    public class TesteeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TesteeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Testee.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImajId,Nome,Foto")] Testee testee, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    byte[] b;
                    using(var or = Image.OpenReadStream())
                    {
                        using(var ms = new MemoryStream())
                        {
                            or.CopyTo(ms);
                            b = ms.ToArray();
                        }
                    }
                    testee.Foto = b;
                }

                _context.Add(testee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testee);
        }

        public IActionResult PegarImagem(int id)
        {
            byte[] b =_context.Testee.Find(id).Foto;

            return File(b, "image/jpg");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testee = await _context.Testee.FindAsync(id);
            if (testee == null)
            {
                return NotFound();
            }
            return View(testee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImajId,Nome,Foto")] Testee testee, IFormFile Image)
        {
            if (id != testee.ImajId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Image != null)
                {
                    byte[] b;
                    using(var or = Image.OpenReadStream())
                    {
                        using(var ms = new MemoryStream())
                        {
                            or.CopyTo(ms);
                            b = ms.ToArray();
                        }
                    }
                    testee.Foto = b;    
                }
                    _context.Update(testee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TesteeExists(testee.ImajId))
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
            return View(testee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testee = await _context.Testee
                .FirstOrDefaultAsync(m => m.ImajId == id);
            if (testee == null)
            {
                return NotFound();
            }

            return View(testee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testee = await _context.Testee.FindAsync(id);
            _context.Testee.Remove(testee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TesteeExists(int id)
        {
            return _context.Testee.Any(e => e.ImajId == id);
        }
    }
}
