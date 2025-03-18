using BackendVisitaNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Services
{
    public class EmpleadosService
    {
        private readonly AppDbContext _context;

        public EmpleadosService(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Empleado> GetAllEmpleados()
        {
            return _context.Empleados.AsQueryable();
        }

        public async Task<Empleado> CreateEmpleadoAsync(Empleado empleado)
        {
            empleado.FechaRegistro = empleado.FechaRegistro.ToUniversalTime();
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task<Empleado> UpdateEmpleadoAsync(long id, Empleado empleado)
        {
            var empleadoExistente = await _context.Empleados.FindAsync(id);
            if (empleadoExistente == null) return null;

            empleado.FechaRegistro = empleado.FechaRegistro.ToUniversalTime();
            _context.Entry(empleadoExistente).CurrentValues.SetValues(empleado);
            await _context.SaveChangesAsync();
            return empleadoExistente;
        }

    }
}
