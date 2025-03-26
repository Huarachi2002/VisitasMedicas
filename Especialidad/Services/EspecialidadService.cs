using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDB.Models;

namespace Especialidades.Services
{
    public class EspecialidadService
    {
        private readonly AppDbContext _context;

        public EspecialidadService(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Especialidad> GetAllEspecialidades()
        {
            return _context.Especialidades.AsQueryable();
        }

        public async Task<Especialidad> CreateEspecialidad(Especialidad especialidad)
        {
            try
            {
                _context.Especialidades.Add(especialidad);
                await _context.SaveChangesAsync();
                return especialidad;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Especialidad> UpdateEspecialidad(long id, Especialidad especialidad)
        {
            var especialidadExistente = await _context.Especialidades.FindAsync(id);
            if (especialidadExistente == null) return null;
            _context.Entry(especialidadExistente).CurrentValues.SetValues(especialidad);
            await _context.SaveChangesAsync();
            return especialidadExistente;
        }
    }
}
