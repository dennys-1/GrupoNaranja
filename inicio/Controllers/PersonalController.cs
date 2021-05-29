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
   
    public class PersonalController : Controller
        {
        private readonly ILogger<PersonalController> _logger;
        
        private readonly ApplicationDbContext _context;

        public PersonalController(ILogger<PersonalController> logger,
        ApplicationDbContext context)
        {
            _logger = logger;
            _context=context;
        }
         
         public IActionResult Personal()
        { 
           

            var listapersonal = _context.Personal.ToList();
            ViewData["message"]="";
            return View(listapersonal);
        }
         [HttpGet]
        public IActionResult NuevoPersonal()
        {
            return View();
        }
         [HttpPost]
        public IActionResult NuevoPersonal(Personal Npersonal)
        {
            _context.Add(Npersonal);
            _context.SaveChanges();
            ViewData["Message"] = "El personal ya esta registrado";
            return View();
        }

          /***************BORRAR **********/
        public IActionResult BorrarPersonal(int id){
            /*_context.Regiones.First(r =>r.Id==id);*/ /* primera forma de borrar*/
            var personales=_context.Personal.Find(id);// segunda forma 
            _context.Remove(personales);
            _context.SaveChanges();
            return RedirectToAction("Personal");
        }

        /***************EDITAR **********/

         public IActionResult EditarPersonal(int id){
             var personales=_context.Personal.Find(id);

            return View(personales);

        }
        [HttpPost]
        public IActionResult EditarPersonal(Personal r){
            if(ModelState.IsValid)
            {
                var personales=_context.Personal.Find(r.id);
                personales.Nombres=r.Nombres;
                personales.Apellidos=r.Apellidos;
                personales.EMAIL=r.EMAIL;
                personales.DNI=r.DNI;
                personales.Celular=r.Celular;
                personales.Cargo=r.Cargo;
                personales.imagen=r.imagen;
               
                _context.SaveChanges();
                
            }
             ViewData["Message"] = "El personal editado";
            return View(r);
        }













        public IActionResult ExportarExcel()
{
    string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    var Personal = _context.Personal.AsNoTracking().ToList();
    using (var libro = new ExcelPackage())
    {
        var worksheet = libro.Workbook.Worksheets.Add("Personal");
        worksheet.Cells["A1"].LoadFromCollection(Personal, PrintHeaders: true);
        for (var col = 1; col < Personal.Count + 1; col++)
        {
            worksheet.Column(col).AutoFit();
        }

        // Agregar formato de tabla
        var tabla = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: Personal.Count + 1, toColumn: 8), "Personal");
        tabla.ShowHeader = true;
        tabla.TableStyle = TableStyles.Light6;
        tabla.ShowTotal = true;

        return File(libro.GetAsByteArray(), excelContentType, "Personal.xlsx");
    }
}
    }
}