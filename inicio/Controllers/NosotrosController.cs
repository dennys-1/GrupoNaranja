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
using OfficeOpenXml;
using OfficeOpenXml.Table;
namespace inicio.Controllers
{
   
    public class NosotrosController : Controller
        {
        private readonly ILogger<NosotrosController> _logger;
        
        private readonly ApplicationDbContext _context;

        public NosotrosController(ILogger<NosotrosController> logger,
        ApplicationDbContext context)
        {
            _logger = logger;
            _context=context;
        }
         
         public IActionResult Nosotros()
        {
            return View();
        }
        
    }
}