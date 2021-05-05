using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Models
{
    public class Usuario : IdentityUser
    {
        [Required]
        [Column(TypeName ="VARCHAR(11)")]
        public string Cpf { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(9)")]        
        public string Rg { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string NomeCompleto { get; set; }
    }
}
