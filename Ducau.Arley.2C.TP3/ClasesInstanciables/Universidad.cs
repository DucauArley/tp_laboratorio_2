using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        /// <summary>
        /// Constructor de instancia que inicializa las listas de alumnos, jornadas y profesores
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }


        /// <summary>
        /// Propeidad de lectura/escritura de la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }


        /// <summary>
        /// Propiedad de lectura/escritura de la lista de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }

            set
            {
                this.jornadas = value;
            }
        }


        /// <summary>
        /// Propiedad de lectura/escritura de la lista de profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }


        /// <summary>
        /// Indexador para la lista de jornadas
        /// </summary>
        /// <param name="i"></param>Indice de cada jornada
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                Jornada jor = null;
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    jor = this.Jornadas[i];
                }

                return jor;
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    this.Jornadas[i] = value;
                }
            }
        }


        /// <summary>
        /// Metodo que devuelve los datos de la universidad
        /// </summary>
        /// <param name="uni"></param>Universidad de la que se quieren mostrar los datos
        /// <returns></returns>Devuelve una cadena de caracteres con los datos de la universidad
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            foreach (Jornada j in uni.Jornadas)
            {
                str.AppendLine(j.ToString());
            }

            retorno = str.ToString();

            return retorno;
        }

        /// <summary>
        /// Metodo sobreescrito
        /// </summary>
        /// <returns></returns>Devuelve todos los datos de la universidad
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.AppendLine(MostrarDatos(this));

            retorno = str.ToString();

            return retorno;
        }

        /// <summary>
        /// Metodo para guardar los datos de la universidad en un archivo
        /// </summary>
        /// <param name="uni"></param>Universidad a ser guardada
        /// <returns></returns>True si se pudo guardar, false si no
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            bool ok = true;

            if(xml.Guardar("Universidad.xml", uni) == false)
            {
                ok = false;
                SerializationException e = new SerializationException();
                throw new ArchivosException(e);
            }

            return ok;
        } 


        /// <summary>
        /// Metodo para leer los datos de una universidad guardada en un archivo
        /// </summary>
        /// <param name="uni"></param>Universidad a la que se le van a pasar todos los datos
        /// <returns></returns>Universidad con todos los datos
        public static Universidad Leer(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            if(xml.Leer("Universidad.xml", out uni) == false)
            {
                SerializationException e = new SerializationException();
                throw new ArchivosException(e);
            }

            return uni;
        }

        
        /// <summary>
        /// Compara si un alumno esta en una universidad
        /// </summary>
        /// <param name="g"></param>Universidad a ser comparada
        /// <param name="a"></param>Alumno a ser comparado
        /// <returns></returns>True si esta, false si no
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool ok = false;

            if (g.Alumnos.Contains(a))
            {
                ok = true;
            }
            
            return ok;
        }

        /// <summary>
        /// Compara si un profesor esta en una universidad
        /// </summary>
        /// <param name="g"></param>Universidad a ser comparada
        /// <param name="i"></param>Profesor a ser comparado
        /// <returns></returns>True si esta, false si no
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool ok = false;

            if (g.Instructores.Contains(i))
            {
                ok = true;
            }
            
            return ok;
        }


        /// <summary>
        /// Retorna el primer profesor capaz de dar la clase
        /// </summary>
        /// <param name="u"></param>Universidad a ser comparada
        /// <param name="clase"></param>Clase a ser comparada
        /// <returns></returns>El primer profesor que de la clase, si no hay, lanza una excepcion de tipo SinProfesorException
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Instructores)
            {
                if(p == clase)
                {
                    return p;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Compara si un alumno no esta en una universidad
        /// </summary>
        /// <param name="g"></param>Universidad a ser comparada
        /// <param name="a"></param>Alumno a ser comparado
        /// <returns></returns>True si no esta, false si esta
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Compara si un profesor no esta en una universidad
        /// </summary>
        /// <param name="g"></param>Universidad a ser comparada
        /// <param name="i"></param>Profesor a ser comparado
        /// <returns></returns>True si no esta, false si esta
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Retorna el primer profesor que no da la clase
        /// </summary>
        /// <param name="u"></param>Universidad a ser comparada
        /// <param name="clase"></param>Clase a ser comparada
        /// <returns></returns>El primer profesor que no de la clase, si no hay, lanza una excepcion de tipo SinProfesorException
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Instructores)
            {
                if(p != clase)
                {
                    return p;
                }
            }

            throw new SinProfesorException();
        }


        /// <summary>
        /// Agrega un alumno a una universidad
        /// </summary>
        /// <param name="u"></param>universidad a la cual se le agregara un alumno
        /// <param name="a"></param>Alumno a ser agregado
        /// <returns></returns>La universidad con el alumno agregado
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        /// <summary>
        /// Agrega un profesor a una universidad
        /// </summary>
        /// <param name="u"></param>universidad a la cual se le agregara un alumno
        /// <param name="i"></param>Profesor a ser agregado
        /// <returns></returns>La universidad con el profesor agregado
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u != i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }

        /// <summary>
        /// Agrega una nueva jornada de clase. Asigna un profesor a la misma 
        /// y a los alumnos que tomen esa clase.
        /// </summary>
        /// <param name="g"></param>Universidad a la cual se le agregara una clase
        /// <param name="clase"></param>Clase a ser agregada
        /// <returns></returns>La universidad con la nueva jornada de clase cargada
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada j = new Jornada(clase, g == clase);

            foreach (Alumno a in g.Alumnos)
            {
                if (a == clase)
                {
                    j.Alumnos.Add(a); 
                }
            }

            g.Jornadas.Add(j);

            return g;
        }


        /// <summary>
        /// Enumerado de las clases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
