using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Dto
{
    public class ClienteDto
    {
        // Cliente
        public long? Id { get; set; }
        public string? CodigoERP { get; set; }
        public string? Ci { get; set; }
        public string Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public string Nit { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal SaldoDeudor { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
        public DateTime FechaRegistro { get; set; }
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
        public long IdCliente1 { get; set; }
        public int Visitado { get; set; }
        public long? IdTipoPersona { get; set; }
        public long? TipoLista { get; set; }
        public decimal? DiasPlazo { get; set; }
        public string? RazonSocial { get; set; }
        public int? tipo { get; set; }
        public DateTime? fecha { get; set; }
        public long? IdEmpleado { get; set; }
        public int? Facturado { get; set; }
        public int? Consignacion { get; set; }
        public int? CopiaAdicionalFactura { get; set; }
        public string? CodigoPadre { get; set; }
        public short CantidadCompras { get; set; }
        public DateTime FechaUltimaCompra { get; set; }
        public long? IdTipoDocumentoSFE { get; set; }
        public string? Extension { get; set; }
        public int? AplicarSustituto { get; set; }

        // Cliente1
        public string? ReferenciaUbicacion { get; set; }
        public string? Foto { get; set; }
        public string? Barrio { get; set; }
        public string? Lote { get; set; }
        public string? UV { get; set; }
        public string? Manzana { get; set; }
        public string? NroCasa { get; set; }
        public string Especialidad1 { get; set; }
        public string? Especialidad2 { get; set; }
        public string? Especialidad3 { get; set; }
        public long IdCategoria { get; set; }
        public string Dias { get; set; }
        public string Turno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public long IdRegional { get; set; }
        public string? Movil { get; set; }
    }
}
