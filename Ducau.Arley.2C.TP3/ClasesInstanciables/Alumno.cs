using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno:Universitario
    {
        private Universidad.EClases  clasesQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma):base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta):this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
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

            str.AppendLine("Toma clases de: " + this.clasesQueToma);

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

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool ok = false;

            if(a.clasesQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                ok = true;
            }
            
            return ok;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);   
        }

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }


    }
}
