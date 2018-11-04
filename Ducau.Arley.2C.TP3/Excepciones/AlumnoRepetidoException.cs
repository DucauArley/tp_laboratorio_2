using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException: Exception
    {

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public AlumnoRepetidoException():base("El alumno esta repetido")
        {

        }
    }
}
