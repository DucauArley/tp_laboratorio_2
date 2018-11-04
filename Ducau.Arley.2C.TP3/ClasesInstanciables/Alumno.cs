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
        private Universidad.EClases  claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Constructor por defecto de Alumno
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor de instancia que llama al constructor de Universitario
        /// </summary>
        /// <param name="id"></param>Legajo de el alumno
        /// <param name="nombre"></param>Nombre del alumno
        /// <param name="apellido"></param>Apellido del alumno
        /// <param name="dni"></param>Dni del alumno
        /// <param name="nacionalidad"></param>Nacionalidad del alumno
        /// <param name="claseQueToma"></param>La clase que el alumno toma
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma):base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de instancia que llama al constructor de arriba
        /// </summary>
        /// <param name="id"></param>Legajo del alumno
        /// <param name="nombre"></param>Nombre del alumno
        /// <param name="apellido"></param>Apellido del alumno
        /// <param name="dni"></param>Dni del alumno
        /// <param name="nacionalidad"></param>Nacionalidad del alumno
        /// <param name="clasesQueToma"></param>Clase que el alumno toma
        /// <param name="estadoCuenta"></param>El estado de la cuenta del alumno
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta):this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        
        /// <summary>
        /// Metodo sobreescrito de Universitario
        /// </summary>
        /// <returns></returns>Devuelve los datos del alumno
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
        /// <returns></returns>Devuelve la clase que toma el alumno y el estado de su cuenta
        protected override string ParticiparEnClase()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.AppendLine("Toma clases de: " + this.claseQueToma);
            str.AppendLine("Estado de cuenta: " + this.estadoCuenta);

            retorno = str.ToString();

            return retorno;
        }


        /// <summary>
        /// Metodo sobreescrito
        /// </summary>
        /// <returns></returns>Devuelve todos los datos del alumno
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.Append(MostrarDatos());
            str.Append(ParticiparEnClase());

            retorno = str.ToString();

            return retorno;
        }


        /// <summary>
        /// Compara si un alumno toma la clase y no tiene deudas
        /// </summary>
        /// <param name="a"></param>Alumno a ser comparado
        /// <param name="clase"></param>Clase a ser comparada
        /// <returns></returns>True si el alumno cursa la clase y no debe dinero, false si no la cursa o debe dinero
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool ok = false;

            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                ok = true;
            }
            
            return ok;
        }

        /// <summary>
        /// Compara si un alumno no toma la clase o tiene deudas
        /// </summary>
        /// <param name="a"></param>Alumno a ser comparado
        /// <param name="clase"></param>Clase a ser comparada
        /// <returns></returns>True si el alumno no cursa la clase o debe dinero, false si la cursa y no debe dinero
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);   
        }
         
        /// <summary>
        /// Enumerado de los estados de cuenta que se pueden tener
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }


    }
}
