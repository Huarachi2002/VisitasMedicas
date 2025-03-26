using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Categorias.Services;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Mvc;
using AppDB.Models;
using BackendVisitaNET.Data;

namespace Categorias.Controllers
{
    [Route("api/Categorias")]
    public class CategoriaController : ODataController
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var query = _categoriaService.GetAllCategorias();
                return Ok(query);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<Categoria>>
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
        public async Task<IActionResult> Post([FromBody] Categoria categoria)
        {
            if(categoria == null)
            {
                var response = new ApiResponse<Categoria>
                {
                    Success = false,
                    Message = "Formato de categoria incorrecto.",
                    Data = null,
                    Error = "Error al crear categoria"
                };
                return BadRequest(response);
            }

            try
            {
                var createdCategoria = await _categoriaService.CreateCategoria(categoria);
                var response = new ApiResponse<Categoria>
                {
                    Success = true,
                    Message = "Categoria creada correctamente.",
                    Data = createdCategoria,
                    Error = null
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<Categoria>
                {
                    Success = false,
                    Message = "Error al crear categoria.",
                    Data = null,
                    Error = ex.Message
                };
                return BadRequest(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Categoria categoria)
        {
            if (categoria == null || id != categoria.Id)
            {
                var response = new ApiResponse<Categoria>
                {
                    Success = false,
                    Message = "Id no coincide con la categoria proporcionada.",
                    Data = null,
                    Error = "Error al actualizar categoria"
                };
                return BadRequest(response);
            }
            try
            {
                var updatedCategoria = await _categoriaService.UpdateCategoria(id, categoria);
                if (updatedCategoria == null)
                {
                    var response = new ApiResponse<Categoria>
                    {
                        Success = false,
                        Message = "Categoria no encontrada.",
                        Data = null,
                        Error = "Error al actualizar categoria"
                    };
                    return NotFound(response);
                }
                var successResponse = new ApiResponse<Categoria>
                {
                    Success = true,
                    Message = "Categoria actualizada correctamente.",
                    Data = updatedCategoria,
                    Error = null
                };
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<Categoria>
                {
                    Success = false,
                    Message = "Error al actualizar categoria.",
                    Data = null,
                    Error = ex.Message
                };
                return BadRequest(response);
            }
        }
    }
}
