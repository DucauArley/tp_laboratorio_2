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

        public Profesor()
        {
        }


        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _RandomClase();
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

            str.AppendLine("Clases del dia: ");

            if (this.clasesDelDia != null)
            {
                foreach (Universidad.EClases c in this.clasesDelDia)
                {
                    str.AppendLine(c.ToString());
                }
            }

            retorno = str.ToString();

            return retorno;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.Append(MostrarDatos());
            str.Append(ParticiparEnClase());

            retorno = str.ToString();

            return retorno;
        }


        private void _RandomClase()
        {
            for (int i = 0; i < 1; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            }
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool ok = false;

            if (i.clasesDelDia.Contains(clase))
            {
                ok = true;
            }
            
            return ok;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }


    }
}
