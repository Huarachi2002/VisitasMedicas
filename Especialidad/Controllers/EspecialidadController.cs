using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Especialidades.Services;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using AppDB.Models;
using BackendVisitaNET.Data;

namespace Especialidades.Controllers
{
    [Route("api/Especialidades")]
    public class EspecialidadController : ODataController
    {
        private readonly EspecialidadService _especialidadService;

        public EspecialidadController(EspecialidadService especialidadService)
        {
            _especialidadService = especialidadService;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var query = _especialidadService.GetAllEspecialidades();
                return Ok(query);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<Especialidad>>
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
        public async Task<IActionResult> Post([FromBody] Especialidad especialidad)
        {
            if (especialidad == null)
            {
                var response = new ApiResponse<Especialidad>
                {
                    Success = false,
                    Message = "Formato de especialidad incorrecto.",
                    Data = null,
                    Error = "Error al crear especialidad"
                };
                return BadRequest(response);
            }
            try
            {
                var result = await _especialidadService.CreateEspecialidad(especialidad);
                var response = new ApiResponse<Especialidad>
                {
                    Success = true,
                    Message = "Especialidad creada con éxito.",
                    Data = result,
                    Error = null
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<Especialidad>
                {
                    Success = false,
                    Message = "Error al crear especialidad.",
                    Data = null,
                    Error = ex.Message
                };
                return BadRequest(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Especialidad especialidad)
        { 
            if(especialidad == null || id != especialidad.Id)
            {
                var response = new ApiResponse<Especialidad>
                {
                    Success = false,
                    Message = "Id no coincide con la especialidad proporcionado.",
                    Data = null,
                    Error = "Error al actualizar especialidad"
                };
                return BadRequest(response);
            }

            var updatedEspecialidad = await _especialidadService.UpdateEspecialidad(id, especialidad);
            
            if (updatedEspecialidad == null)
            {
                var response = new ApiResponse<Especialidad>
                {
                    Success = false,
                    Message = "Especialidad no encontrada.",
                    Data = null,
                    Error = "Error al actualizar especialidad"
                };
                return NotFound(response);
            }

            var successResponse = new ApiResponse<Especialidad>
            {
                Success = true,
                Message = "Especialidad actualizada exitosamente.",
                Data = updatedEspecialidad,
                Error = null
            };
            return Ok(successResponse);
        }

    }
}
