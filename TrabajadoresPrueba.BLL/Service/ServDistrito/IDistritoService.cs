using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajadoresPrueba.DAL.DataContext;

namespace TrabajadoresPrueba.BLL.Service.ServDistrito
{
    public interface IDistritoService
    {
        Task<bool> Insertar(Distrito modelo);
        Task<bool> Actualizar(Distrito modelo);
        Task<bool> Eliminar(int id);
        Task<Distrito> Obtener(int id);
        List<Distrito> ObtenerTodos();
    }
}
