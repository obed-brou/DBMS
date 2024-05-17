using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class dbSqlServer
    {
        public String sLastError;
        private SqlConnection conexion;
        public class DatosDeInicio
        {
            public String sServidor;
            public String sUsuario;
            public String sContrasena;
        }
        DataTable datagrid = new DataTable();
        public string ConnectionString;

        public dbSqlServer(String sServer, String sUsuario, String sPassword)
        {
            conexion = new SqlConnection($"Server={sServer};Database=master;User Id={sUsuario};Password={sPassword};");
        }
        public DataTable Datagrid(String sComando)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand(sComando, conexion))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;

        }
        public Boolean AbrirConexion()
        {
            Boolean bAllOk = true;

            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;
                bAllOk = false;
            }

            return bAllOk;
        }
        public Boolean EjecutarComando(String sComando)
        {
            Boolean bAllOk = true;
            try
            {
                using (SqlCommand cmd = new SqlCommand(sComando, conexion))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;
                bAllOk = false;
            }
            return bAllOk;
        }
        public Boolean ConexionAbierta()
        {
            Boolean bAllOk = true;
            try
            {
                bAllOk = conexion.State == System.Data.ConnectionState.Open ? true : false;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;
                bAllOk = false;
            }
            return bAllOk;
        }
        public void CerrarConexion()
        {
            conexion.Close();
        }
        public static String GetConnectionString(String sServidor, String sUsuario, String sContraseña)
        {
            String sCadenaConnection = "";

            String sServer = sServidor;
            String sDataBase = "master";
            String sUserId = sUsuario;
            String sPassword = sContraseña;

            sCadenaConnection = $"Server={sServer};Database={sDataBase};User Id={sUserId};Password={sPassword}";

            return sCadenaConnection;

        }
        public DataTable Columnas(ref DatosDeInicio user,string BaseDatos, string Tabla)
        {
            DataTable data = new DataTable();
            Boolean bAllOk = false;
            using (SqlConnection conn = new SqlConnection(Class1.GetConnectionString(user.sServidor, user.sUsuario, user.sContrasena)))
            {
                try
                {
                    conn.Open();
                    //WHERE name not in('master','tempdb,'model','msdb')

                    string Query = " Select COLUMN_NAME, IS_NULLABLE, DATA_TYPE, DATALENGTH(DATA_TYPE)" +
                        " from INFORMATION_SCHEMA.COLUMNS " +
                        $" Where TABLE_NAME = '{Tabla}'";
                    
                    SqlCommand comando = new SqlCommand(Query, conn);
                    data.Load(comando.ExecuteReader());

                    bAllOk = true;
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                    bAllOk = false;
                }
                finally
                {
                    conn.Close();
                }
            }

            return data;
        }
        public DataTable ConsultarBD(ref DatosDeInicio user)
        {
            DataTable data = new DataTable();
            Boolean bAllOk = false;
            using (SqlConnection conn = new SqlConnection(Class1.GetConnectionString(user.sServidor, user.sUsuario, user.sContrasena)))
            {
                try
                {
                    conn.Open();
                    //WHERE name not in('master','tempdb,'model','msdb')
                    string Query = " SELECT name FROM sys.databases where database_id >6;";
                    SqlCommand comando = new SqlCommand(Query, conn);
                    data.Load(comando.ExecuteReader());

                    bAllOk = true;
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                    bAllOk = false;
                }
                finally
                {
                    conn.Close();
                }
            }

            return data;
        }
        //string sentenciaSql = $"USE {bd}; DROP TABLE {nombreTabla};";

        public bool EliminarTabla(ref DatosDeInicio user, string bd, string nombreTabla)
        {
            string sLastError = "";
            bool bAllOk = false;
            using (SqlConnection conn = new SqlConnection(dbSqlServer.GetConnectionString(user.sServidor, user.sUsuario, user.sContrasena)))
            {
                try
                {
                    conn.Open();
                    // Si la tabla existe, la eliminamos
                    string eliminarQuery = $"USE {bd}; DROP TABLE {nombreTabla};";
                    SqlCommand eliminarComando = new SqlCommand(eliminarQuery, conn);
                    eliminarComando.ExecuteNonQuery();
                    bAllOk = true;

                }
                catch (Exception ex)
                {
                    sLastError = $"La tabla [{nombreTabla}] no existe en la base de datos [{bd}]."+ '\n'+ $"{ex.Message}  ";
                    bAllOk = false;
                }
                finally
                {
                    conn.Close();
                }
            }

            return bAllOk;
        }
        public bool CrearBD(string sServidor, string sUsuario, string sContrasena, string bd, string rutaGuardada)
        {
            string sLastError = "";
            bool bAllOk = false;
            using (SqlConnection conn = new SqlConnection(dbSqlServer.GetConnectionString(sServidor, sUsuario, sContrasena)))
            {
                try
                {
                    conn.Open();
                    // Utiliza la ruta seleccionada para guardar la base de datos
                    string sentenciaSql = $"CREATE DATABASE {bd} ON PRIMARY (NAME = {bd}, FILENAME = '{rutaGuardada}')";
                    SqlCommand crearBDComando = new SqlCommand(sentenciaSql, conn);
                    crearBDComando.ExecuteNonQuery();
                    bAllOk = true;
                }
                catch (Exception ex)
                {
                    sLastError = $"La [{bd}] no fue creada correctamente " + '\n' + $"{ex.Message}  ";
                    bAllOk = false;
                }
                finally
                {
                    conn.Close();
                }
            }

            return bAllOk;
        }



        public DataTable ConsultarTablas(ref DatosDeInicio user, String sBaseDeDatos)
        {
            String sLastError = "";
            DataTable data = new DataTable();
            Boolean bAllOk = false;
            using (SqlConnection conn = new SqlConnection(dbSqlServer.GetConnectionString(user.sServidor, user.sUsuario, user.sContrasena)))
            {
                try
                {
                    conn.Open();

                    string Query = $" use [{sBaseDeDatos}] SELECT CAST(table_name as varchar)  FROM INFORMATION_SCHEMA.TABLES";
                    SqlCommand comando = new SqlCommand(Query, conn);
                    data.Load(comando.ExecuteReader());

                    bAllOk = true;
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                    bAllOk = false;
                }
                finally
                {
                    conn.Close();
                }
            }

            return data;
        }
        public DataTable ConsultarCamposTipos(ref DatosDeInicio user, String sBaseDeDatos, String sTabla)
        {
            DataTable data = new DataTable();
            Boolean bAllOk = false;
            using (SqlConnection conn = new SqlConnection(dbSqlServer.GetConnectionString(user.sServidor, user.sUsuario, user.sContrasena)))
            {
                try
                {
                    conn.Open();

                    string Query = $"USE [{sBaseDeDatos}] SELECT COLUMN_NAME as Nombre, DATA_TYPE as Tipo, information_schema.columns.CHARACTER_MAXIMUM_LENGTH FROM information_schema.columns WHERE TABLE_NAME = '{sTabla}'";
                    SqlCommand comando = new SqlCommand(Query, conn);
                    data.Load(comando.ExecuteReader());

                    bAllOk = true;
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                    bAllOk = false;
                }
                finally
                {
                    conn.Close();
                }
            }

            return data;
        }
        public DataTable ConsultarTablasSelect(string sServidor, string sUsuario, string sContrasena, String sBaseDeDatos, String sTabla)
        {
            DataTable data = new DataTable();
            Boolean bAllOk = false;
            using (SqlConnection conn = new SqlConnection(dbSqlServer.GetConnectionString(sServidor, sUsuario, sContrasena)))
            {
                try
                {
                    conn.Open();

                    string Query = $"USE [{sBaseDeDatos}] SELECT * from {sTabla}";
                    SqlCommand comando = new SqlCommand(Query, conn);
                    data.Load(comando.ExecuteReader());

                    bAllOk = true;
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                    bAllOk = false;
                }
                finally
                {
                    conn.Close();
                }
            }

            return data;
        }
        public string ObtenerNombrePrimeraColumna(string sServidor, string sUsuario, string sContrasena, String sBaseDeDatos, String sTabla)
        {
            string nombreColumna = null;

            using (SqlConnection conn = new SqlConnection(dbSqlServer.GetConnectionString(sServidor, sUsuario, sContrasena)))
            {
                try
                {
                    conn.Open();

                    string Query = $"USE [{sBaseDeDatos}] SELECT TOP 1 COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{sTabla}'";

                    SqlCommand comando = new SqlCommand(Query, conn);
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        nombreColumna = reader.GetString(0);
                    }
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }

            return nombreColumna;
        }

        public void InsertarEnTabla(string nombreBaseDeDatos, string nombreTabla, string campos, string valores)
        {
            string query = $"USE {nombreBaseDeDatos}; INSERT INTO {nombreTabla} ({campos}) VALUES {valores}";

            try
            {
                AbrirConexion();
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.ExecuteNonQuery();
                }
                CerrarConexion();
                
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;
                CerrarConexion();
                
            }
        }
        public void InsertarSelect(string nombreBaseDeDatos, string valores)
        {
            string query = $"USE {nombreBaseDeDatos}; {valores}";

            try
            {
                AbrirConexion();
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.ExecuteNonQuery();
                }
                CerrarConexion();

            }
            catch (Exception ex)
            {
                sLastError = ex.Message;
                CerrarConexion();

            }
        }
        public bool CrearUsuario(string sServidor, string sUsuario, string sContrasena, string baseDeDatos, string usuario, string contraseña, string rol)
        {
            bool bAllOk = false;
            using (SqlConnection conn = new SqlConnection(dbSqlServer.GetConnectionString(sServidor, sUsuario, sContrasena)))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand($"USE {baseDeDatos}; CREATE LOGIN {usuario} WITH PASSWORD = '{contraseña}' MUST_CHANGE, CHECK_EXPIRATION = ON, DEFAULT_DATABASE = {baseDeDatos}, DEFAULT_LANGUAGE = us_english; USE {baseDeDatos}; CREATE USER {usuario} FOR LOGIN {usuario}; ALTER ROLE {rol} ADD MEMBER {usuario};", conn))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        
                    }
                    catch (Exception ex)
                    {
                        sLastError = ex.Message;
                    }
                    return bAllOk;
                }
            }
        }
        public void EliminarFilaEnTabla(string nombreBaseDeDatos, string nombreTabla,string column,string ID)
        {
            string query = $"USE {nombreBaseDeDatos}; DELETE FROM {nombreTabla} WHERE {column} = {ID}";

            try
            {
                AbrirConexion();
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.ExecuteNonQuery();
                }
                CerrarConexion();
                
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;
                CerrarConexion();
                
            }
        }
        public void ActualizarEnTabla(string nombreBaseDeDatos, string nombreTabla, string valores)
        {
            string query = $"USE {nombreBaseDeDatos}; UPDATE {nombreTabla} SET {valores}";

            try
            {
                AbrirConexion();
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.ExecuteNonQuery();
                }
                CerrarConexion();
               
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;
                CerrarConexion();
                
            }
        }
        public bool ActualizarContraseña(string sServidor, string nombreUsuario, string nuevaContraseña)
        {
            string sUsuario = "sa";
            string sContrasena = "230318";
            try
            {
                using (SqlConnection conn = new SqlConnection(dbSqlServer.GetConnectionString(sServidor, sUsuario, sContrasena)))
                {
                    conn.Open();

                    // Verificar si el usuario existe antes de actualizar
                    string query = $"SELECT COUNT(*) FROM sys.syslogins WHERE name = '{nombreUsuario}'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        
                        int existeUsuario = (int)cmd.ExecuteScalar();
                        if (existeUsuario == 1)
                        {
                            // El usuario existe, ahora actualizamos la contraseña
                            query = $"ALTER LOGIN {nombreUsuario} WITH PASSWORD = '{nuevaContraseña}'";
                            using (SqlCommand updateCmd = new SqlCommand(query, conn))
                            {
                               updateCmd.ExecuteNonQuery();
                            }

                            return true;  // Éxito al actualizar la contraseña
                        }
                        else
                        {
                            // El usuario no existe
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la contraseña: {ex.Message}");
                return false;  // Error al actualizar la contraseña
            }
        }
        public bool IsNewUserOrRequiresPasswordUpdate(string sServidor, string sUsuario, string sContrasena, string username)
        {
            using (SqlConnection connection = new SqlConnection(dbSqlServer.GetConnectionString(sServidor, sUsuario, sContrasena)))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM sys.syslogins WHERE Username = @Username", connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    object result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                    {
                        // El usuario es nuevo.
                        return true;
                    }
                    return !(bool)result;
                }
            }
        }
        public bool UpdatePassword(string sServidor, string sUsuario, string sContrasena, string username, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(dbSqlServer.GetConnectionString(sServidor, sUsuario, sContrasena)))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Users SET Password = @Password, PasswordUpdated = 1 WHERE Username = @Username", connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", newPassword);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }



        public DataTable ConsultarTablasInsert(ref DatosDeInicio user, String sBaseDeDatos, String sTabla)
        {
            DataTable data = new DataTable();
            Boolean bAllOk = false;
            using (SqlConnection conn = new SqlConnection(dbSqlServer.GetConnectionString(user.sServidor, user.sUsuario, user.sContrasena)))
            {
                try
                {
                    conn.Open();

                    string Query = $@"USE [{sBaseDeDatos}] ; 
SELECT col.COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS col
LEFT JOIN sys.index_columns ic ON ic.object_id = object_id(col.TABLE_NAME) AND ic.column_id = col.ORDINAL_POSITION
WHERE col.TABLE_NAME = '{sTabla}' AND COLUMNPROPERTY(object_id(col.TABLE_NAME), col.COLUMN_NAME, 'IsIdentity') <> 1;";
                    SqlCommand comando = new SqlCommand(Query, conn);
                    data.Load(comando.ExecuteReader());

                    bAllOk = true;
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                    bAllOk = false;
                }
                finally
                {
                    conn.Close();
                }
            }

            return data;
        }

        

    }
}
