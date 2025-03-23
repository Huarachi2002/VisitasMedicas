using BackendVisitaNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Services
{
    public class UsuarioService
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Usuario> GetAllUsuarios()
        {
            return _context.Usuarios.AsQueryable();
        }

        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Usuario> UpdateUsuarioAsync(long id, Usuario usuario)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(id);
            if (usuarioExistente == null) return null;

            _context.Entry(usuarioExistente).CurrentValues.SetValues(usuario);
            await _context.SaveChangesAsync();
            return usuarioExistente;
        }
    }
}
