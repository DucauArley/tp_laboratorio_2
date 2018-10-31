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

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
        {
            this.clase = clase;
            this.instructor = instructor;
        }

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

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.Append("Clase de: " + this.Clase + "Por: ");
            str.Append(Instructor.ToString());

            foreach (Alumno a in this.Alumnos)
            {
                str.Append(a.ToString());
            }

            retorno = str.ToString();

            return retorno;
        }

        public bool Guardar(Jornada j)
        {
            Texto tex = new Texto();
            bool ok = true;

            if(tex.Guardar("Jornada.txt", j.ToString()) == false)
            {
                throw new ArchivosException(null);//#############################
                ok = false;
            }

            return ok;
        }

        public string Leer(Jornada j)
        {
            Texto tex = new Texto();
            string retorno;

            if (tex.Leer("Jornada.txt", out retorno) == false)
            {
                throw new ArchivosException(null);//#############################
            }

            return retorno;
        }



        public static bool operator ==(Jornada j, Alumno a)
        {
            bool ok = false;

            if (j.Alumnos.Contains(a))
            {
                ok = true;
            }
            
            return ok;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

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
