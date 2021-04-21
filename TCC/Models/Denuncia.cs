using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Models
{
    [Table("Denuncia")]
    public class Denuncia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string Descricao { get; set; }
        public byte[] Foto { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Status { get; set; }

        public IList<IFormFile> Arquivos { get; set; }

        public DenunciaEndereco DenunciaEndereco { get; set; }
    }
}
