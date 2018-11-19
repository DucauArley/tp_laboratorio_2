using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo:IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }

            set
            {
                this.paquetes = value;
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            foreach (Paquete p in (List<Paquete>)elementos)
            {
                str.AppendLine(p.ToString());
            }

            retorno = str.ToString();

            return retorno;
        }

        public void FinEntregas()
        {
            foreach (Thread t in this.mockPaquetes)
            {
                if (t.IsAlive)
                {
                    t.Abort();
                }
            }
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete pac in c.Paquetes)
            {
                if (p == pac)
                {
                    throw new TrakingIdRepetidoException("El paquete se encuentra en la lista");
                }
            }

            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;


        }


    }
}
