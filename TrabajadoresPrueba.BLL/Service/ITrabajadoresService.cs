using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajadoresPrueba.DAL.DataContext;

namespace TrabajadoresPrueba.BLL.Service
{
    public interface ITrabajadoresService
    {
        Task<bool> Insertar(Trabajadores modelo);
        Task<bool> Actualizar(Trabajadores modelo);
        Task<bool> Eliminar(int id);
        Task<Trabajadores> Obtener(int id);
        List<Trabajadores> ObtenerTodos();

    }
}
