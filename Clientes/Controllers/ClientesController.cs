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


namespace BackendVisitaNET.Controllers
{
    //[Authorize] // Requiere autenticación para acceder
    [Route("api/Clientes")]
    public class ClientesController : ODataController
    {
        private readonly ClientesService _clientesService;

        public ClientesController(ClientesService clientesService)
        {
            _clientesService = clientesService;
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
                    Categoria = cliente.Categoria,
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
                    TipoLIsta = cliente.TipoLIsta,
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


                var createdCliente = await _clientesService.CreateClienteAsync(newCliente, cliente1);
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
        public async Task<IActionResult> Put(long id, [FromBody] Cliente cliente)
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

            var updatedCliente = await _clientesService.UpdateClienteAsync(id, cliente);
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
