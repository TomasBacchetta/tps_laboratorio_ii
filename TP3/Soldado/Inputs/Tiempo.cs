using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Tiempo
    {
        public static bool ValidarFecha(string fecha)
        {
            int dia;
            int mes;
            int anio;
            string[] fechaDividida = new string[3];
            fechaDividida = fecha.Split('/');

            if (fechaDividida.Length < 3)//si no se dividio en 3 espacios
            {
                return false;
            }
            else
            {
                foreach (string palabra in fechaDividida)
                {
                    if (string.IsNullOrWhiteSpace(palabra))//si alguno de los espacios está vacío
                    {
                        return false;
                    }
                    else
                    {
                        foreach (char caracter in palabra)
                        {
                            if (caracter < 48 || caracter > 57)//si alguno no corresponde a caracteres numéricos
                            {
                                return false;
                            }
                        }

                    }
                }
                dia = int.Parse(fechaDividida[0]);
                mes = int.Parse(fechaDividida[1]);
                anio = int.Parse(fechaDividida[2]);

                if (anio < 1930 || anio > DateTime.Now.Year)//si el año es muy viejo o mayor al actual
                {
                    return false;
                }
                else
                {
                    if (mes < 1 || mes > 12 || (mes > DateTime.Now.Month && anio == DateTime.Now.Year))
                    {
                        return false;
                    }
                    else
                    {
                        if (dia < 1 || dia > CalcularDiasDeUnMes(mes, anio))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static DateTime ConvertirFechaStringEnDateTime(string fecha)
        {
            DateTime fechaConvertida;
            string[] fechaDividida = new string[3];
            if (ValidarFecha(fecha))
            {
                fechaDividida = fecha.Split('/');
                fechaConvertida = new DateTime(int.Parse(fechaDividida[2]), int.Parse(fechaDividida[1]), int.Parse(fechaDividida[0]));
            } else
            {
                fechaConvertida = DateTime.MinValue;
            }
            return fechaConvertida;
        }

        public static string ConvertirFechaDeNacimientoAString(DateTime fechaNacimiento)
        {
            return $"{fechaNacimiento.Day}/{fechaNacimiento.Month}/{fechaNacimiento.Year}";
        }
        public static string CalcularTiempoPasadoExtendido(DateTime fechaNacimiento, DateTime fechaActual)
        {
            int dia;
            int mes;
            int anio;

            dia = (int)fechaActual.Day - (int)fechaNacimiento.Day;
            mes = (int)fechaActual.Month - (int)fechaNacimiento.Month;
            anio = (int)fechaActual.Year - (int)fechaNacimiento.Year;
            if ((int)fechaNacimiento.Day > (int)fechaActual.Day)
            {
                dia += CalcularDiasDeUnMes(fechaNacimiento.Month, fechaNacimiento.Year);
                mes--;
            }
            if ((int)fechaNacimiento.Month > (int)fechaActual.Month)
            {
                mes += 12;
                anio--;
            }


            return $"{anio} años {mes} meses {dia} días";

        }

        public static string CalcularTiempoPasadoEnAños(DateTime fechaNacimiento, DateTime fechaActual)
        {
            string tiempo = CalcularTiempoPasadoExtendido(fechaNacimiento, fechaActual);
            return $"{tiempo[0]}{tiempo[1]}";
        }

        public static bool DetectarBisiesto(int anio)
        {
            bool esBisiesto = false;
            if (anio % 4 == 0 && (anio % 100 != 0 || anio % 400 == 0))
            {
                esBisiesto = true;
            }
            return esBisiesto;
        }

        public static int CalcularDiasDeUnMes(int mes, int anio)
        {
            int diasDelMes;

            //equivalente al algoritmo de los nudillos
            if (mes <= 7)
            {
                if (mes % 2 == 0)
                {
                    if (mes == 2)
                    {
                        if (DetectarBisiesto(anio))
                        {
                            diasDelMes = 29;
                        }
                        else
                        {
                            diasDelMes = 28;
                        }
                    }
                    else
                    {
                        diasDelMes = 30;
                    }
                }
                else
                {
                    diasDelMes = 31;
                }
            }
            else
            {
                if (mes % 2 == 0)
                {
                    diasDelMes = 31;
                }
                else
                {
                    diasDelMes = 30;
                }
            }
            return diasDelMes;
        }
    }
}
