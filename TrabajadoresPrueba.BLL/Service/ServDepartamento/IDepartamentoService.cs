using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajadoresPrueba.DAL.DataContext;

namespace TrabajadoresPrueba.BLL.Service.ServDepartamento
{
    public interface IDepartamentoService
    {
        Task<bool> Insertar(Departamento modelo);
        Task<bool> Actualizar(Departamento modelo);
        Task<bool> Eliminar(int id);
        Task<Departamento> Obtener(int id);

        List<Departamento> ObtenerTodos();
    }
}
