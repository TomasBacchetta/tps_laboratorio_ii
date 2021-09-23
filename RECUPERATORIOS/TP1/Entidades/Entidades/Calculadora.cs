using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char op = ValidarOperador(operador);
            double resultado = 0;

            switch (op)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }
        /// <summary>
        /// Determina si el caracter ingresado como parámetro corresponde a un operador matemático válido
        /// </summary>
        /// <param name="operador">recibe la el caracter correspondiente al operador</param>
        /// <returns>devuelve el operador ingresado, siendo '+' si el operador no es válido</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '*' && operador != '/')
            {
                operador = '+';
            }
            return operador;
        }
    }
}
