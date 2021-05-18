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
        [Required(ErrorMessage = "{0} - Campo requerido")]
        [Column(TypeName = "VARCHAR(100)")]
        public string CidadeDistrito { get; set; }

        [Required(ErrorMessage = "{0} - Campo requerido")]
        [Column(TypeName = "VARCHAR(100)")]
        public string Regiao { get; set; }

        [Required(ErrorMessage = "{0} - Campo requerido")]
        [Column(TypeName = "VARCHAR(100)")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "{0} - Campo requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Número inválido")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "{0} - Campo requerido")]
        [Column(TypeName = "VARCHAR(100)")]
        public string Bairro { get; set; }
    }
}
