using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajadoresPrueba.DAL.DataContext;

namespace TrabajadoresPrueba.BLL.Service.ServProvincia
{
    public interface IProvinciaService
    {
        Task<bool> Insertar(Provincia modelo);
        Task<bool> Actualizar(Provincia modelo);
        Task<bool> Eliminar(int id);
        Task<Provincia> Obtener(int id);
        List<Provincia> ObtenerTodos();
    }
}
