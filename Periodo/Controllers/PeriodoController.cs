using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Periodos.Services;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Mvc;
using AppDB.Models;
using BackendVisitaNET.Data;

namespace Periodos.Controllers
{
    [Route("api/Periodos")]
    class PeriodoController : ODataController
    {
        private readonly PeriodoService _periodoService;

        public PeriodoController(PeriodoService periodoService)
        {
            _periodoService = periodoService;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var query = _periodoService.GetAllPeriodos();
                return Ok(query);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<Periodo>>
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
        public async Task<IActionResult> Post([FromBody] Periodo periodo)
        {
            if (periodo == null)
            {
                var response = new ApiResponse<Periodo>
                {
                    Success = false,
                    Message = "Formato de periodo incorrecto.",
                    Data = null,
                    Error = "Error al crear periodo"
                };
                return BadRequest(response);
            }

            try
            {
                var createdEmpleado = await _periodoService.CreatePeriodo(periodo);
                var response = new ApiResponse<Periodo>
                {
                    Success = true,
                    Message = "Periodo creado correctamente.",
                    Data = createdEmpleado,
                    Error = null
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<Periodo>
                {
                    Success = false,
                    Message = "Error al crear el periodo.",
                    Data = null,
                    Error = ex.Message
                };
                return BadRequest(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id,[FromBody] Periodo periodo)
        {
            if (periodo == null || id != periodo.Id)
            {
                var response = new ApiResponse<Periodo>
                {
                    Success = false,
                    Message = "Id no coincide con el periodo proporcionado.",
                    Data = null,
                    Error = "Error al actualizar periodo"
                };
                return BadRequest(response);
            }
            try
            {
                var updatedPeriodo = await _periodoService.UpdatePeriodo(id, periodo);
                if (updatedPeriodo == null)
                {
                    var response = new ApiResponse<Periodo>
                    {
                        Success = false,
                        Message = "Periodo no encontrado.",
                        Data = null,
                        Error = "Error al actualizar periodo"
                    };
                    return NotFound(response);
                }
                var successResponse = new ApiResponse<Periodo>
                {
                    Success = true,
                    Message = "Periodo actualizado correctamente.",
                    Data = updatedPeriodo,
                    Error = null
                };
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<Periodo>
                {
                    Success = false,
                    Message = "Error al actualizar el periodo.",
                    Data = null,
                    Error = ex.Message
                };
                return BadRequest(response);
            }
        }
    }
}
