using AppDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoEspecialidades.Services
{
    public class EmpleadoEspecialidadService
    {
        private readonly AppDbContext _context;

        public EmpleadoEspecialidadService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmpleadoEspecialidad>> AddEspecialidadesToEmpleado(long IdEmpleado, List<long> especialidadIds)
        {
            var empleado = await _context.Empleados.FindAsync(IdEmpleado);
            if (empleado == null)
            {
                throw new Exception("Empleado no encontrado");
            }

            var especialidades = await _context.Especialidades
                .Where(es => especialidadIds.Contains(es.Id))
                .ToListAsync();

            if (especialidades.Count != especialidadIds.Count)
            {
                throw new Exception("Algunas especialidades no existen");
            }

            var empleadoEspecialidades = especialidades.Select(e => new EmpleadoEspecialidad
            {
                IdEmpleado = IdEmpleado,
                IdEspecialidad = e.Id
            }).ToList();

            await _context.EmpleadoEspecialidades.AddRangeAsync(empleadoEspecialidades);
            await _context.SaveChangesAsync();
            return empleadoEspecialidades;
        }

        public async Task<List<Especialidad>> GetEspecialidadesByEmpleadoId(long IdEmpleado)
        {
            return await _context.EmpleadoEspecialidades
                .Where(e => e.IdEmpleado == IdEmpleado)
                .Select(e => e.Especialidad)
                .ToListAsync();
        }

    }
}