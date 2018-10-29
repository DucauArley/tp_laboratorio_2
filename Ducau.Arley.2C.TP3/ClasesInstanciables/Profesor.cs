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
        
        static Profesor()
        {
            random = new Random();
        }

        private Profesor()
        {
        }


        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
        }

        protected override string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.Append(base.MostrarDatos());

            retorno = str.ToString();
            
            return retorno;
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.AppendLine("Clases del dia: " + this.clasesDelDia.ElementAt(0) + " y " + this.clasesDelDia.ElementAt(1));

            retorno = str.ToString();

            return retorno;
        }



    }
}
