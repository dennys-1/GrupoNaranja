using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

  
  namespace NARANJA.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }
    public IActionResult PagoCliente()
        {
            return View();
        }
     public IActionResult BoletaCliente()
        {
            return View();
        }
         public IActionResult CartaCliente()
        {
            return View();
        }
         public IActionResult Combo()
        {
            return View();
        }
         public IActionResult EspecialidadesCliente()
        {
            return View();
        }
         public IActionResult OfertaCliente()
        {
            return View();
        }
         public IActionResult ReservaCliente()
        {
            return View();
        }

        
        public IActionResult Index()
        {
            return View();
        }
    }
}