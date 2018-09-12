using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
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

        }

        private double ValidarNumero(string strNumero)
        {
            double numero = 0;

            double.TryParse(strNumero, out numero);

            return numero;
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

            num = n1.numero + n2.numero;

            return num;
        }


    }
}
