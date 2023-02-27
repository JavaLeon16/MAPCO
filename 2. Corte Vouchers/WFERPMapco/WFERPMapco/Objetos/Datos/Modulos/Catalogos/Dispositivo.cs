using MySql.Data.MySqlClient;
using System;
using System.Data;
using WFERPMapco.Objetos.Utilerias;

namespace WFERPMapco.Objetos.Datos.Modulos.Catalogos
{
    public class Dispositivo
    {
        ParametrosSQLMYSQL sqlPar = new ParametrosSQLMYSQL();
        DATABASEMYSQL dtbs = new DATABASEMYSQL();
        MySqlParameter[] sqlParametros;
        string pvarError;

        /*CONSULTAS*/
        public Resultado obtenerDispositivo()
        {
            Resultado resultado = new Resultado();
            try
            {
                sqlParametros = new MySqlParameter[1];
                sqlPar = new ParametrosSQLMYSQL();
                DataSet ds = new DataSet();

                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "VAROpcion", 0, MySqlDbType.Int32, 1);
                ds = dtbs.RegresaDataSet("GetDispositivos", "DispositivoT", ref pvarError, "MYSQL", sqlParametros);
                resultado.Datos = ds;
                resultado.Error = false;
            }
            catch (MySqlException e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:DataBase - obtenerDispositivo]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            catch (Exception e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:Exception - obtenerDispositivo]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            return resultado;
        }
    }
}
