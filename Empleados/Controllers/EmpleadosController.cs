﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using BackendVisitaNET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Formatter;
using BackendVisitaNET.Data;
using Empleados.Services;

namespace BackendVisitaNET.Controllers
{
    //[Authorize] // Requiere autenticación para acceder
    [Route("odata/Empleados")]
    public class EmpleadosController : ODataController
    {
        private readonly EmpleadosService _empleadosService;

        public EmpleadosController(EmpleadosService empleadosService)
        {
            _empleadosService = empleadosService;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var query = _empleadosService.GetAllEmpleados();
                return Ok(query);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<Empleado>>
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
        public async Task<IActionResult> Post([FromBody] Empleado empleado)
        {
            if (empleado == null)
            {
                var response = new ApiResponse<Empleado>
                {
                    Success = false,
                    Message = "Formato de empleado incorrecto.",
                    Data = null,
                    Error = "Error al crear empleado"
                };
                return BadRequest(response);
            }

            try
            {
                var createdEmpleado = await _empleadosService.CreateEmpleadoAsync(empleado);
                var response = new ApiResponse<Empleado>
                {
                    Success = true,
                    Message = "Empleado creado exitosamente.",
                    Data = createdEmpleado,
                    Error = null
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<Empleado>
                {
                    Success = false,
                    Message = "Error al crear el empleado.",
                    Data = null,
                    Error = ex.Message
                };
                return BadRequest(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Empleado empleado)
        {
            if (empleado == null || id != empleado.Id)
            {
                var response = new ApiResponse<Empleado>
                {
                    Success = false,
                    Message = "Id no coincide con el empleado proporcionado.",
                    Data = null,
                    Error = "Error al actualizar empleado"
                };
                return BadRequest(response);
            }

            var updatedEmpleado = await _empleadosService.UpdateEmpleadoAsync(id, empleado);
            if (updatedEmpleado == null)
            {
                var response = new ApiResponse<Empleado>
                {
                    Success = false,
                    Message = "Empleado no encontrado.",
                    Data = null,
                    Error = "Error al actualizar empleado"
                };
                return NotFound(response);
            }

            var successResponse = new ApiResponse<Empleado>
            {
                Success = true,
                Message = "Empleado actualizado exitosamente.",
                Data = updatedEmpleado,
                Error = null
            };
            return Ok(successResponse);
        }
    }
}
