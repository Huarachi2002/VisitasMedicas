using BackendVisitaNET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Services
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
    }
}
