using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Universitario:Persona
    {
        private int legajo;

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, nacionalidad, dni)
        {
            this.legajo = legajo;
        }


        protected virtual string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.Append(base.ToString());
            str.AppendLine("Legajo: " + this.legajo);

            retorno = str.ToString();

            return retorno;
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            bool ok = false;


            if (obj is Universitario && this is Universitario)
            {
                Universitario uni = (Universitario)obj;

                if (this.Dni == uni.Dni && this.legajo == uni.legajo)
                {
                    ok = true;
                }
            }

            return ok;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
