using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

//using NARANJA.Data;
//using NARANJA.Models;

namespace NARANJA.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly ILogger<AdministradorController> _logger;
        
       // private readonly ApplicationDbContext _context;

        public AdministradorController(ILogger<AdministradorController> logger)/*,
        /*ApplicationDbContext context)*/
        {
            _logger = logger;
            //_context=context;
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
           return View();

            /*var listreservas = _context.Reservas.ToList();
            ViewData["message"]="";
            return View(listreservas);*/
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
