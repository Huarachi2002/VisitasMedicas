using BackendVisitaNET.Data;
using AppDB.Models;
using Clientes.Dto;
using Clientes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Clientes1.Services;

namespace BackendVisitaNET.Controllers
{
    //[Authorize] // Requiere autenticación para acceder
    [Route("api/Clientes")]
    public class ClientesController : ODataController
    {
        private readonly ClientesService _clientesService;
        private readonly Cliente1Service _cliente1Service;

        public ClientesController(ClientesService clientesService, Cliente1Service cliente1Service)
        {
            _clientesService = clientesService;
            _cliente1Service = cliente1Service;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var query = _clientesService.GetAllClientes();
                return Ok(query);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<Cliente>>
                {
                    Success = false,
                    Message = "Error al obtener data.",
                    Data = null,
                    Error = ex.Message
                };
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDto cliente)
        {
            if (cliente == null)
            {
                var response = new ApiResponse<Cliente>
                {
                    Success = false,
                    Message = "Formato de cliente incorrecto.",
                    Data = null,
                    Error = "Error al crear cliente"
                };
                return BadRequest(response);
            }

            try
            {
                var cliente1 = new Cliente1
                {
                    ReferenciaUbicacion = cliente.ReferenciaUbicacion,
                    Foto = cliente.Foto,
                    Barrio = cliente.Barrio,
                    Lote = cliente.Lote,
                    UV = cliente.UV,
                    Manzana = cliente.Manzana,
                    NroCasa = cliente.NroCasa,
                    Especialidad1 = cliente.Especialidad1,
                    Especialidad2 = cliente.Especialidad2,
                    Especialidad3 = cliente.Especialidad3,
                    IdCategoria = cliente.IdCategoria,
                    Dias = cliente.Dias,
                    Turno = cliente.Turno,
                    FechaNacimiento = cliente.FechaNacimiento,
                    IdRegional = cliente.IdRegional,
                    Movil = cliente.Movil
                };

                var newCliente = new Cliente
                {
                    CodigoERP = cliente.CodigoERP,
                    Ci = cliente.Ci,
                    Nombre = cliente.Nombre,
                    Paterno = cliente.Paterno,
                    Materno = cliente.Materno,
                    Nit = cliente.Nit,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    Email = cliente.Email,
                    LimiteCredito = cliente.LimiteCredito,
                    SaldoDeudor = cliente.SaldoDeudor,
                    Longitud = cliente.Longitud,
                    Latitud = cliente.Latitud,
                    FechaRegistro = cliente.FechaRegistro,
                    Estado = 1 ,
                    IdListaPrecio = cliente.IdListaPrecio,
                    IdPorcentajeDescuento = cliente.IdPorcentajeDescuento,
                    IdNivelC1 = cliente.IdNivelC1,
                    IdSucursal = cliente.IdSucursal,
                    IdTipoCliente = cliente.IdTipoCliente,
                    Transaccion = cliente.Transaccion,
                    HashCode = cliente.HashCode,
                    Celular = cliente.Celular,
                    IdTabla = cliente.IdTabla,
                    IdCliente1 = cliente1.Id,
                    Visitado = cliente.Visitado,
                    IdTipoPersona = cliente.IdTipoPersona,
                    TipoLista = cliente.TipoLista,
                    DiasPlazo = cliente.DiasPlazo,
                    RazonSocial = cliente.RazonSocial,
                    tipo = cliente.tipo,
                    fecha = cliente.fecha,
                    IdEmpleado = cliente.IdEmpleado,
                    Facturado = cliente.Facturado,
                    Consignacion = cliente.Consignacion,
                    CopiaAdicionalFactura = cliente.CopiaAdicionalFactura,
                    CodigoPadre = cliente.CodigoPadre,
                    CantidadCompras = cliente.CantidadCompras,
                    FechaUltimaCompra = cliente.FechaUltimaCompra,
                    IdTipoDocumentoSFE = cliente.IdTipoDocumentoSFE,
                    Extension = cliente.Extension,
                    AplicarSustituto = cliente.AplicarSustituto
                };


                var createdCliente1 = await _cliente1Service.CreateCliente1(cliente1);
                var createdCliente = await _clientesService.CreateClienteAsync(createdCliente1.Id, newCliente);

                var response = new ApiResponse<Cliente>
                {
                    Success = true,
                    Message = "Cliente creado exitosamente.",
                    Data = createdCliente,
                    Error = null
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<Cliente>
                {
                    Success = false,
                    Message = "Error al crear el cliente.",
                    Data = null,
                    Error = ex.Message
                };
                return BadRequest(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ClienteDto cliente)
        {
            if (cliente == null || id != cliente.Id)
            {
                var response = new ApiResponse<Cliente>
                {
                    Success = false,
                    Message = "Id no coincide con el cliente proporcionado.",
                    Data = null,
                    Error = "Error al actualizar cliente"
                };
                return BadRequest(response);
            }

            var clienteExistente = _clientesService.GetAllClientes().First<Cliente>(e => e.Id == id);
            var cliente1Existente = _cliente1Service.GetAllClientes1().First<Cliente1>(e1 => e1.Id == cliente.IdCliente1);

            cliente1Existente.ReferenciaUbicacion = cliente.ReferenciaUbicacion;
            cliente1Existente.Foto = cliente.Foto;
            cliente1Existente.Barrio = cliente.Barrio;
            cliente1Existente.Lote = cliente.Lote;
            cliente1Existente.UV = cliente.UV;
            cliente1Existente.Manzana = cliente.Manzana;
            cliente1Existente.NroCasa = cliente.NroCasa;
            cliente1Existente.Especialidad1 = cliente.Especialidad1;
            cliente1Existente.Especialidad2 = cliente.Especialidad2;
            cliente1Existente.Especialidad3 = cliente.Especialidad3;
            cliente1Existente.IdCategoria = cliente.IdCategoria;
            cliente1Existente.Dias = cliente.Dias;
            cliente1Existente.Turno = cliente.Turno;
            cliente1Existente.FechaNacimiento = cliente.FechaNacimiento;
            cliente1Existente.IdRegional = cliente.IdRegional;
            cliente1Existente.Movil = cliente.Movil;

            clienteExistente.CodigoERP = cliente.CodigoERP;
            clienteExistente.Ci = cliente.Ci;
            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Paterno = cliente.Paterno;
            clienteExistente.Materno = cliente.Materno;
            clienteExistente.Nit = cliente.Nit;
            clienteExistente.Direccion = cliente.Direccion;
            clienteExistente.Telefono = cliente.Telefono;
            clienteExistente.Email = cliente.Email;
            clienteExistente.LimiteCredito = cliente.LimiteCredito;
            clienteExistente.SaldoDeudor = cliente.SaldoDeudor;
            clienteExistente.Longitud = cliente.Longitud;
            clienteExistente.Latitud = cliente.Latitud;
            clienteExistente.FechaRegistro = cliente.FechaRegistro;
            clienteExistente.Estado = 1;
            clienteExistente.IdListaPrecio = cliente.IdListaPrecio;
            clienteExistente.IdPorcentajeDescuento = cliente.IdPorcentajeDescuento;
            clienteExistente.IdNivelC1 = cliente.IdNivelC1;
            clienteExistente.IdSucursal = cliente.IdSucursal;
            clienteExistente.IdTipoCliente = cliente.IdTipoCliente;
            clienteExistente.Transaccion = cliente.Transaccion;
            clienteExistente.HashCode = cliente.HashCode;
            clienteExistente.Celular = cliente.Celular;
            clienteExistente.IdTabla = cliente.IdTabla;
            clienteExistente.IdCliente1 = cliente.IdCliente1;
            clienteExistente.Visitado = cliente.Visitado;
            clienteExistente.IdTipoPersona = cliente.IdTipoPersona;
            clienteExistente.TipoLista = cliente.TipoLista;
            clienteExistente.DiasPlazo = cliente.DiasPlazo;
            clienteExistente.RazonSocial = cliente.RazonSocial;
            clienteExistente.tipo = cliente.tipo;
            clienteExistente.fecha = cliente.fecha;
            clienteExistente.IdEmpleado = cliente.IdEmpleado;
            clienteExistente.Facturado = cliente.Facturado;
            clienteExistente.Consignacion = cliente.Consignacion;
            clienteExistente.CopiaAdicionalFactura = cliente.CopiaAdicionalFactura;
            clienteExistente.CodigoPadre = cliente.CodigoPadre;
            clienteExistente.CantidadCompras = cliente.CantidadCompras;
            clienteExistente.FechaUltimaCompra = cliente.FechaUltimaCompra;
            clienteExistente.IdTipoDocumentoSFE = cliente.IdTipoDocumentoSFE;
            clienteExistente.Extension = cliente.Extension;
            clienteExistente.AplicarSustituto = cliente.AplicarSustituto;

            var updatedCliente = await _clientesService.UpdateClienteAsync(id, clienteExistente);
            var updatedCliente1 = await _cliente1Service.UpdateCliente1(cliente.IdCliente1, cliente1Existente);
            if (updatedCliente == null)
            {
                var response = new ApiResponse<Cliente>
                {
                    Success = false,
                    Message = "Cliente no encontrado.",
                    Data = null,
                    Error = "Error al actualizar cliente"
                };
                return NotFound(response);
            }

            var successResponse = new ApiResponse<Cliente>
            {
                Success = true,
                Message = "Cliente actualizado exitosamente.",
                Data = updatedCliente,
                Error = null
            };
            return Ok(successResponse);
        }
    }
}
