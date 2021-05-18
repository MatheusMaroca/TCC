using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Models
{
    [Table("UsuarioEndereco")]
    public class UsuarioEndereco : Endereco
    {
        [Key]
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }        
    }
}
