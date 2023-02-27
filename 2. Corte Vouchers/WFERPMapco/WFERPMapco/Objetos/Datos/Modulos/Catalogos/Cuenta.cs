using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFERPMapco.Objetos.Utilerias;

namespace WFERPMapco.Objetos.Datos.Modulos.Catalogos
{
    public class Cuenta
    {
        ParametrosSQLMYSQL sqlPar = new ParametrosSQLMYSQL();
        DATABASEMYSQL dtbs = new DATABASEMYSQL();
        MySqlParameter[] sqlParametros;
        string pvarError;


        /*CONSULTAS*/
        public Resultado obtenerCuenta(int varIdBancoContable)
        {
            Resultado resultado = new Resultado();
            try
            {
                sqlParametros = new MySqlParameter[1];
                sqlPar = new ParametrosSQLMYSQL();
                DataSet ds = new DataSet();
                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "varIdBancoContable", 0, MySqlDbType.Int32, varIdBancoContable);
                //cuenta = dtbs.EjecutaSqlSP("GetCuenta", ref pvarError, "MYSQL");
                ds = dtbs.RegresaDataSet("GetCuenta", "CuentaR", ref pvarError, "MYSQL", sqlParametros);
                resultado.Datos = ds;
                resultado.Error = false;
            }
            catch (MySqlException e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:DataBase - obtenerCuenta]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            catch (Exception e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:Exception - obtenerCuenta]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            return resultado;
        }
    }
}
