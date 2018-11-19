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
        public delegate void DelegadoEstado();
        private event DelegadoEstado InformaEstado;
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        
        public Paquete(string direccionEntrega, string trackingId)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingId;
            this.estado = EEstado.Ingresado;
        }

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

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string retorno;

            retorno = string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);

            return retorno;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            string retorno;

            str.Append(MostrarDatos(this));
            str.AppendLine("Estado: " + this.Estado);

            retorno = str.ToString();
            
            return retorno;
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool ok = false;

            if(p1.TrackingID == p2.TrackingID)
            {
                ok = true;
            }

            return ok;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public void MockCicloDeVida()
        {
            do
            {
                this.InformaEstado.Invoke();

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

            this.InformaEstado.Invoke();

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

    }
}
