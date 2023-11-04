using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajadoresPrueba.DAL
{
    public class Conexion
    {
        private readonly string _connectionString;
        public Conexion(string connectionString)
        {
            _connectionString = connectionString;
        }
        public SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(_connectionString);
            conexion.Open();
            return conexion;
        }
    }
}
