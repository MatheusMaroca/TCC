using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Models
{
    public class Endereco
    {
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string CidadeDistrito { get; set; }        
        [Column(TypeName = "VARCHAR(100)")]
        public string Regiao { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Rua { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Bairro { get; set; }
    }
}
