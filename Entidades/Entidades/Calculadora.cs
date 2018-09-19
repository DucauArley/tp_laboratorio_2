using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

        /// <summary>
        /// Valida que el operador enviado sea el correcto
        /// </summary>
        /// <param name="operador"></param>Operador a ser validado
        /// <returns></returns>El operador
        private static string ValdiarOperador(string operador)
        {
            string retorno = "+";

            if(operador == "-" || operador == "/" || operador == "*" || operador == "+")
            {
                retorno = operador;
            }

            return retorno;
        }


        /// <summary>
        /// Realiza operaciones matematicas
        /// </summary>
        /// <param name="n1"></param>Numero a operar
        /// <param name="n2"></param>Numero a operar
        /// <param name="operador"></param>Operador de la operacion
        /// <returns></returns>Resultado de la operacion matematica
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
