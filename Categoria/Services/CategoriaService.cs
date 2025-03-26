using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDB.Models;

namespace Categorias.Services
{
    public class CategoriaService
    {
        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Categoria> GetAllCategorias()
        {
            return _context.Categorias.AsQueryable();
        }

        public async Task<Categoria> CreateCategoria(Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return categoria;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Categoria> UpdateCategoria(long id, Categoria categoria)
        {
            var categoriaExistente = await _context.Categorias.FindAsync(id);
            if (categoriaExistente == null) return null;
            _context.Entry(categoriaExistente).CurrentValues.SetValues(categoria);
            await _context.SaveChangesAsync();
            return categoriaExistente;
        }
    }
}
