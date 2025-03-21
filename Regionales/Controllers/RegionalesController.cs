using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using BackendVisitaNET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Formatter;
using BackendVisitaNET.Data;
using Regionales.Services;
using System.Data.SqlTypes;

namespace BackendVisitaNET.Controllers
{
    [Route("odata/Regionales")]
    public class RegionalesController : ODataController
    {
        private readonly RegionalesService _regionalesSevice;
        public RegionalesController(RegionalesService regionalesService)
        {
            _regionalesSevice = regionalesService;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var query = _regionalesSevice.GetAllRegionales();
                return Ok(query);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<Regional>>
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
        public async Task<IActionResult> Post([FromBody] Regional regional)
        {
            if (regional == null)
            {
                var response = new ApiResponse<Regional>
                {
                    Success = false,
                    Message = "Formato de regional incorrecto.",
                    Data = null,
                    Error = "Error al crear regional"
                };
                return BadRequest(response);
            }

            try
            {
                var createdRegional = await _regionalesSevice.CreateRegionalAsync(regional);
                var response = new ApiResponse<Regional>
                {
                    Success = true,
                    Message = "Regional creado exitosamente.",
                    Data = createdRegional,
                    Error = null
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<Regional>
                {
                    Success = false,
                    Message = "Error al crear el regional.",
                    Data = null,
                    Error = ex.Message
                };
                return BadRequest(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Regional regional)
        {
            if (regional == null || id != regional.Id)
            {
                var response = new ApiResponse<Regional>
                {
                    Success = false,
                    Message = "Id no coincide con el regional proporcionado.",
                    Data = null,
                    Error = "Error al actualizar regional"
                };
                return BadRequest(response);
            }

            var updatedRegional = await _regionalesSevice.UpdateRegionalAsync(id, regional);
            if (updatedRegional == null)
            {
                var response = new ApiResponse<Regional>
                {
                    Success = false,
                    Message = "Regional no encontrado.",
                    Data = null,
                    Error = "Error al actualizar regional"
                };
                return NotFound(response);
            }

            var successResponse = new ApiResponse<Regional>
            {
                Success = true,
                Message = "Regional actualizado exitosamente.",
                Data = updatedRegional,
                Error = null
            };
            return Ok(successResponse);
        }
    }
}
