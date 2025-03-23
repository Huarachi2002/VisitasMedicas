using BackendVisitaNET.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Services;

namespace Usuario.Controllers
{
    public class UsuarioController : ODataController
    {

        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
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
                return BadRequest(response);
            }
        }
    }
}
