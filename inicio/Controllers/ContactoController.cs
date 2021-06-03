using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using inicio.Data;
using inicio.Models;

namespace inicio.Controllers
{
    public class ContactoController : Controller
    {
        private readonly ILogger<ContactoController> _logger;
        
        private readonly ApplicationDbContext _context;

        public ContactoController(ILogger<ContactoController> logger,
            ApplicationDbContext context
            )
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
           var listacontacto = _context.DataContacto.ToList();
            ViewData["message"]="";
            return View(listacontacto);
        
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contacto objContacto)
        {
            _context.Add(objContacto);
            _context.SaveChanges();
            ViewData["Message"] = "El contacto ya esta registrado";
            return View();
        }
         public IActionResult BorrarContacto(int id){
            /*_context.Regiones.First(r =>r.Id==id);*/ /* primera forma de borrar*/
            var contactos=_context.DataContacto.Find(id);// segunda forma 
            _context.Remove(contactos);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}