using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException: Exception
    {
        private const string mensajeBase = "Dni invalido";


        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public DniInvalidoException()
        {

        }

        /// <summary>
        /// Constructor que permite detallar la excepcion
        /// </summary>
        /// <param name="e"></param>Excepcion a ser detallada
        public DniInvalidoException(Exception e) : this(mensajeBase, e)
        {

        }


        /// <summary>
        /// Constructor que permite escribir un mensaje
        /// </summary>
        /// <param name="mensaje"></param>Mensaje de la excepcion
        public DniInvalidoException(string mensaje) : this(mensaje, null)
        {

        }


        /// <summary>
        /// Constructor que permite escribir un mensaje y detallar una excepcion
        /// </summary>
        /// <param name="mensaje"></param>Mensaje de la excepcion
        /// <param name="e"></param>Excepcion a ser detallada
        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {

        }

    }
}
