using BackendVisitaNET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regionales.Services
{
    public class RegionalesService
    {
        private readonly AppDbContext _context;
        public  RegionalesService(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Regional> GetAllRegionales()
        {
            return _context.Regional.AsQueryable();
        }

        public async Task<Regional> CreateRegionalAsync(Regional regional)
        {
            try
            {
                _context.Regional.Add(regional);
                await _context.SaveChangesAsync();
                return regional;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Regional> UpdateRegionalAsync(long id, Regional regional)
        {
            var regionalExistente = await _context.Regional.FindAsync(id);
            if (regionalExistente == null) return null;

            _context.Entry(regionalExistente).CurrentValues.SetValues(regional);
            await _context.SaveChangesAsync();
            return regionalExistente;
        }
    }
}
