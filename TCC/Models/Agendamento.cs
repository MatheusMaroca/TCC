using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Models
{
    [Table("Agendamento")]
    public class Agendamento
    {
        [Key]
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public string UsuarioId { get; set; }
        public Animal Animal { get; set; }
        public int AnimalId { get; set; }
        public AgendaCastramovel AgendaCastramovel { get; set; }
        public int AgendaCastramovelId { get; set; }
        [Column(TypeName = "VARCHAR(5)")]
        public string Horario { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Status { get; set; }
    }
}
