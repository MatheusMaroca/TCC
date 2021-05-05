using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Models
{
    [Table("Clinica")]
    public class Clinica
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }
        [Column(TypeName = "VARCHAR(11)")]
        public string Telefone { get; set; }
        public string Foto { get; set; }
        [Column(TypeName = "VARCHAR(500)")]
        [Display(Name = "Descrição")] 
        public string Descricao { get; set; }        

        public ClinicaEndereco ClinicaEndereco { get; set; }
    }
}
