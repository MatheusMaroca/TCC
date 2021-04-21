using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Models
{
    [Table("Animal")]
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }
        [Required]
        [Column(TypeName = "CHAR(1)")]
        public char Tipo { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Cor { get; set; }
        [Required]
        [Column(TypeName = "TINYINT")]
        public int IdadeAno { get; set; }
        [Required]
        [Column(TypeName = "TINYINT")]
        public int IdadeMes { get; set; }
        [Required]
        [Column(TypeName = "CHAR(1)")]
        public char Sexo { get; set; }
        [Required]
        [Column(TypeName = "CHAR(1)")]
        public char Porte { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime DataVacida { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime DataVermifugo { get; set; }
        [Column(TypeName = "VARCHAR(255)")]
        public string Medicamento { get; set; }
        public int NumChip { get; set; }

        public Usuario Usuario { get; set; }
        public string UsuarioId { get; set; }

    }
}
