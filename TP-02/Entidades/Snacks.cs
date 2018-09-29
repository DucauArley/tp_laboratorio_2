using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks:Producto
    {


        /// <summary>
        /// Constructor que asigna los valores introducidos
        /// </summary>
        /// <param name="marca"></param>La marca del producto
        /// <param name="patente"></param>El codigo de barras del producto
        /// <param name="color"></param>El color del empaque del producto
        public Snacks(EMarca marca, string patente, ConsoleColor color): base(patente, marca, color)
        {
        }

        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
