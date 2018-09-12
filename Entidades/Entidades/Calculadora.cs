using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Calculadora
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

        public double Operar(Numero n1, Numero n2, string operador)
        {
            double resultado;

            operador = ValdiarOperador(operador);

            switch (operador)
            {




            }



            return resultado;
        }



    }
}
