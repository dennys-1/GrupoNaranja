using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inicio.Models
{
    [Table("t_order")]
    public class Pedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id {get; set;}

        public String UserID {get; set;}


        public Decimal Total { get; set; }
    }
}