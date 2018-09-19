using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;



        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Numero()
        {

        }

        /// <summary>
        /// Constructor que asigna el valor introducido
        /// </summary>
        /// <param name="numero"></param>El numero que se le asigna en formato double
        public Numero(double numero)
        {
            this.numero = numero;
        }
        
        /// <summary>
        /// Constructor que asigna el valor introducido
        /// </summary>
        /// <param name="strNumero"></param>EL numero que se le asigna en formato string
        public Numero(string strNumero)
        {
            setNumero = strNumero;
        }

        /// <summary>
        /// Valida que se pueda pasar a double el string pasado por parametro
        /// </summary>
        /// <param name="strNumero"></param>String a ser convertido en double
        /// <returns></returns>Double parseado del string
        private double ValidarNumero(string strNumero)
        {
            double numero = 0;

            double.TryParse(strNumero, out numero);

            return numero;
        }

        /// <summary>
        /// Setter de la variable numero
        /// </summary>
        public string setNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        
        public static double operator +(Numero n1, Numero n2)
        {
            double num;

            num = n1.numero + n2.numero;

            return num;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double num;

            num = n1.numero - n2.numero;

            return num;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double num;

            num = n1.numero / n2.numero;

            return num;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double num;

            num = n1.numero * n2.numero;

            return num;
        }

        /// <summary>
        /// Convierte un numero binario en decimal
        /// </summary>
        /// <param name="binario"></param>String a ser convertido
        /// <returns></returns>Numero binario convertido en Double
        public static string BinarioDecimal(string binario)
        {
            double numero = 0;
            string retorno;
            int j = binario.Length - 1;

            for (int i = 0; i < binario.Length; i++)
            {
                numero += double.Parse(binario[j].ToString()) * Math.Pow(2, i);
                j--;
            }

            retorno = "" + numero;

            return retorno;
        }

        /// <summary>
        /// Convierte un numero decimal en binario
        /// </summary>
        /// <param name="numero"></param>Numero a ser convertido
        /// <returns></returns>Numero convertido en binario en formato String
        public static string DecimalBinario(double numero)
        {
            string binario = "";

            while (numero != 0 && numero != 1)
            {
                if (numero % 2 == 0)
                {
                    binario = "0" + binario;
                }
                else
                {
                    binario = "1" + binario;
                }

                numero = Math.Truncate(numero / 2);
            }

            binario = numero + binario;

            return binario;
        }


        /// <summary>
        /// Convierte un numero decimal en binario
        /// </summary>
        /// <param name="numero"></param>Numero a ser convertido en formato String
        /// <returns></returns>Numero convertido en binario en formato String
        public static string DecimalBinario(string numero)
        {
            string binario;
            double num;

            double.TryParse(numero, out num);

            binario = DecimalBinario(num);

            return binario;
        }
    }
}
