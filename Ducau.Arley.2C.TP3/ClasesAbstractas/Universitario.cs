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

        /// <summary>
        /// Constructor por defecto de Universitario
        /// </summary>
        public Universitario()
        {

        }


        /// <summary>
        /// Constructor de instancia que llama al constructor de Persona
        /// </summary>
        /// <param name="legajo"></param>Legajo del universitario
        /// <param name="nombre"></param>Nombre del universitario
        /// <param name="apellido"></param>Apellido del univeristario
        /// <param name="dni"></param>Dni del universitario, entero
        /// <param name="nacionalidad"></param>Nacionalidad del universitario
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, nacionalidad, dni)
        {
            this.legajo = legajo;
        }


        /// <summary>
        /// Metodo virtual para mostrar los datos del universitario
        /// </summary>
        /// <returns></returns>Los datos del universitario
        protected virtual string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.Append(base.ToString());
            str.AppendLine("Legajo: " + this.legajo);

            retorno = str.ToString();

            return retorno;
        }


        /// <summary>
        /// Metodo abstracto
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();


        /// <summary>
        /// Compara si 2 universitarios son iguales
        /// </summary>
        /// <param name="obj"></param>Universitario a comparar
        /// <returns></returns>True si son iguales, false si no lo son
        public override bool Equals(object obj)
        {
            bool ok = false;

            if (obj is Universitario && this is Universitario)
            {
                Universitario uni = (Universitario)obj;

                if (this.Dni == uni.Dni || this.legajo == uni.legajo)
                {
                    ok = true;
                }
            }

            return ok;
        }


        /// <summary>
        /// Compara si dos universitarios son iguales
        /// </summary>
        /// <param name="pg1"></param>Universitario a comparar
        /// <param name="pg2"></param>Universitario a comparar
        /// <returns></returns>True si son iguales, false si no los son
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Compara si dos universitarios no son iguales
        /// </summary>
        /// <param name="pg1"></param>Universitario a comparar
        /// <param name="pg2"></param>Universitario a comparar
        /// <returns></returns>True si no son iguales, false si lo son
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
