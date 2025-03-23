using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using BackendVisitaNET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Formatter;
using BackendVisitaNET.Data;
using Sucursales.Services;


namespace BackendVisitaNET.Controllers
{
    [Route("api/Sucursales")]
    public class SucursalesController : ODataController
    {
        private readonly SucursalesService _sucursalesService;
        public SucursalesController(SucursalesService sucursalesService)
        {
            _sucursalesService = sucursalesService;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var query = _sucursalesService.GetAllSucursales();
                return Ok(query);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<Sucursal>>
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
        public async Task<IActionResult> Post([FromBody] Sucursal sucursal)
        {
            if (sucursal == null)
            {
                var response = new ApiResponse<Sucursal>
                {
                    Success = false,
                    Message = "Formato de sucursal incorrecto.",
                    Data = null,
                    Error = "Error al crear sucursal"
                };
                return BadRequest(response);
            }

            try
            {
                var createdSucursal = await _sucursalesService.CreateSucursalAsync(sucursal);
                var response = new ApiResponse<Sucursal>
                {
                    Success = true,
                    Message = "Sucursal creado exitosamente.",
                    Data = createdSucursal,
                    Error = null
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<Sucursal>
                {
                    Success = false,
                    Message = "Error al crear el sucursal.",
                    Data = null,
                    Error = ex.Message
                };
                return BadRequest(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Sucursal sucursal)
        {
            if (sucursal == null || id != sucursal.Id)
            {
                var response = new ApiResponse<Sucursal>
                {
                    Success = false,
                    Message = "Id no coincide con el sucursal proporcionado.",
                    Data = null,
                    Error = "Error al actualizar sucursal"
                };
                return BadRequest(response);
            }

            var updatedSucursal = await _sucursalesService.UpdateSucursalAsync(id, sucursal);
            if (updatedSucursal == null)
            {
                var response = new ApiResponse<Sucursal>
                {
                    Success = false,
                    Message = "Sucursal no encontrado.",
                    Data = null,
                    Error = "Error al actualizar sucursal"
                };
                return NotFound(response);
            }

            var successResponse = new ApiResponse<Sucursal>
            {
                Success = true,
                Message = "Sucursal actualizado exitosamente.",
                Data = updatedSucursal,
                Error = null
            };
            return Ok(successResponse);
        }
    }
}

   
