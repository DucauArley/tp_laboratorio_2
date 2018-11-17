using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class TrakingIdRepetidoException:Exception
    {

        public TrakingIdRepetidoException(string mensaje):this(mensaje, null)
        {

        }

        public TrakingIdRepetidoException(string mensaje, Exception inner):base(mensaje, inner)
        {

        }
        
    }
}
