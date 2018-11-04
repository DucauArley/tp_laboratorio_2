using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;


        /// <summary>
        /// Constructor privado donde se inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }


        /// <summary>
        /// Constructor de instancia que llama al constructor privado
        /// </summary>
        /// <param name="clase"></param>Clase de la jornada
        /// <param name="instructor"></param>Profesor de la jornada
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }


        /// <summary>
        /// Propiedad de lectura/escritura de la lista de alumnos
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
        /// Propiedad de lectura/escritura de la clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }

            set
            {
                this.clase = value;
            }
        }


        /// <summary>
        /// Propiedad de lectura/escritura del profesor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }

            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Metodo sobreescrito
        /// </summary>
        /// <returns></returns>Devuelve todos los datos de la jornada
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.AppendLine("Jornada: ");
            str.AppendLine("Clase de: " + this.Clase + " Por: ");
            str.AppendLine(Instructor.ToString());

            str.AppendLine("Alumnos: ");
            foreach (Alumno a in this.Alumnos)
            {
                str.AppendLine(a.ToString());
            }

            retorno = str.ToString();

            return retorno;
        }


        /// <summary>
        /// Metodo para guardar los datos de la jornada en un archivo
        /// </summary>
        /// <param name="j"></param>Jornada a ser guardada
        /// <returns></returns>True si se pudo guardar, false si no
        public static bool Guardar(Jornada j)
        {
            Texto tex = new Texto();
            bool ok = true;

            if(tex.Guardar("Jornada.txt", j.ToString()) == false)
            {
                ok = false;
                IOException e = new IOException();
                throw new ArchivosException(e);
            }

            return ok;
        }


        /// <summary>
        /// Metodo para leer los datos de una jornada guardada en un archivo
        /// </summary>
        /// <returns></returns>Devuelve los datos de la jornada guardada
        public static string Leer()
        {
            Texto tex = new Texto();
            string retorno = "";

            if (tex.Leer("Jornada.txt", out retorno) == false)
            {
                IOException e = new IOException();
                throw new ArchivosException(e);
            }

            return retorno;
        }


        /// <summary>
        /// Compara si un alumno esta en una jornada
        /// </summary>
        /// <param name="j"></param>Jornada a ser comparada
        /// <param name="a"></param>Alumno a ser comparado
        /// <returns></returns>True si esta en la jornada, false si no lo esta
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool ok = false;

            if (j.Alumnos.Contains(a))
            {
                ok = true;
            }
            
            return ok;
        }

        /// <summary>
        /// Compara si un alumno esta en una jornada
        /// </summary>
        /// <param name="j"></param>Jornada a ser comparada
        /// <param name="a"></param>Alumno a ser comparado
        /// <returns></returns>True si esta en la jornada, false si no lo esta
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }


        /// <summary>
        /// Agrega un alumno a una jornada
        /// </summary>
        /// <param name="j"></param>Jornada a la cual se le agregara un alumno
        /// <param name="a"></param>Alumno a ser agregado
        /// <returns></returns>La jornada con el alumno agregado
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.Alumnos.Add(a);
            }
            
            return j;
        }

    }
}
