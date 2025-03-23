using BackendVisitaNET.Data;
using BackendVisitaNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Services;

namespace Usuarios.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ODataController
    {
        private readonly UsuarioService _usuarioService;
        private readonly IConfiguration _configuration;

        public AuthController(UsuarioService usuarioService, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            // Buscar usuario en la base de datos
            var usuario = await _usuarioService.GetAllUsuarios()
                                       .Where(u => u.Login == loginRequest.Login)
                                       .FirstOrDefaultAsync();

            if (usuario == null || usuario.Estado != 1)
            {
                return Unauthorized(
                    new ApiResponse<String>
                    {
                        Success = false,
                        Message = "Usuario no encontrado o inactivo.",
                        Data = null,
                        Error = "Error al iniciar sesion."
                    }
                );
            }

            if (usuario.Contrasena != loginRequest.Contrasena)
            {
                return Unauthorized(
                    new ApiResponse<String>
                    {
                        Success = false,
                        Message = "Contraseña incorrecta.",
                        Data = null,
                        Error = "Error al iniciar sesion."
                    }
                );
            }
            // Generar Token JWT
            var token = GenerarTokenJWT(usuario);
            var data = new
            {
                token = token,
                IdEmpleado = usuario.IdEmpleado,
            };
            var response = new ApiResponse<object>
            {
                Success = true,
                Message = "Inicio de sesion exitosa.",
                Data = data,
                Error = null
            };
            return Ok(response);
        }

        private string GenerarTokenJWT(Usuario usuario)
            {
                var secretKey = _configuration["Jwt:Key"];
                var key = Encoding.UTF8.GetBytes(secretKey);

                // Verificar que la clave tenga al menos 32 caracteres (256 bits)
                if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 32)
                {
                    throw new Exception("La clave secreta JWT es demasiado corta. Debe tener al menos 32 caracteres.");
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim(ClaimTypes.Name, usuario.Login),
                new Claim("IdUsuario", usuario.Id.ToString()),
                new Claim("IdEmpleado", usuario.IdEmpleado.ToString()),
            }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);

            }
        }
    } 



public class LoginRequest
{
    public string Login { get; set; }
    public string Contrasena { get; set; }
}