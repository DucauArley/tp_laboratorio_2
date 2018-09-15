using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private static string ValdiarOperador(string operador)
        {
            string retorno = "+";

            if(operador == "-" || operador == "/" || operador == "*" || operador == "+")
            {
                retorno = operador;
            }

            return retorno;
        }

        public static double Operar(Numero n1, Numero n2, string operador)
        {
            double resultado = 0;

            operador = ValdiarOperador(operador);

            switch (operador)
            {
                case "+":
                    resultado = n1 + n2;
                    break;
                case "-":
                    resultado = n1 - n2;
                    break;
                case "/":
                    resultado = n1 / n2;
                    break;
                case "*":
                    resultado = n1 * n2;
                    break;
            }

            return resultado;
        }



    }
}
