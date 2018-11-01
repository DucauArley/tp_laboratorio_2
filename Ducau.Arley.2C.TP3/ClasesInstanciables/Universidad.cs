using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
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

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            foreach (Jornada j in uni.Jornadas)
            {
                str.Append(j.ToString());
            }

            retorno = str.ToString();

            return retorno;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.Append(MostrarDatos(this));

            retorno = str.ToString();

            return retorno;
        }



        public static bool operator ==(Universidad g, Alumno a)
        {
            bool ok = false;

            if (g.Alumnos.Contains(a))
            {
                ok = true;
            }
            
            return ok;
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool ok = false;

            if (g.Instructores.Contains(i))
            {
                ok = true;
            }
            
            return ok;
        }

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


        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

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

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.Alumnos.Add(a);
            }

            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u != i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }

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

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
