using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajadoresPrueba.DAL.DataContext;
using TrabajadoresPrueba.DAL.Repositories;

namespace TrabajadoresPrueba.BLL.Service.ServDistrito
{
    internal class DistritoService : IDistritoService
    {
        private readonly IGenericRepository<Distrito> _repository;
        public DistritoService(IGenericRepository<Distrito> repository)
        {
            _repository = repository;
        }
        public Task<bool> Actualizar(Distrito modelo)
        {
            return _repository.Actualizar(modelo);
        }

        public Task<bool> Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }

        public Task<bool> Insertar(Distrito modelo)
        {
            return _repository.Insertar(modelo);
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
