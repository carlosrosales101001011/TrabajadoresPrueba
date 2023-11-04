using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajadoresPrueba.DAL.DataContext;

namespace TrabajadoresPrueba.DAL.Repositories
{
    public class ProvinciaRepository:IGenericRepository<Provincia>
    {
        private readonly TrabajadoresPruebaContext _context;
        public ProvinciaRepository(TrabajadoresPruebaContext context)
        {
            _context = context;
        }

        public async Task<bool> Actualizar(Provincia modelo)
        {
            _context.Provincia.Update(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Provincia modelo = _context.Provincia.First(c => c.Id == id);
            _context.Provincia.Remove(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Provincia modelo)
        {
            _context.Provincia.Add(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<Provincia> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public List<Provincia> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
