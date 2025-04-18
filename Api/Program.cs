﻿using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OData.ModelBuilder;
using AppDB.Models;
using Microsoft.AspNetCore.Authorization;
using Clientes.Services;
using Empleados.Services;
using Sucursales.Services;
using Regionales.Services;
using Usuarios.Services;
using EmpleadoEspecialidades.Services;
using Periodos.Services;
using Categorias.Services;
using System.Text.Json.Serialization;
using Especialidades.Services;
using Clientes1.Services;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);

// Configurar la conexión a PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"),
                      b => b.MigrationsAssembly("AppDB"));
});


// Configurar OData con las entidades permitidas
ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Regional>("Regional");
modelBuilder.EntitySet<Sucursal>("Sucursal");
modelBuilder.EntitySet<Cliente>("Clientes");
modelBuilder.EntitySet<Cliente1>("Cliente1");
modelBuilder.EntitySet<Empleado>("Empleados");
modelBuilder.EntitySet<TipoUsuario>("TipoUsuario");
modelBuilder.EntitySet<Usuario>("Usuarios");
modelBuilder.EntitySet<EmpleadoEspecialidad>("EmpleadoEspecialidades");
modelBuilder.EntitySet<Especialidad>("Especialidades");
modelBuilder.EntitySet<Periodo>("Periodos");
modelBuilder.EntitySet<Categoria>("Categorias");


var jwtIssuer = builder.Configuration.GetValue<string>("Jwt:Issuer");
var jwtAudience = builder.Configuration.GetValue<string>("Jwt:Audience");
var jwtKey = builder.Configuration.GetValue<string>("Jwt:Key");

if (string.IsNullOrEmpty(jwtKey) || jwtKey.Length < 32)
{
    throw new Exception("La clave JWT debe tener al menos 32 caracteres para seguridad.");
}

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

})
.AddJwtBearer(option =>
{
    option.RequireHttpsMetadata = false;
    option.SaveToken = true;
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = key,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,  // 🔹 Ahora validamos la expiración del token
        ClockSkew = TimeSpan.Zero, // 🔹 Evita problemas de desfase horario en validación de tokens
        ValidateIssuerSigningKey = true
    };
    option.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine($"Error de autenticación: {context.Exception.Message}");
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            Console.WriteLine("Token validado correctamente.");
            return Task.CompletedTask;
        }
    };

});

builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    // 🔹 Definimos una política específica para usuarios con rol "1"
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireAuthenticatedUser().RequireRole("1"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularFrontend", policy =>
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials());
});

builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<Cliente1Service>();
builder.Services.AddScoped<SucursalesService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<EmpleadoEspecialidadService>();
builder.Services.AddScoped<RegionalesService>();
builder.Services.AddScoped<EmpleadosService>();
builder.Services.AddScoped<PeriodoService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<EspecialidadService>();
builder.Services.AddControllers()
    .AddOData(opt => opt
        .Select()
        .Filter()
        .OrderBy()
        .Expand()
        .Count()
        //.SetMaxTop(100) // Opcional, establece un límite de resultados
        .AddRouteComponents("odata", modelBuilder.GetEdmModel()))
        .AddJsonOptions(x => { 
            //x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; 
            
            x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
             
        });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAngularFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
