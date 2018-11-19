using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete:IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        

        /// <summary>
        /// Constructor de instancia que inicializa todos los atributos
        /// </summary>
        /// <param name="direccionEntrega"></param>Direccion del paquete
        /// <param name="trackingId"></param>trackingId del packete
        public Paquete(string direccionEntrega, string trackingId)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingId;
            this.estado = EEstado.Ingresado;
        }


        /// <summary>
        /// Propiedad de lectura/escritura de DireccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }

            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura/escritura de Estado
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }

            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura/escritura de TrackingID
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }

            set
            {
                this.trackingID = value;
            }
        }


        /// <summary>
        /// Muestra los datos del paquete
        /// </summary>
        /// <param name="elemento"></param>Paquete a mostrar
        /// <returns></returns>Los datos del paquete
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string retorno = "";

            if (elemento is Paquete)
            {
                retorno = string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
            }

            return retorno;
        }


        /// <summary>
        /// Metodo sobreescrito
        /// </summary>
        /// <returns></returns>Todos los datos del paquete
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.Append(this.MostrarDatos(this));
            str.AppendLine("(" + this.Estado + ")");

            retorno = str.ToString();
            
            return retorno;
        }


        /// <summary>
        /// Metodo que cambia el estado del paquete
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                this.InformaEstado.Invoke(this, null);

                Thread.Sleep(4000);

                if (this.Estado == EEstado.Ingresado)
                {
                    this.Estado = EEstado.EnViaje;
                }
                else
                {
                    this.Estado = EEstado.Entregado;
                }

            } while (this.Estado != EEstado.Entregado);

            this.InformaEstado.Invoke(this, null);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Compara si un paquete es igual al otro
        /// </summary>
        /// <param name="p1"></param>Paquete a ser comparado
        /// <param name="p2"></param>Paquete a ser comparado
        /// <returns></returns>True si son iguales, false si no
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool ok = false;

            if(p1.TrackingID == p2.TrackingID)
            {
                ok = true;
            }

            return ok;
        }

        /// <summary>
        /// Compara si un paquete no es igual al otro
        /// </summary>
        /// <param name="p1"></param>Paquete a ser comparado
        /// <param name="p2"></param>Paquete a ser comparado
        /// <returns></returns>True si no son iguales, false si lo son
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Enumerado de los estados que puede tener el paquete
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

    }
}
