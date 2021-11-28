using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Aquí se aplican extensamente los conceptos de SQL vistos en las clase 15 y 16
    /// </summary>
    public static class IncursionDB
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;
        static IncursionDB()
        {
            string cadenaConexion = ConexionDB.cadenaConexion;
            comando = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
        }

        public static SqlCommand Comando { get => comando; set => comando = value; }

        public static void ProbarConexion()
        {
            try
            {
                conexion.Open();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Elimina una fila de la tabla de incursiones base de datos en base a su codigo de incursión
        /// </summary>
        /// <param name="codigoIncursion"></param>
        public static void Eliminar(int codigoIncursion)
        {
            try
            {
                comando.Parameters.Clear();
                EscuadronDB.Eliminar(codigoIncursion);
                comando.CommandText = "DELETE FROM dbo.tabla_Incursiones WHERE N_INCURSION = @codigoIncursion;";
                comando.Parameters.AddWithValue("@codigoIncursion", codigoIncursion);
                conexion.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();

                }
            }

        }
        /// <summary>
        /// elimina indiscriminadamente todas las filas de la tabla de incursiones en la base de datos
        /// </summary>
        public static void EliminarTodo()
        {
            try
            {
                comando.Parameters.Clear();
                EscuadronDB.EliminarTodo();
                comando.CommandText = "DELETE FROM dbo.tabla_Incursiones;";
                conexion.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();

                }
            }
        }

        /// <summary>
        /// guarda una fila en la tabla de incursiones de la base de datos
        /// </summary>
        /// <param name="incursion"></param>
        public static void Guardar(Incursion incursion)
        {
            try
            {
                comando.Parameters.Clear();
                comando.CommandText = "INSERT INTO dbo.tabla_Incursiones(DESTINO, HORASALIDA, HORALLEGADA, N_BAJAS, N_CURACIONES, N_ARTEFACTOS, N_ANOMALIAS, ESCUADRON) " +
                    "VALUES (@destino, @horaSalida, @horaLlegada, @numBajas, @numCuraciones, @numArtefactos, @numAnomalias, @escuadron);";
                comando.Parameters.AddWithValue("@destino", incursion.Locacion);
                comando.Parameters.AddWithValue("@horaSalida", incursion.TiempoInicial);
                comando.Parameters.AddWithValue("@horaLlegada", incursion.TiempoFinal);
                comando.Parameters.AddWithValue("@numBajas", incursion.NumBajas);
                comando.Parameters.AddWithValue("@numCuraciones", incursion.NumCuraciones);
                comando.Parameters.AddWithValue("@numArtefactos", incursion.NumArtefactos);
                comando.Parameters.AddWithValue("@numAnomalias", incursion.NumAnomalias);
                comando.Parameters.AddWithValue("@escuadron", incursion.NombreEscuadron);
                conexion.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();

                }
            }

        }

        /// <summary>
        /// lee la base de datos sin tener en cuenta ningun orden ni criterio ni filtro
        /// </summary>
        /// <returns></returns>

        public static List<RegistroIncursion> Leer()
        {
            return Leer("", "", "");

        }

        public static List<RegistroIncursion> Leer(string orden, string criterio, string filtro)
        {
            List<RegistroIncursion> lista = new List<RegistroIncursion>();
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                string comandoFiltro;
                if (filtro == "Todos" || string.IsNullOrWhiteSpace(filtro))
                {
                    comandoFiltro = "ESCUADRON";
                } else
                {
                    comandoFiltro = $"'{filtro}'";
                }

                if (string.IsNullOrWhiteSpace(orden) || orden == "Por defecto" || string.IsNullOrWhiteSpace(criterio) || criterio == "Por defecto")
                {
                    comando.CommandText = "SELECT tabla_Incursiones.N_INCURSION as Num, DESTINO as  Lugar, HORASALIDA as Salida, HORALLEGADA as Llegada, N_BAJAS as Bajas, N_CURACIONES as Curaciones," +
                    " N_ARTEFACTOS as Artefactos, N_ANOMALIAS as Anomalias, ESCUADRON as NombreEscuadron, ASALTO as Asalto, MEDICO as Medico, TECNICO as Tecnico, RECONOCIMIENTO as Reconocimiento " +
                    "FROM dbo.tabla_Incursiones INNER JOIN tabla_Escuadrones ON tabla_Incursiones.N_INCURSION = tabla_Escuadrones.N_INCURSION WHERE ESCUADRON = " + $"{comandoFiltro}" + ";";
                } else
                {
                    if (criterio == "Descendente")
                    {
                        comando.CommandText = "SELECT tabla_Incursiones.N_INCURSION as Num, DESTINO as  Lugar, HORASALIDA as Salida, HORALLEGADA as Llegada, N_BAJAS as Bajas, N_CURACIONES as Curaciones," +
                    " N_ARTEFACTOS as Artefactos, N_ANOMALIAS as Anomalias, ESCUADRON as NombreEscuadron, ASALTO as Asalto, MEDICO as Medico, TECNICO as Tecnico, RECONOCIMIENTO as Reconocimiento " +
                    "FROM dbo.tabla_Incursiones INNER JOIN tabla_Escuadrones ON tabla_Incursiones.N_INCURSION = tabla_Escuadrones.N_INCURSION WHERE ESCUADRON = "+$"{comandoFiltro}"+" ORDER BY " + $"{orden}" + " DESC;";
                    } else
                    {
                        comando.CommandText = "SELECT tabla_Incursiones.N_INCURSION as Num, DESTINO as  Lugar, HORASALIDA as Salida, HORALLEGADA as Llegada, N_BAJAS as Bajas, N_CURACIONES as Curaciones," +
                    " N_ARTEFACTOS as Artefactos, N_ANOMALIAS as Anomalias, ESCUADRON as NombreEscuadron, ASALTO as Asalto, MEDICO as Medico, TECNICO as Tecnico, RECONOCIMIENTO as Reconocimiento " +
                    "FROM dbo.tabla_Incursiones INNER JOIN tabla_Escuadrones ON tabla_Incursiones.N_INCURSION = tabla_Escuadrones.N_INCURSION WHERE ESCUADRON = " + $"{comandoFiltro}" + " ORDER BY " + $"{orden}"+ " ASC;";
                    }
                    
                }

                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    lista.Add(new RegistroIncursion(Convert.ToInt32(dataReader["Num"]), Convert.ToDateTime(dataReader["Salida"]), Convert.ToDateTime(dataReader["Llegada"]),
                        Convert.ToInt32(dataReader["Bajas"]), Convert.ToInt32(dataReader["Curaciones"]), Convert.ToInt32(dataReader["Artefactos"]),
                        Convert.ToInt32(dataReader["Anomalias"]), dataReader["Lugar"].ToString(), dataReader["NombreEscuadron"].ToString(), dataReader["Asalto"].ToString(), 
                        dataReader["Medico"].ToString(), dataReader["Tecnico"].ToString(), dataReader["Reconocimiento"].ToString()));
                }
                dataReader.Close();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();

                }
            }
            return lista;

        }

        /// <summary>
        /// obtiene el numero de incursion de la última incursión guardada. Esto sirve para conferirle un codigo a la tabla de miembros de escuadron
        /// </summary>
        /// <returns></returns>
        public static int ObtenerCodigoDeLaUltimaIncursionGuardada()
        {
            int numeroIncursion = 0;

            try
            {
                comando.Parameters.Clear();
                conexion.Open();

                comando.CommandText = "SELECT N_INCURSION as numIncursion FROM dbo.tabla_Incursiones WHERE N_INCURSION = (SELECT MAX(N_INCURSION) FROM dbo.tabla_Incursiones);";
                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    numeroIncursion = Convert.ToInt32(dataReader["numIncursion"]);
                }

                dataReader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();

                }
            }

            return numeroIncursion;
        }
        public static Dictionary<string, int> DevolverCantidadDeVecesQueAparecenLosLugares()
        {
            Dictionary<string, int> cantidadRepeticionesLugar = new Dictionary<string, int>();

            try
            {
                comando.Parameters.Clear();
                conexion.Open();

                comando.CommandText = "SELECT DESTINO FROM tabla_Incursiones; ";
                
                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    if (cantidadRepeticionesLugar.ContainsKey(dataReader["DESTINO"].ToString()))
                    {
                        cantidadRepeticionesLugar[dataReader["DESTINO"].ToString()]++;
                    } else
                    {
                        cantidadRepeticionesLugar.Add(dataReader["DESTINO"].ToString(), 1);
                    }

                }
                dataReader.Close();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();

                }
            }
            return cantidadRepeticionesLugar;
        }



    }


}
