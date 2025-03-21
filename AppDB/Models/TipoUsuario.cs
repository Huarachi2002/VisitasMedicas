using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendVisitaNET.Models
{
    [Table("TipoUsuario", Schema = "SIS")]
    public class TipoUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string CodigoERP { get; set; }
        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }
        [MaxLength(10)]
        public string? Abreviatura { get; set; }
        public int Tipo { get; set; }
    }
}
