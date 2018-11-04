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

        /// <summary>
        /// Permite serializar datos en formato xml
        /// </summary>
        /// <param name="archivo"></param>La ruta donde se encuentra el archivo
        /// <param name="datos"></param>Los datos a ser guardados en el archivo
        /// <returns></returns>True si no se produjeron excepciones al guardar, false si se produjeron
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

        /// <summary>
        /// Lee los datos en formato xml
        /// </summary>
        /// <param name="archivo"></param>La ruta donde se encuentra el archivo
        /// <param name="datos"></param>Parametro de salida donde se guardan los datos
        /// <returns></returns>True si no se produjeron excepciones al leer, false si se produjeron
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
