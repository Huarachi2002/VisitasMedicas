using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendVisitaNET.Models
{
    [Table("Sucursal", Schema="GEN")]
    public class Sucursal
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string CodigoERP { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(200)]
        public string? Direccion { get; set; }
        [MaxLength(50)]
        public string? Telefono { get; set; }
        [MaxLength(50)]
        public string? Fax { get; set; }
        [MaxLength(50)]
        public string? Registro { get; set; }
        [Required]
        public long IdDepartamento { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        [Required]
        public int Estado { get; set; }
        [Required]
        public long IdEmpresa { get; set; }
        public long? IdRegion { get; set; }
        public int? Tipo { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        [MaxLength(100)]
        public string? Lugar { get; set; }
        public int? ZonaFranca { get; set; }
        public long? IdRegional { get; set; }
        public virtual Regional? Regional { get; set; }
    }
}
