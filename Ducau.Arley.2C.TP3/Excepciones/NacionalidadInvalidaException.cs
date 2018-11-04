using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException: Exception
    {

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public NacionalidadInvalidaException()
        {

        }


        /// <summary>
        /// Constructor que permite escribir un mensaje
        /// </summary>
        /// <param name="mensaje"></param>Mensaje de la excepcion
        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        {

        }
    }
}
