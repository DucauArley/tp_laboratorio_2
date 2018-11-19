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
        public static bool Guardar(this string texto, string archivo)
        {
            StreamWriter stream = null;
            bool ok = true;

            try
            {
                stream = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo + ".txt", true);
                stream.Write(texto);
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
