using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor:Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        

        /// <summary>
        /// Constructor estatico de Profesor
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor por defecto de Profesor
        /// </summary>
        public Profesor()
        {
        }


        /// <summary>
        /// Constructor de instancia que llama al constructor de Universitario
        /// </summary>
        /// <param name="id"></param>Legajo del profesor
        /// <param name="nombre"></param>Nombre del profesor
        /// <param name="apellido"></param>Apellido del profesor
        /// <param name="dni"></param>Dni del profesor
        /// <param name="nacionalidad"></param>Nacionalidad del profesor
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _RandomClase();
        }

        /// <summary>
        /// Metodo sobreescrito de Universitario
        /// </summary>
        /// <returns></returns>Devuelve los datos del profesor
        protected override string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.Append(base.MostrarDatos());

            retorno = str.ToString();
            
            return retorno;
        }

        /// <summary>
        /// Metodo sobreescrito de Universitario
        /// </summary>
        /// <returns></returns>Devuelve las clases que imparte el profesor
        protected override string ParticiparEnClase()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.AppendLine("Clases del dia: ");

            if (this.clasesDelDia != null)
            {
                foreach (Universidad.EClases c in this.clasesDelDia)
                {
                    str.AppendLine("" + c);
                }
            }

            retorno = str.ToString();

            return retorno;
        }

        /// <summary>
        /// Metodo sobreescrito
        /// </summary>
        /// <returns></returns>Devuelve todos los datos del profesor
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.AppendLine(MostrarDatos());
            str.AppendLine(ParticiparEnClase());

            retorno = str.ToString();

            return retorno;
        }


        /// <summary>
        /// Metodo que asigna clases al profesor
        /// </summary>
        private void _RandomClase()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            }
        }

        /// <summary>
        /// Compara si un profesor imparte la clase
        /// </summary>
        /// <param name="i"></param>Profesor a ser comparado
        /// <param name="clase"></param>Clase a ser comparada
        /// <returns></returns>True si el profesor imparte la clase, false si no
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool ok = false;

            if (i.clasesDelDia.Contains(clase))
            {
                ok = true;
            }
            
            return ok;
        }

        /// <summary>
        /// Compara si un profesor no imparte la clase
        /// </summary>
        /// <param name="i"></param>Profesor a ser comparado
        /// <param name="clase"></param>Clase a ser comparada
        /// <returns></returns>True si el profesor no imparte la clase, false si la imparte
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }


    }
}
