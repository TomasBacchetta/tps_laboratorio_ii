using System;
using System.Text;


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
        
        private static char ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '*' && operador != '/')
            {
                operador = '+';
            }
            return operador;
        }
    }

    public class Operando
    {
        private double numero;
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }
        public Operando()
        {
            this.numero = 0;
        }

        public Operando(double numero)
        {
            this.Numero = numero.ToString();
        }

        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        public static string BinarioDecimal(string binario)
        {
            double numeroDecimal = 0;
            if (EsBinario(binario))
            {
                for (int x = 0; x < binario.Length; x++)
                {

                    if (binario[x] == '1')
                    {
                        numeroDecimal += Math.Pow(2, binario.Length - 1 - x);
                    }

                }

                return numeroDecimal.ToString();
            }
            return "Valor Inválido";
            
        }

        public static string DecimalBinario(double numero)
        {
            string digitoBinarioStr;
            string numeroBinarioStrInvertido;
            int posicionNueva = 0;
            int numeroEntero = (int)Math.Abs(numero);
            StringBuilder stringBuilder = new StringBuilder();

            do
            {
                digitoBinarioStr = (numeroEntero % 2).ToString();
                numeroEntero /= 2;
                stringBuilder.Append(digitoBinarioStr);

            } while (numeroEntero >= 1);

            numeroBinarioStrInvertido = stringBuilder.ToString();
            stringBuilder.Clear();

            for (int x = numeroBinarioStrInvertido.Length - 1; x >= 0; x--)
            {
                stringBuilder.Append(numeroBinarioStrInvertido[x]);
                posicionNueva++;
            }
            return stringBuilder.ToString();
        }

        public static string DecimalBinario(string numero)
        {
            if (!double.TryParse(numero, out double retorno)){
                return "Valor Inválido";
            }
            return DecimalBinario(retorno);
        }

        private static bool EsBinario(string binario)
        {
            int resultado;

            foreach (char digito in binario)
            {
                if (digito != '1' && digito != '0')
                {
                    return false;
                }
            }
            if (int.TryParse(binario, out resultado))
            {
                if (resultado >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            return double.MinValue;
        }
        
        private double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double retorno))//es necesario que en calculadora se escriba ","
            {
                return retorno;
            }
            return 0;
        }
    }
}
