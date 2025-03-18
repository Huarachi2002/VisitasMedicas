using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendVisitaNET.Models
{
    [Table("Cliente", Schema = "ERP")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string CodigoERP { get; set; } = string.Empty;
        public string? Ci { get; set; }
        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        [Required]
        public string Nit { get; set; } = string.Empty;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        [Required]
        public decimal LimiteCredito { get; set; }
        [Required]
        public decimal SaldoDeudor { get; set; }
        [Required]
        public decimal Longitud { get; set; }
        [Required]
        public decimal Latitud { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        [Required]
        public int Estado { get; set; }
        public long? IdListaPrecio { get; set; }
        public long? IdPorcentajeDescuento { get; set; }
        public long IdNivelC1 { get; set; }
        public long IdSucursal { get; set; }
        public long? IdTipoCliente { get; set; }
        public string? Transaccion { get; set; }
        public string? HashCode { get; set; }
        public string? Celular { get; set; }
        public long? IdTabla { get; set; }
        public long? IdCliente1 { get; set; }
        public int? Visitado { get; set; }
        public long? IdTipoPersona { get; set; }
        public long? TipoLIsta { get; set; }
        public decimal? DiasPlazo { get; set; }
        public string? RazonSocial { get; set; }
        public int? tipo { get; set; }
        public DateTime? fecha { get; set; }
        public long? IdEmpleado { get; set; }
        public int? Facturado { get; set; }
        public int? Consignacion { get; set; }
        public int? CopiaAdicionalFactura { get; set; }
        public string? CodigoPadre { get; set; }
        public short? CantidadCompras { get; set; }
        public DateTime? FechaUltimaCompra { get; set; }
        public long? IdTipoDocumentoSFE { get; set; }
        public string? Extension { get; set; }
        public int? AplicarSustituto { get; set; }
    }
}
