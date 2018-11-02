using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextWriter texto = null;
            bool ok = true;

            try
            {
                texto = new XmlTextWriter(archivo, null);
                ser.Serialize(texto, datos);
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


        public bool Leer(string archivo, out T dato)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextReader texto = null;
            bool ok = true;

            try
            {
                texto = new XmlTextReader(archivo);
                dato = (T) ser.Deserialize(texto);
            }
            catch (Exception)
            {
                dato = default(T);
                ok = false;
            }
            finally
            {
                texto.Close();
            }


            return ok;
        }


    }
}
