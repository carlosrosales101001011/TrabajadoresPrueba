using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajadoresPrueba.DAL;
using TrabajadoresPrueba.DAL.DataContext;
using TrabajadoresPrueba.DAL.Repositories;

namespace TrabajadoresPrueba.BLL.Service
{
    public class TrabajadoresService : ITrabajadoresService
    {
        private readonly IGenericRepository<Trabajadores> _repository;
        public readonly IConfiguration _config;
        public TrabajadoresService(IConfiguration config, IGenericRepository<Trabajadores> repository)
        {
            _config = config;
            _repository = repository;
        }
        public async Task<bool> Actualizar(Trabajadores modelo)
        {
            return await _repository.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {

            return await _repository.Eliminar(id);
        }

        public async Task<bool> Insertar(Trabajadores modelo)
        {
            return await _repository.Insertar(modelo);
        }

        public async Task<Trabajadores> Obtener(int id)
        {
            return await _repository.Obtener(id);

        }
        public List<Trabajadores> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }
    }
}
