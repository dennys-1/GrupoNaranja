using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace inicio.Models
{
    [Table("t_contact")]
    public class Contacto
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id {get; set;}

        
        public String Nombre {get; set;}

        public String Email {get; set;}

        public String Celular {get; set;}

        public String Detalles{get;set;}
        
    }
}