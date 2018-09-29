using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum ETipo
        {
            Entera, Descremada
        }

        private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>La marca del producto
        /// <param name="patente"></param>El codigo de barras del producto
        /// <param name="color"></param>El color del empaque del producto
        public Leche(EMarca marca, string patente, ConsoleColor color): base(patente, marca, color)
        {
            this.tipo = ETipo.Entera;
        }

        /// <summary>
        /// Constructor que asigna los valores introducidos
        /// </summary>
        /// <param name="marca"></param>La marca del producto
        /// <param name="patente"></param>El codigo de barras del producto
        /// <param name="color"></param>El color del empaque del producto
        /// <param name="tipo"></param>Tipo de producto
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo):this(marca, patente, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
