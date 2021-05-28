using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using inicio.Data;
using inicio.Models;

namespace inicio.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly ILogger<AdministradorController> _logger;
        
        private readonly ApplicationDbContext _context;

        public AdministradorController(ILogger<AdministradorController> logger,
        ApplicationDbContext context)
        {
            _logger = logger;
            _context=context;
        }
         public IActionResult Index()
        {
            return View();
        }

        public IActionResult Carta()
        {
            return View();
        }
         public IActionResult Reservas()
        { 
           

            var listreservas = _context.Reserva.ToList();
            ViewData["message"]="";
            return View(listreservas);
        }
         public IActionResult Horario()
        {
            return View();
        }
        public IActionResult Miperfil()
        {
            return View();
        }
    }
}
