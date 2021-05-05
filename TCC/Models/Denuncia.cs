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
        [Display(Name = "Descrição")] 
        public string Descricao { get; set; }
        public string Foto { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Status { get; set; }
        [Required]
        [Column(TypeName = "DATE")]
        [Display(Name = "Data Realizada")]
        public DateTime DataRealizada { get; set; }


        public DenunciaEndereco DenunciaEndereco { get; set; }
    }
}
