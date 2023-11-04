using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajadoresPrueba.DAL.DataContext;

namespace TrabajadoresPrueba.DAL.Repositories
{
    public class DistritoRepository:IGenericRepository<Distrito>
    {

        private readonly TrabajadoresPruebaContext _context;

        public DistritoRepository(TrabajadoresPruebaContext context)
        {
            _context = context;
        }

        public async Task<bool> Actualizar(Distrito modelo)
        {
            _context.Distritos.Update(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Distrito modelo = _context.Distritos.First(c => c.Id == id);
            _context.Distritos.Remove(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Distrito modelo)
        {
            _context.Distritos.Add(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<Distrito> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public List<Distrito> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
