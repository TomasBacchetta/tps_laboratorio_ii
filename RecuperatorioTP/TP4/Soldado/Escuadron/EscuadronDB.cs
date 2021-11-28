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
    public static class EscuadronDB
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;
        static EscuadronDB()
        {
            string cadenaConexion = ConexionDB.cadenaConexion;
            comando = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
        }

        public static SqlCommand Comando { get => comando; set => comando = value; }

        
        public static void Eliminar(int numIncursion)
        {
     
            try
            {
                comando.Parameters.Clear();
                comando.CommandText = "DELETE FROM tabla_Escuadrones WHERE N_INCURSION = @codigoIncursion;";
                comando.Parameters.AddWithValue("@codigoIncursion", numIncursion);
                conexion.Open();

                comando.ExecuteNonQuery();
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
        public static void EliminarTodo()
        {
            try
            {
                comando.Parameters.Clear();
                comando.CommandText = "DELETE FROM dbo.tabla_Escuadrones;";
                conexion.Open();

                comando.ExecuteNonQuery();
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

        public static void Guardar(Escuadron escuadron)
        {
            try
            {
                comando.Parameters.Clear();
                comando.CommandText = "INSERT INTO dbo.tabla_Escuadrones(N_INCURSION, ASALTO, MEDICO, TECNICO, RECONOCIMIENTO) " +
                    "VALUES (@nIncursion, @Asalto, @Medico, @Tecnico, @Reconocimiento);";
                comando.Parameters.AddWithValue("@nIncursion", IncursionDB.ObtenerCodigoDeLaUltimaIncursionGuardada());
                comando.Parameters.AddWithValue("@Asalto", escuadron.BuscarSoldadoPorClase(Soldado.ClaseSoldado.Asalto).NombreYApellido);
                comando.Parameters.AddWithValue("@Medico", escuadron.BuscarSoldadoPorClase(Soldado.ClaseSoldado.Medico).NombreYApellido);
                comando.Parameters.AddWithValue("@Tecnico", escuadron.BuscarSoldadoPorClase(Soldado.ClaseSoldado.Tecnico).NombreYApellido);
                comando.Parameters.AddWithValue("@Reconocimiento", escuadron.BuscarSoldadoPorClase(Soldado.ClaseSoldado.Reconocimiento).NombreYApellido);
                
                conexion.Open();

                comando.ExecuteNonQuery();
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

        public static int[] DevolverEstadisticasHistoricasDeEscuadron(Escuadron.NombreEscuadron escuadron)
        {
            int[] arrayEstadisticas = new int[] { 0, 0, 0, 0, 0};

            try
            {
                comando.Parameters.Clear();
                conexion.Open();

                comando.CommandText = "SELECT N_BAJAS as Bajas, N_CURACIONES as Curaciones, N_ARTEFACTOS as Artefactos, N_ANOMALIAS as Anomalias FROM tabla_Incursiones WHERE ESCUADRON = @nombreEscuadron; ";
                comando.Parameters.AddWithValue("@nombreEscuadron", escuadron.ToString());
                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                        arrayEstadisticas[0] += Convert.ToInt32(dataReader["Bajas"]);
                        arrayEstadisticas[1] += Convert.ToInt32(dataReader["Curaciones"]);
                        arrayEstadisticas[2] += Convert.ToInt32(dataReader["Artefactos"]);
                        arrayEstadisticas[3] += Convert.ToInt32(dataReader["Anomalias"]);
                        arrayEstadisticas[4] += 1; //numero de incursiones
                    
                }
                dataReader.Close();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return arrayEstadisticas;
        }
        

    }
}
