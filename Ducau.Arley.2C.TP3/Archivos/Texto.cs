using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto: IArchivo<string>
    {

        /// <summary>
        /// Guarda los datos en formato de texto
        /// </summary>
        /// <param name="archivo"></param>La ruta donde se encuentra el archivo
        /// <param name="datos"></param>Los datos a ser guardados en el archivo
        /// <returns></returns>True si no se produjeron excepciones al guardar, false si se produjeron
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter texto = null;
            bool ok = true;

            try
            {
                texto = new StreamWriter(archivo, false);
                texto.Write(datos);
            }
            catch (Exception)
            {
                ok = false;
            }
            finally
            {
                texto.Close();
            }
            
            return ok;
        }

        /// <summary>
        /// Lee los datos en formato de texto de un archivo
        /// </summary>
        /// <param name="archivo"></param>La ruta donde se encuentra el archivo
        /// <param name="datos"></param>Parametro de salida donde se guardan los datos
        /// <returns></returns>True si no se produjeron excepciones al leer, false si se produjeron
        public bool Leer(string archivo, out string datos)
        {
            StreamReader texto = null;
            bool ok = true;

            try
            {
                texto = new StreamReader(archivo);
                datos = texto.ReadToEnd();
            }
            catch (Exception)
            {
                ok = false;
                datos = null;
            }
            finally
            {
                texto.Close();
            }
            
            return ok;
        }


    }
}
