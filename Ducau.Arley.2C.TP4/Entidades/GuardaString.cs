using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {

        /// <summary>
        /// Metodo de extencion de la clase string que guarda strings en un archivo
        /// </summary>
        /// <param name="texto"></param>Texto que se va a guardar en el archivo
        /// <param name="archivo"></param>Nombre del archivo
        /// <returns></returns>True si se pudo guardar, false si no
        public static bool Guardar(this string texto, string archivo)
        {
            StreamWriter stream = null;
            bool ok = true;

            try
            {
                stream = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo + ".txt", true);
                stream.Write(texto + "\n");
            }
            catch (Exception)
            {
                ok = false;
            }
            finally
            {
                stream.Close();
            }

            return ok;
        }

    }
}
