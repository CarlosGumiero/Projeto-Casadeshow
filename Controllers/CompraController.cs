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

        public IActionResult HistCompra()
        {
            ViewBag.Evento = _context.Evento.ToList();
            return View();
        }

        //Salvando as informações da View Compra
        [HttpPost]
        public IActionResult ConfirmaCompra(Compra compra)
        {
            compra.Evento = _context.Evento.First(c => c.EventoId == compra.Evento.EventoId);
            compra.Data = DateTime.Now;
            compra.Total = (compra.QtdIngressos * compra.Evento.PrecoIngresso);

            //Mudando a quantidade de ingressos do bando de dados do evento
            var zea = _context.Evento.First(c => c.EventoId == compra.Evento.EventoId);
            zea.QtdIngresso -= compra.QtdIngressos;
            
            _context.Update(zea);
            _context.Add(compra);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


    }
}