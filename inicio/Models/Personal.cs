using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace inicio.Models
{
     [Table ("Personal")]
    public class Personal
    {
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id {get; set;}
        
        [Column("Nombres")]
        public String Nombres {get; set;}

         [Column("Apellidos")]
        public String Apellidos {get; set;}
        
         [Column("EMAIL")]
        public String EMAIL {get; set;}
        
        [Column("DNI")]  
        public int DNI { get; set; }

        [Column("Celular")]  
        public int Celular { get; set; }

        [Column("Cargo")] 
        public String Cargo { get; set; }
        
        [Column("imagen")] 
        public String imagen { get; set; }   
    }
}