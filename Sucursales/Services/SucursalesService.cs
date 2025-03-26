using AppDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sucursales.Services
{
    public class SucursalesService
    {
        private readonly AppDbContext _context;
        public SucursalesService(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Sucursal> GetAllSucursales()
        {
            return _context.Sucursal.AsQueryable();
        }

        public async Task<Sucursal> CreateSucursalAsync(Sucursal sucursal)
        {
            try
            {
                _context.Sucursal.Add(sucursal);
                await _context.SaveChangesAsync();
                return sucursal;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Sucursal> UpdateSucursalAsync(long id, Sucursal sucursal)
        {
            var sucursalExistente = await _context.Sucursal.FindAsync(id);
            if (sucursalExistente == null) return null;

            _context.Entry(sucursalExistente).CurrentValues.SetValues(sucursal);
            await _context.SaveChangesAsync();
            return sucursalExistente;
        }
    }
}
