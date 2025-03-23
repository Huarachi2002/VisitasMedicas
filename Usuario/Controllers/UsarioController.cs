using BackendVisitaNET.Data;
using BackendVisitaNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Services;

namespace Usuarios.Controllers
{
    [Route("api/Usuarios")]
    public class UsarioController : ODataController
    {
        private readonly UsuarioService _usuarioService;
        public UsarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var query = _usuarioService.GetAllUsuarios();
                return Ok(query);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<Usuario>>
                {
                    Success = false,
                    Message = "Error al obtener data.",
                    Data = null,
                    Error = ex.Message
                };
                return BadRequest(response); ;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                var response = new ApiResponse<Usuario>
                {
                    Success = false,
                    Message = "Formato de usuario incorrecto.",
                    Data = null,
                    Error = "Error al crear usuario"
                };
                return BadRequest(response);
            }

            try
            {
                var createdUsuario = await _usuarioService.CreateUsuarioAsync(usuario);
                var response = new ApiResponse<Usuario>
                {
                    Success = true,
                    Message = "Usuario creado exitosamente.",
                    Data = createdUsuario,
                    Error = null
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<Usuario>
                {
                    Success = false,
                    Message = "Error al crear el usuario.",
                    Data = null,
                    Error = ex.Message
                };
                return BadRequest(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Usuario usuario)
        {
            if (usuario == null || id != usuario.Id)
            {
                var response = new ApiResponse<Usuario>
                {
                    Success = false,
                    Message = "Id no coincide con el usuario proporcionado.",
                    Data = null,
                    Error = "Error al actualizar usuario"
                };
                return BadRequest(response);
            }

            var updatedUsuario = await _usuarioService.UpdateUsuarioAsync(id, usuario);
            if (updatedUsuario == null)
            {
                var response = new ApiResponse<Usuario>
                {
                    Success = false,
                    Message = "Usuario no encontrado.",
                    Data = null,
                    Error = "Error al actualizar usuario"
                };
                return NotFound(response);
            }

            var successResponse = new ApiResponse<Usuario>
            {
                Success = true,
                Message = "Usuario actualizado exitosamente.",
                Data = updatedUsuario,
                Error = null
            };
            return Ok(successResponse);
        }
    }
}
