using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDB.Models;

namespace Periodos.Services
{
    public class PeriodoService
    {
        private readonly AppDbContext _context;

        public PeriodoService(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Periodo> GetAllPeriodos()
        {
            return _context.Periodos.AsQueryable();
        }
        
        public async Task<Periodo> CreatePeriodo(Periodo periodo)
        {
            try
            {
                _context.Periodos.Add(periodo);
                await _context.SaveChangesAsync();
                return periodo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Periodo> UpdatePeriodo(long id, Periodo periodo)
        {
            var periodoExistente = await _context.Periodos.FindAsync(id);
            if (periodoExistente == null) return null;
            _context.Entry(periodoExistente).CurrentValues.SetValues(periodo);
            await _context.SaveChangesAsync();
            return periodoExistente;
        }
    }
}
