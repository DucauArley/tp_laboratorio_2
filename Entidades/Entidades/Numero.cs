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

        public Numero()
        {

        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            setNumero = strNumero;
        }

        private double ValidarNumero(string strNumero)
        {
            double numero = 0;

            double.TryParse(strNumero, out numero);

            return numero;
        }

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
