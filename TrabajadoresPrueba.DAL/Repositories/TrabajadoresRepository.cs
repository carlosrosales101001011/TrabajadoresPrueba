using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TrabajadoresPrueba.DAL.DataContext;

namespace TrabajadoresPrueba.DAL.Repositories
{
    public class TrabajadoresRepository : IGenericRepository<Trabajadores>
    {
        private readonly TrabajadoresPruebaContext _context;
        public readonly IConfiguration _config;
        public TrabajadoresRepository(IConfiguration config, TrabajadoresPruebaContext context)
        {
            _context = context;
            _config = config;
        }
        public async Task<bool> Actualizar(Trabajadores modelo)
        {
            _context.Trabajadores.Update(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Trabajadores modelo = _context.Trabajadores.First(c => c.Id == id);
            _context.Trabajadores.Remove(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Trabajadores modelo)
        {
            _context.Trabajadores.Add(modelo);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<Trabajadores> Obtener(int id)
        {
            return await _context.Trabajadores.FindAsync(id);
        }

        public List<Trabajadores> ObtenerTodos()
        {
            SqlConnection cnn = new SqlConnection(_config["ConnectionStrings:cadenaSQL"]);
            SqlDataAdapter da = new SqlDataAdapter("sp_listar_trabajadores", cnn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
             List<Trabajadores> lstTrabajadores = new List<Trabajadores>();
            if (dt.Rows.Count > 0)
            {
            cnn.Open();
                for (int i=0; i<dt.Rows.Count; i++)
                {
                    lstTrabajadores.Add(new Trabajadores()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                        TipoDocumento = dt.Rows[i]["TipoDocumento"].ToString(),
                        NumeroDocumento = dt.Rows[i]["NumeroDocumento"].ToString(),
                        Nombres = dt.Rows[i]["Nombres"].ToString(),
                        Sexo = dt.Rows[i]["Sexo"].ToString(),
                        IdDepartamento= Convert.ToInt32(dt.Rows[i]["IdDep"]),
                        IdProvincia = Convert.ToInt32(dt.Rows[i]["IdProv"]),
                        IdDistrito= Convert.ToInt32(dt.Rows[i]["IdDis"]),
                        oDepartamento = new Departamento() { Id= Convert.ToInt32(dt.Rows[i]["IdDep"]), NombreDepartamento= dt.Rows[i]["Departamento"].ToString() },
                        oProvincia = new Provincia() { Id = Convert.ToInt32(dt.Rows[i]["IdProv"]), NombreProvincia = dt.Rows[i]["Provincia"].ToString() },
                        oDistrito = new Distrito() { Id = Convert.ToInt32(dt.Rows[i]["IdDis"]), NombreDistrito = dt.Rows[i]["Distrito"].ToString() },


                    });
                }
            cnn.Close();
            }
            if (lstTrabajadores.Count>0)
            {
                return lstTrabajadores;
            }
            else
            {
                return null;
            }




        }
    }
}
