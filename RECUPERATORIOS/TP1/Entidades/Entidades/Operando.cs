using System;
using System.Text;


namespace Entidades
{
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
        /// <summary>
        /// Convierte la cadena de caracteres al sistema decimal
        /// </summary>
        /// <param name="binario">recibe la cadena de caracteres presuntamente binaria</param>
        /// <returns>devuelve la cadena covertida de un double pasado a sistema decimal, si no lo pudo realizar la conversion previa, devuelve dato inválido</returns>
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
        /// <summary>
        /// Convierte un valor en sistema decimal a binario en base a un parametro de tipo double
        /// </summary>
        /// <param name="numero">recibe el numero presuntamente decimal en tipo double</param>
        /// <returns>devuelve la cadena de caracteres del valor convertido a binario</returns>
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
        /// <summary>
        /// Convierte un valor en sistema decimal a binario en base a un parametro de tipo string
        /// </summary>
        /// <param name="numero">recibe la cadena de caracteres correspondiente al numero presuntamente decimal</param>
        /// <returns>devuelve el valor convertido a binario en formato string, si no puede realizar la conversion, devuelve "valor invalido"</returns>
        public static string DecimalBinario(string numero)
        {
            if (!double.TryParse(numero, out double retorno)){
                return "Valor Inválido";
            }
            return DecimalBinario(retorno);
        }
        /// <summary>
        /// determina si un numero es binario 
        /// </summary>
        /// <param name="binario">recibe el numero presuntamente binario en formato string</param>
        /// <returns>devuelve true si es binario, false si no lo es</returns>
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
        /// <summary>
        /// determina si un operando es valido para operar
        /// </summary>
        /// <param name="strNumero">recibe el operando en formato string</param>
        /// <returns>devuelve el numero convertido en double si logra hacer la conversion, caso contrario devuelve 0</returns>
        private double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double retorno))//es necesario que en calculadora se escriba "," o "." dependiendo del idioma del visual studio
            {
                return retorno;
            }
            return 0;
        }
    }
}
