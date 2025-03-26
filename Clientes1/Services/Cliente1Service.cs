using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDB.Models;

namespace Clientes1.Services
{
    public class Cliente1Service
    {
        private readonly AppDbContext _context;

        public Cliente1Service(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Cliente1> GetAllClientes1()
        {
            return _context.Cliente1.AsQueryable();
        }

        public async Task<Cliente1> CreateCliente1(Cliente1 cliente1)
        {
            try
            {
                _context.Cliente1.Add(cliente1);
                await _context.SaveChangesAsync();
                return cliente1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cliente1> UpdateCliente1(long id, Cliente1 cliente1)
        {
            try
            {
                var cliente1Existente = await _context.Cliente1.FindAsync(id);
                if (cliente1Existente == null) return null;

                _context.Entry(cliente1Existente).CurrentValues.SetValues(cliente1);
                await _context.SaveChangesAsync();
                return cliente1Existente;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
