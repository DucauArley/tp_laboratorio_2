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


        /// <summary>
        /// Constrctor por defecto de Persona
        /// </summary>
        public Persona()
        {

        }



        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre"></param>Nombre de la persona
        /// <param name="apellido"></param>Apellido de la persona
        /// <param name="nacionalidad"></param>Nacionalidad de la persona
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }


        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre"></param>Nombre de la persona
        /// <param name="apellido"></param>Apellido de la persona
        /// <param name="nacionalidad"></param>Nacionalidad de la persona
        /// <param name="dni"></param>Dni de la persona, entero
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad, int dni) : this(nombre, apellido, nacionalidad, dni.ToString())
        {

        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre"></param>Nombre de la persona
        /// <param name="apellido"></param>Apellido de la persona
        /// <param name="nacionalidad"></param>Nacionalidad de la persona
        /// <param name="dni"></param>Dni de la persona, cadena de caracteres
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad, string dni) : this(nombre, apellido, nacionalidad)
        {
            StringToDni = dni;
        }


        /// <summary>
        /// Propeidad de lectura/escritura de Apellido
        /// </summary>
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


        /// <summary>
        /// Propiedad de lectura/escritura de Nombre
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura/escritura de Nacionalidad
        /// </summary>
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

        /// <summary>
        /// Propiedad de escritura de Dni, cadena de caracteres
        /// </summary>
        public string StringToDni
        {
            set
            {
                this.dni = ValidarDni(Nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de lectura/escritura de Dni, entero
        /// </summary>
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


        /// <summary>
        /// Metodo para validar el dni
        /// </summary>
        /// <param name="nacionalidad"></param>Nacionalidad de la persona
        /// <param name="dato"></param>Dni de le persona, entero
        /// <returns></returns>El dni de la persona
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


        /// <summary>
        /// Metodo para validar el dni
        /// </summary>
        /// <param name="nacionalidad"></param>Nacionalidad de la persona
        /// <param name="dato"></param>Dni de le persona, cadena de caracteres
        /// <returns></returns>El dni de la persona
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni = 0;

            if (Regex.IsMatch(dato, @"^[0-9]+[0-9\.]*$")) 
            {
                dato = dato.Replace(".", "");
                if (int.TryParse(dato, out dni))
                {
                    dni = ValidarDni(nacionalidad, dni);
                }
            }
            else
            {
                throw new DniInvalidoException("El dni tiene caracteres que no corresponden");
            }

            return dni;
        }

        /// <summary>
        /// Metodo para validar el Nombre/Apellido
        /// </summary>
        /// <param name="dato"></param>Nombre/Apellido de la persona
        /// <returns></returns>El nombre/apellido de la persona
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


        /// <summary>
        /// Metodo sobreescrito ToString()
        /// </summary>
        /// <returns></returns>Todos los datos de la persona
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


        /// <summary>
        /// enumerado de las nacionalidades
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }



    }
}
