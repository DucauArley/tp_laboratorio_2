using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete
    {
        public delegate void DelegadoEstado();
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        private event DelegadoEstado InformaEstado;



        public Paquete(string direccionEntrega, string trackingId)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingId;
        }






        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

    }
}
