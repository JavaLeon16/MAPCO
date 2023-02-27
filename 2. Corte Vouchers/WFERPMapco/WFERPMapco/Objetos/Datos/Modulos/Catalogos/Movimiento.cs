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
    
    public class Movimiento
    {
        ParametrosSQLMYSQL sqlPar = new ParametrosSQLMYSQL();
        DATABASEMYSQL dtbs = new DATABASEMYSQL();
        MySqlParameter[] sqlParametros;
        string pvarError;
        public Resultado obtenerMovimientos()
        {
            Resultado resultado = new Resultado();
            try
            {
                sqlParametros = new MySqlParameter[1];
                sqlPar = new ParametrosSQLMYSQL();
                DataSet ds = new DataSet();

                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "VAROpcion", 0, MySqlDbType.Int32, 1);
                ds = dtbs.RegresaDataSet("GetTipoMovimientoFicha", "MovimientoR", ref pvarError, "MYSQL", sqlParametros);
                resultado.Datos = ds;
                resultado.Error = false;
            }
            catch (MySqlException e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:DataBase - obtenerMovimientos]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            catch (Exception e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:Exception - obtenerMovimientos]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            return resultado;
        }
    }
}
