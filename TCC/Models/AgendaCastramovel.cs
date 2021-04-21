using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Models
{
    [Table("AgendaCastramovel")]
    public class AgendaCastramovel : Endereco
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "DATE")]
        public DateTime Data { get; set; }

    }
}
