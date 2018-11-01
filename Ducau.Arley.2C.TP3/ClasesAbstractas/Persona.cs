using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
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

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad, int dni) : this(nombre, apellido, nacionalidad, dni.ToString())
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad, string dni) : this(nombre, apellido, nacionalidad)
        {
            StringToDni = dni;
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                this.apellido = ValidarNombreApellido(value);
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
                this.nombre = ValidarNombreApellido(value);
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
                this.dni = ValidarDni(Nacionalidad, value);
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
                this.dni = ValidarDni(Nacionalidad, value);
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato < 1 || dato > 99999999)
            {
                throw new DniInvalidoException("Dni invalido, fuera de rango");
            }
            else
            {
                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:
                        if (dato > 89999999)
                        {
                            throw new NacionalidadInvalidaException("El dni no coincide con la nacionaidad");
                        }
                        break;
                    case ENacionalidad.Extranjero:
                        if (dato < 90000000)
                        {
                            throw new NacionalidadInvalidaException("El dni no coincide con la nacionalida");
                        }
                        break;
                }

            }

            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni = 0;

            if (int.TryParse(dato, out dni))
            {
                dni = ValidarDni(nacionalidad, dni);
            }
            else
            {
                throw new DniInvalidoException("El dni tiene caracteres que no corresponden");
            }

            return dni;
        }

        private string ValidarNombreApellido(string dato)
        {
            string retorno = "";
            Regex str = new Regex(@"^[a-zA-Z]+$/");

            if (str.IsMatch(dato))
            {
                retorno = dato;
            }

            return retorno;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.AppendLine("Nombre completo: " + Nombre + ", " + Apellido);
            str.AppendLine("Nacionalidad: " + Nacionalidad);
            str.AppendLine("Dni: " + Dni);

            retorno = str.ToString();

            return retorno;
        }

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }



    }
}
