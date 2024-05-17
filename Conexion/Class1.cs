using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Conexion
{
    public class Class1
    {
        public String sLastError = "";
        SqlConnection conexion;
        public static String GetConnectionString(String sServidor, String sUsuario, String sContrasena)
        {
            String sCadenaConnection = "";

            String sServer = sServidor;
            String sDataBase = "master";
            String sUserId = sUsuario;
            String sPassword = sContrasena;

            sCadenaConnection = $"Server={sServer};Database={sDataBase};User Id={sUserId};Password={sPassword}";

            return sCadenaConnection;

        }
        string cadenaConexion(string servidor, string usuario, string contraseña)
        {
            string cadena = "";
            cadena = $"Server={servidor};Database=master;User Id={usuario};Password={contraseña};";
            return cadena;
        }
        public bool UsuarioEsNuevoORequiereActualizarContrasena(string sServidor, string sUsuario, string sContrasena, string nombreUsuario)
        {
            string query = "SELECT PasswordActualizada FROM Usuarios WHERE NombreUsuario = @nombreUsuario";

            using (SqlConnection conn = new SqlConnection(dbSqlServer.GetConnectionString(sServidor, sUsuario, sContrasena)))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                conn.Open();
                var resultado = cmd.ExecuteScalar();

                if (resultado == null || resultado == DBNull.Value)
                {
                    // El usuario es nuevo.
                    return true;
                }

                bool passwordActualizada = Convert.ToBoolean(resultado);

                // Si passwordActualizada es 'true', el usuario ya actualizó su contraseña. Si es 'false', necesita actualizarla.
                return !passwordActualizada;
            }
        }
        public DataTable ConsultaDeBasedeDatos(string servidor, string usuario, string contraseña)
        {
            DataTable data = new DataTable();
            using (SqlConnection conectarBD = new SqlConnection(cadenaConexion(servidor, usuario, contraseña)))
            {
                try
                {
                    conectarBD.Open();
                    string Query = " SELECT name FROM sys.databases; ";
                    SqlCommand comando = new SqlCommand(Query, conectarBD);
                    data.Load(comando.ExecuteReader());
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                }
                finally
                {
                    conectarBD.Close();
                }
            }
            return data;
        }
    }
}
