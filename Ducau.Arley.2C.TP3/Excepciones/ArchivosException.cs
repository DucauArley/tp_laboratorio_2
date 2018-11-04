using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException:Exception
    {

        /// <summary>
        /// Constructor que permite detallar la excepcion
        /// </summary>
        /// <param name="innerException"></param>Excepcion a ser detallada
        public ArchivosException(Exception innerException):base("Ocurrio un error con el archivo", innerException)
        {

        }
    }
}
