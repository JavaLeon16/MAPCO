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
    public class Login
    {
        ParametrosSQLMYSQL sqlPar = new ParametrosSQLMYSQL();
        DATABASEMYSQL dtbs = new DATABASEMYSQL();
        MySqlParameter[] sqlParametros;
        string pvarError;

        /*C O N S U L T A S*/

        /// <summary>
        /// OBTENER SUCURSALES OMITIENDO SUCURSALES DE PRUEBAS E INACTIVAS
        /// </summary>
        /// <returns></returns>
        public Resultado obtenerSucursales()
        {
            Resultado resultado = new Resultado();
            try
            {
                sqlParametros = new MySqlParameter[2];
                sqlPar = new ParametrosSQLMYSQL();
                DataSet ds = new DataSet();

                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "VAROpcion", 0, MySqlDbType.Int32, 1);
                sqlPar.AgregarParametro(ref sqlParametros, "VARUsuario", 1, MySqlDbType.Int32, 0);
                ds = dtbs.RegresaDataSet("Login", "Menu", ref pvarError, "MYSQL", sqlParametros);
                resultado.Datos = ds;
                resultado.Error = false;
            }
            catch (MySqlException e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:DataBase - obtenerSucursales]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            catch (Exception e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:Exception - obtenerSucursales]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            return resultado;
        }

        /// <summary>
        /// OBTENER USUARIO PARA LOGIN
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public Resultado obtenerLogin(int numeroEmpleado)
        {
            Resultado resultado = new Resultado();
            try
            {
                sqlParametros = new MySqlParameter[2];
                sqlPar = new ParametrosSQLMYSQL();
                DataSet ds = new DataSet();

                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "VAROpcion", 0, MySqlDbType.Int32, 2);
                sqlPar.AgregarParametro(ref sqlParametros, "VARUsuario", 1, MySqlDbType.Int32, numeroEmpleado);
                ds = dtbs.RegresaDataSet("Login", "Menu", ref pvarError, "MYSQL", sqlParametros);
                resultado.Datos = ds;
                resultado.Error = false;
            }
            catch (MySqlException e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:DataBase - obtenerUsuarioLogin]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            catch (Exception e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:Exception - obtenerUsuarioLogin]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            return resultado;
        }
    }
}
