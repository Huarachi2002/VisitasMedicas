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

        public async Task<Cliente> CreateClienteAsync(Cliente cliente, Cliente1 cliente1)
        {
            using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Cliente1.Add(cliente1);
                    await _context.SaveChangesAsync();

                    cliente.IdCliente1 = cliente1.Id;

                    _context.Clientes.Add(cliente);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return cliente;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<Cliente> UpdateClienteAsync(long id, Cliente cliente)
        {
            var clienteExistente = await _context.Clientes.FindAsync(id);
            if (clienteExistente == null) return null;

            cliente.FechaRegistro = cliente.FechaRegistro.ToUniversalTime();
            cliente.fecha = cliente.fecha?.ToUniversalTime();
            cliente.FechaUltimaCompra = cliente.FechaUltimaCompra.ToUniversalTime();

            _context.Entry(clienteExistente).CurrentValues.SetValues(cliente);
            await _context.SaveChangesAsync();
            return clienteExistente;
        }

    }
}
