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

        public IActionResult Index()
        {
            return View();
        }

        private bool HistoricoExists(int id)
        {
            return _context.Historico.Any(e => e.HistoricoId == id);
        }
    }
}
