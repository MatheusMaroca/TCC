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

        [Required(ErrorMessage = "{0} - Campo requerido")]
        [MinLength(3, ErrorMessage = "O campo deve conter ao menos 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O campo deve conter no máximo 100 caracteres.")]
        [Column(TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} - Campo requerido")]
        [StringLength(14, MinimumLength = 13, ErrorMessage = "Informe o telefone corretamente.")]
        [Column(TypeName = "VARCHAR(11)")]
        public string Telefone { get; set; }

        public string Foto { get; set; }
        
        [Column(TypeName = "VARCHAR(500)")]
        [Display(Name = "Descrição")] 
        public string Descricao { get; set; }        

        public ClinicaEndereco ClinicaEndereco { get; set; }
    }
}
