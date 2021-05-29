using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace inicio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
         public DbSet<inicio.Models.Reserva> Reserva {get; set;}
         public DbSet<inicio.Models.Producto> DataProducto {get; set;}
         public DbSet<inicio.Models.Proforma> DataCarrito { get; set; }
        public DbSet<inicio.Models.Pedido> DataPedidos { get; set; }

        public DbSet<inicio.Models.Personal> Personal {get; set;}
    }
}
