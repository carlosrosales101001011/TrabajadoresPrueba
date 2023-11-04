using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajadoresPrueba.DAL.DataContext;
using TrabajadoresPrueba.DAL.Repositories;

namespace TrabajadoresPrueba.BLL.Service.ServDepartamento
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IGenericRepository<Departamento> _repository;
        public DepartamentoService(IGenericRepository<Departamento> repo)
        {
            _repository = repo;
        }
        public async Task<bool> Actualizar(Departamento modelo)
        {
            return await _repository.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repository.Eliminar(id);
        }

        public async Task<bool> Insertar(Departamento modelo)
        {
            return await _repository.Insertar(modelo);
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
