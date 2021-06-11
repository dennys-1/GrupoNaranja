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
           public IActionResult ExportarExcel()
{
    string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    var contacto = _context.DataContacto.AsNoTracking().ToList();
    using (var libro = new ExcelPackage())
    {
        var worksheet = libro.Workbook.Worksheets.Add("Contacto");
        worksheet.Cells["A1"].LoadFromCollection(contacto, PrintHeaders: true);
        for (var col = 1; col < contacto.Count + 1; col++)
        {
            worksheet.Column(col).AutoFit();
        }

        // Agregar formato de tabla
        var tabla = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: contacto.Count + 1, toColumn: 5), "Contacto");
        tabla.ShowHeader = true;
        tabla.TableStyle = TableStyles.Light6;
        tabla.ShowTotal = true;

        return File(libro.GetAsByteArray(), excelContentType, "Contactanos.xlsx");
    }
}

    }
}