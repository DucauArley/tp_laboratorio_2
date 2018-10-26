using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducau.Arley._2C.TP3
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad, int dni):this(nombre, apellido, nacionalidad, dni.ToString())
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad, string dni):this(nombre, apellido, nacionalidad)
        {
            int.TryParse(dni, out this.dni);
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                this.apellido = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                this.nombre = value;
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }

            set
            {
                this.nacionalidad = value;
            }
        }

        public string StringToDni
        {
            set
            {
                this.dni = int.Parse(value);
            }
        }

        public int Dni
        {
            get
            {
                return this.dni;
            }

            set
            {
                this.dni = value;
            }
        }







        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }


    }
}
