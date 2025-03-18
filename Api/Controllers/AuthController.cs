using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using BackendVisitaNET.Models;
using Microsoft.AspNetCore.Identity.Data;
using BackendVisitaNET.Data;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        // Buscar usuario en la base de datos
        var usuario = _context.Usuarios
            .FirstOrDefault(u => u.Login == loginRequest.Login);

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

        // Verificar la contraseña encriptada
        string contrasenaEncriptada = EncriptarSHA256(loginRequest.Contrasena);
        if (usuario.Contrasena != contrasenaEncriptada)
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
            usuario.IdEmpleado
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

    private string EncriptarSHA256(string contrasena)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contrasena));
            return Convert.ToBase64String(hashBytes); // Base64 para coincidir con PHP
        }
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

// Modelo para recibir los datos de login
public class LoginRequest
{
    public string Login { get; set; }
    public string Contrasena { get; set; }
}
