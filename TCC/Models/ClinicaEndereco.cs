using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Models
{
    [Table("ClinicaEndereco")]
    public class ClinicaEndereco : Endereco
    {
        [Key]
        public int Id { get; set; }
        public Clinica Clinica { get; set; }
        public int ClinicaId { get; set; }
    }
}
