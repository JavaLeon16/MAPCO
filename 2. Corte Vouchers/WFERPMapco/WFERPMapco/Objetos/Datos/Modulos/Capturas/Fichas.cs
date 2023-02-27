using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFERPMapco.Objetos.Utilerias;

namespace WFERPMapco.Objetos.Datos.Modulos.Capturas
{
    public class Fichas
    {
        ParametrosSQLMYSQL sqlPar = new ParametrosSQLMYSQL();
        DATABASEMYSQL dtbs = new DATABASEMYSQL();
        MySqlParameter[] sqlParametros;
        string pvarError;
        public Resultado GuardaFichas(int opcion, string json)
        {

            Resultado resultado = new Resultado();
            try
            {
                sqlParametros = new MySqlParameter[2];
                sqlPar = new ParametrosSQLMYSQL();
                DataSet ds = new DataSet();

                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "varOpcion", 0, MySqlDbType.Int32, opcion);
                sqlPar.AgregarParametro(ref sqlParametros, "VarData", 1, MySqlDbType.VarChar, json);
                ds = dtbs.RegresaDataSet("MantenimientoFichas", "FichaR", ref pvarError, "MYSQL", sqlParametros);
                resultado.Datos = ds;
                resultado.Error = false;
            }
            catch (MySqlException e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:DataBase - capturaFichas]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            catch (Exception e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:Exception - capturaFichas]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            return resultado;
        }

        public Resultado ConsultarFichas(DateTime fecha)
        {

            Resultado resultado = new Resultado();
            try
            {
                sqlParametros = new MySqlParameter[2];
                sqlPar = new ParametrosSQLMYSQL();
                DataSet ds = new DataSet();

                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "varOpcion", 0, MySqlDbType.Int32, 1);
                sqlPar.AgregarParametro(ref sqlParametros, "varFecha", 1, MySqlDbType.DateTime, fecha);
                ds = dtbs.RegresaDataSet("GetFichas", "FichaR", ref pvarError, "MYSQL", sqlParametros);
                resultado.Datos = ds;
                resultado.Error = false;
            }
            catch (MySqlException e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:DataBase - obtenerFichas]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            catch (Exception e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:Exception - obtenerFichas]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            return resultado;
        }
    }
}
