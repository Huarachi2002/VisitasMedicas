﻿using AppDB.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDB.Models
{
    [Table("Empleado", Schema = "ERP")]
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string CodigoERP { get; set; } 
        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        [Required]
        public int Estado { get; set; }
        public long? IdNivelC1 { get; set; }
        public int? VisitaProgramada { get; set; }
        public long? IdSucursal { get; set; }
        public virtual Sucursal? Sucursal { get; set; }
        public decimal? PorcentajeDescuento { get; set; }
        public string? Email { get; set; }
        public int? ValidarUbicacion { get; set; }
        public int? tracking { get; set; }
        public long? IdListaPrecio { get; set; }
        public int? ReImpresion { get; set; }
        public int? Origen { get; set; }
        public string? CodigoSucursalSin { get; set; }
        public string? CodigoPuntoVentaSin { get; set; }
        public long? EmpleadoFacturador { get; set; }
        public int? AbonoPedido { get; set; }
        public ICollection<EmpleadoEspecialidad> EmpleadoEspecialidades { get; set; }
    }
}
