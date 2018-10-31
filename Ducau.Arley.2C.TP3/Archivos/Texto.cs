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
