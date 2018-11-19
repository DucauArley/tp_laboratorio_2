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


        /// <summary>
        /// Constructor de instancia que inicializa los atributos
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Propiedad de lectura/escritura de la lista de paquetes
        /// </summary>
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


        /// <summary>
        /// Muestra los datos de la lista de paquetes
        /// </summary>
        /// <param name="elementos"></param>Lista de paquetes a mostrar
        /// <returns></returns>Los datos de los paquetes
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            if (elementos is Correo)
            {
                foreach (Paquete p in ((Correo)elementos).Paquetes)
                {
                    str.AppendLine(p.ToString());
                }
            }

            retorno = str.ToString();

            return retorno;
        }


        /// <summary>
        /// Metodo que cierra todos los hilos que esten activos
        /// </summary>
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


        /// <summary>
        /// Agrega un paquete al correo
        /// </summary>
        /// <param name="c"></param>Correo al cual se le agregara un paquete
        /// <param name="p"></param>Paquete a ser agregado al correo
        /// <returns></returns>El correo con el paquete agregado
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete pac in c.Paquetes)
            {
                if (p == pac)
                {
                    throw new TrackingIdRepetidoException("El paquete se encuentra en la lista");
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
