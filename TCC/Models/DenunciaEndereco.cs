using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Models
{
    [Table("DenunciaEndereco")]
    public class DenunciaEndereco : Endereco
    {
        [Key]
        public int Id { get; set; }
                
        public Denuncia Denuncia { get; set; }
        public int DenunciaId { get; set; }
    }
}
