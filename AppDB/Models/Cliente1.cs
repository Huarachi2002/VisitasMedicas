using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDB.Models
{
    [Table("Cliente1", Schema = "ERP")]
    public class Cliente1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [MaxLength(512)]
        public string? ReferenciaUbicacion { get; set; }
        public string? Foto { get; set; }
        [MaxLength(200)]
        public string? Barrio { get; set; }
        [MaxLength(200)]
        public string? Lote { get; set; }
        [MaxLength(15)]
        public string? UV { get; set; }
        [MaxLength(15)]
        public string? Manzana { get; set; }
        [MaxLength(15)]
        public string? NroCasa { get; set; }
        [Required]
        [MaxLength(200)]
        public string Especialidad1 { get; set; }
        [MaxLength(200)]
        public string? Especialidad2 { get; set; }
        [MaxLength(200)]
        public string? Especialidad3 { get; set; }
        [Required]
        [MaxLength(15)]
        public long IdCategoria { get; set; }
        public virtual Categoria? Categoria { get; set; }
        [Required]
        [MaxLength(15)]
        public string Dias { get; set; }
        [Required]
        [MaxLength(15)]
        public string Turno { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public long IdRegional { get; set; }
        public virtual Regional? Regional { get; set; }
        public string? Movil { get; set; }
    }
}
