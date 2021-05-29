using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace inicio.Models
{
     [Table ("Producto")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal Precio{get; set;}

        public string Descripcion{get; set;}

        public string Imagen{get; set;}

        public string Status{get;set;}
        public virtual ICollection<Proforma> ProformaItems { get; set; }
        
        


    }
}