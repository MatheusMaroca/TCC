using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Models
{
    [Table("Horarios")]
    public class Horarios
    {
        [Key]
        public int Id { get; set; }
        public Boolean Disponivel { get; set; }
        [Column(TypeName = "VARCHAR(5)")]
        public string Horario { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime Dia { get; set; }

    }
}
