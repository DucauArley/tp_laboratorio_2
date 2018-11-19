using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand sqlCommand;
        private static SqlConnection sqlConnection;


        /// <summary>
        /// Constructor estatico que inicializa la conexion
        /// </summary>
        static PaqueteDAO()
        {
            sqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");
        }


        /// <summary>
        /// Metodo que agrega un paquete a la base de datos
        /// </summary>
        /// <param name="p"></param>Paquete a agregar
        /// <returns></returns>True si se agrego correctamente, false si no
        public static bool Insertar(Paquete p)
        {
            bool ok = true;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("INSERT INTO dbo.Paquetes (direccionEntrega, trackingID, alumno) VALUES ('" + p.DireccionEntrega + "','" + p.TrackingID + "','" + "Ducau Arley" + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                ok = false;
                throw e;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            
            return ok;
        }

    }
}
