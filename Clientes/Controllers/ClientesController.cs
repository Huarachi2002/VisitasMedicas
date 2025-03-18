using BackendVisitaNET.Data;
using BackendVisitaNET.Models;
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
    [Route("odata/Clientes")]
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
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
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
                var createdCliente = await _clientesService.CreateClienteAsync(cliente);
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
