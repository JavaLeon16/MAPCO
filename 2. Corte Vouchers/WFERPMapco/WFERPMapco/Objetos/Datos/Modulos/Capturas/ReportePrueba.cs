using MySql.Data.MySqlClient;
using System;
using System.Data;
using WFERPMapco.Objetos.Utilerias;

namespace WFERPMapco.Objetos.Datos.Modulos.Capturas
{
    public class ReportePrueba
    {

        ParametrosSQLMYSQL sqlPar = new ParametrosSQLMYSQL();
        DATABASEMYSQL dtbs = new DATABASEMYSQL();
        MySqlParameter[] sqlParametros;
        string pvarError;
        Resultado resultado = new Resultado();


        ///----- C O N S U L T A S-----///

        public Resultado obtenerDatos(string Descripcion)
        {

            try
            {
                sqlParametros = new MySqlParameter[2];
                sqlPar = new ParametrosSQLMYSQL();

                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "VAROpcion", 0, MySqlDbType.Int32, 1);
                sqlPar.AgregarParametro(ref sqlParametros, "VARFiltro", 1, MySqlDbType.VarChar,50, Descripcion);
                resultado.Datos = dtbs.RegresaDataSet("PruebaSP", "PrubaTabla", ref pvarError, "MYSQL", sqlParametros);
                resultado.Error = false;
            }
            catch (MySqlException e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:DataBase - obtenerPrueba]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            catch (Exception e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:Exception - obtenerPrueba]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            return resultado;
        }
    }
}
