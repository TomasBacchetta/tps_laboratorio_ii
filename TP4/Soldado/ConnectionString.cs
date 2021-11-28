using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Pedido en la correcion. Establece un parámetro estatatico que contiene la cadena de conexion para el manejo de base de datos.
    /// Permite que la más que probable modificación de la cadena string se vea reflejada en EscuadronDB.cs e IncursionDB.cs
    /// </summary>
    public static class ConnectionString
    {
        public static string cadenaConexion = @"Data Source =./;Initial Catalog=REGISTROINCURSIONES_DB;Integrated Security=True";
    }
}
