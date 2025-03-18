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
        public string Contrasena { get; set; }  // Almacenada en Base64 (SHA-256)

        [Required]
        public int Estado { get; set; } // 1 = Activo, 0 = Inactivo

        public long IdEmpleado { get; set; } // Relación con Empleado
    }
}
