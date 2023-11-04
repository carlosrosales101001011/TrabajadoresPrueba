using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajadoresPrueba.DAL.DataContext;

namespace TrabajadoresPrueba.DAL.Repositories
{
    public class DepartamentoRepository : IGenericRepository<Departamento>
    {
        private readonly TrabajadoresPruebaContext _context;
        public DepartamentoRepository(TrabajadoresPruebaContext context)
        {
            _context = context;
        }

        public async Task<bool> Actualizar(Departamento modelo)
        {
            _context.Departamentos.Update(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Departamento modelo = _context.Departamentos.First(c => c.Id == id);
            _context.Departamentos.Remove(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Departamento modelo)
        {
            _context.Departamentos.Add(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<Departamento> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public List<Departamento> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
