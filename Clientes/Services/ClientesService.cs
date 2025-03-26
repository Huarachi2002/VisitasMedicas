using AppDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Services
{
    public class ClientesService
    {
        private readonly AppDbContext _context;

        public ClientesService(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Cliente> GetAllClientes()
        {
            return _context.Clientes.AsQueryable();
        }

        public async Task<Cliente> CreateClienteAsync(long IdCliente1 ,Cliente cliente)
        {
            try
            {
                cliente.IdCliente1 = IdCliente1;
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cliente> UpdateClienteAsync(long id, Cliente cliente)
        {
            var clienteExistente = await _context.Clientes.FindAsync(id);
            if ( clienteExistente == null ) return null;

            try
            {
                _context.Entry(clienteExistente).CurrentValues.SetValues(cliente);
                await _context.SaveChangesAsync();
                return clienteExistente;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
