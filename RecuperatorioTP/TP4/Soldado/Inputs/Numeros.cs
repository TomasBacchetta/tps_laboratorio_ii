using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Numeros<T> where T: struct
    {
        public static bool DeterminarSiUnStringEsNumerico(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (typeof(T) == typeof(int))
                {
                    foreach (char caracter in input)
                    {
                        if (caracter < 48 || caracter > 57)//si alguno no corresponde a caracteres numéricos
                        {
                            return false;
                        }
                    }
                    return true;
                }
                
            }
            return false;//conforme sea necesario se agregará comprobaciones para float, etc

        }
    }
}
