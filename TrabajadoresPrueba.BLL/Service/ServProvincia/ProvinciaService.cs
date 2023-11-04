using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajadoresPrueba.DAL.DataContext;
using TrabajadoresPrueba.DAL.Repositories;

namespace TrabajadoresPrueba.BLL.Service.ServProvincia
{
    public class ProvinciaService : IProvinciaService
    {
        private readonly IGenericRepository<Provincia> _repository;
        public ProvinciaService(IGenericRepository<Provincia> repo)
        {
            _repository= repo;
        }
        public Task<bool> Actualizar(Provincia modelo)
        {
            return _repository.Actualizar(modelo);
        }

        public Task<bool> Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }

        public Task<bool> Insertar(Provincia modelo)
        {
            return _repository.Insertar(modelo);
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
