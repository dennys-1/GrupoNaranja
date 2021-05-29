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
   
    public class ReservaController : Controller
        {
        private readonly ILogger<ReservaController> _logger;
        
        private readonly ApplicationDbContext _context;

        public ReservaController(ILogger<ReservaController> logger,
        ApplicationDbContext context)
        {
            _logger = logger;
            _context=context;
        }
         
         public IActionResult Reserva()
        { 
           

            var listreserva = _context.Reserva.ToList();
            ViewData["message"]="";
            return View(listreserva);
        }
         [HttpGet]
        public IActionResult CrearReserva()
        {
            return View();
        }
         [HttpPost]
        public IActionResult CrearReserva(Reserva objReserva)
        {
            _context.Add(objReserva);
            _context.SaveChanges();
            ViewData["Message"] = "La reserva ya esta registrado";
            return View();
        }

        public IActionResult ExportarExcel()
{
    string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    var reserva = _context.Reserva.AsNoTracking().ToList();
    using (var libro = new ExcelPackage())
    {
        var worksheet = libro.Workbook.Worksheets.Add("Reservas");
        worksheet.Cells["A1"].LoadFromCollection(reserva, PrintHeaders: true);
        for (var col = 1; col < reserva.Count + 1; col++)
        {
            worksheet.Column(col).AutoFit();
        }

        // Agregar formato de tabla
        var tabla = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: reserva.Count + 1, toColumn: 5), "Reserva");
        tabla.ShowHeader = true;
        tabla.TableStyle = TableStyles.Light6;
        tabla.ShowTotal = true;

        return File(libro.GetAsByteArray(), excelContentType, "Reserva.xlsx");
    }
}
    }
}