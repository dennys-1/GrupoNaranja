using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace inicio.Models
{
     [Table ("reserva")]
    public class Reserva
    {
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]

        public int id { get; set; }
        
        public string n_personas { get; set; }

        public int Telefono{get; set;}
        
        public string ocasion { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }

        public string hora {get; set;}
    }
}