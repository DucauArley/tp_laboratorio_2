using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException:Exception
    {

        /// <summary>
        /// Constructor que permite escribir un mensaje
        /// </summary>
        /// <param name="mensaje"></param>Mensaje de la excepcion
        public TrackingIdRepetidoException(string mensaje):this(mensaje, null)
        {

        }


        /// <summary>
        /// Constructor que permite escribir un mensaje y detallar la eexcepcion
        /// </summary>
        /// <param name="mensaje"></param>Mensaje de la excepcion
        /// <param name="inner"></param>Excepcion a detallar
        public TrackingIdRepetidoException(string mensaje, Exception inner):base(mensaje, inner)
        {

        }
        
    }
}
