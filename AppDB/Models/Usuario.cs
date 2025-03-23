using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendVisitaNET.Models
{
    [Table("Usuario", Schema = "SIS")]
    public class Usuario
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Login { get; set; }
        [Required]
        [MaxLength(50)]
        public string Contrasena { get; set; }  
        [Required]
        public int Estado { get; set; } 
        [Required]
        public long IdEmpleado { get; set; } 
        public virtual Empleado? Empleado { get; set; }
        public long? IdTipoUsuario { get; set; }
        public virtual TipoUsuario? TipoUsuario { get; set; }
        [MaxLength(50)]
        public string? Imei { get; set; }
    }
}
