using MySql.Data.MySqlClient;
using System;
using System.Data;
using WFERPMapco.Objetos.Utilerias;

namespace WFERPMapco.Objetos.Datos.Modulos.Capturas
{
    public class Menu
    {

        ParametrosSQLMYSQL sqlPar = new ParametrosSQLMYSQL();
        DATABASEMYSQL dtbs = new DATABASEMYSQL();
        MySqlParameter[] sqlParametros;
        string pvarError;

        /*C O N S U L T A S*/

        /// <summary>
        /// OBTENER LISTADOS DE MENU X USUARIO
        /// </summary>
        /// <param name="idUsuario"> USUARIO LOGUEADO</param>
        /// <returns></returns>
        public Resultado ObtenerMenu(int NumeroEmpleado, int IdSucursal)
        {
            Resultado resultado = new Resultado();
            try
            {
                sqlParametros = new MySqlParameter[3];
                sqlPar = new ParametrosSQLMYSQL();
                DataSet ds = new DataSet();

                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "VAROpcion", 0, MySqlDbType.Int32, 1);
                sqlPar.AgregarParametro(ref sqlParametros, "VARUsuario", 1, MySqlDbType.Int32, NumeroEmpleado);
                sqlPar.AgregarParametro(ref sqlParametros, "VARSucursal", 2, MySqlDbType.Int32, IdSucursal);
                ds = dtbs.RegresaDataSet("MENUUSUARIO", "Menu", ref pvarError, "MYSQL", sqlParametros);
                resultado.Datos = ds;
                resultado.Error = false;
            }
            catch (MySqlException e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:DataBase - obtenerMenu]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            catch (Exception e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:Exception - obtenerMenu]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            return resultado;
        }

        /// <summary>
        /// OBTENER PERMISOS POR USUARIO
        /// </summary>
        /// <param name="NumeroEmpleado"></param>
        /// <param name="IdSucursal"></param>
        /// <returns></returns>
        public Resultado obtenerPermisosUsuario(int NumeroEmpleado, int IdSucursal)
        {
            Resultado resultado = new Resultado();
            try
            {
                sqlParametros = new MySqlParameter[3];
                sqlPar = new ParametrosSQLMYSQL();
                DataSet ds = new DataSet();

                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "VAROpcion", 0, MySqlDbType.Int32, 2);
                sqlPar.AgregarParametro(ref sqlParametros, "VARUsuario", 1, MySqlDbType.Int32, NumeroEmpleado);
                sqlPar.AgregarParametro(ref sqlParametros, "VARSucursal", 2, MySqlDbType.Int32, IdSucursal);
                ds = dtbs.RegresaDataSet("MENUUSUARIO", "Menu", ref pvarError, "MYSQL", sqlParametros);
                resultado.Datos = ds;
                resultado.Error = false;
            }
            catch (MySqlException e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:DataBase - obtenerPermisosUsuario]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            catch (Exception e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:Exception - obtenerPermisosUsuario]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            return resultado;
        }

        public Resultado obtenerSucursalesUsuario(int NumeroEmpleado)
        {
            Resultado resultado = new Resultado();
            try
            {
                sqlParametros = new MySqlParameter[3];
                sqlPar = new ParametrosSQLMYSQL();
                DataSet ds = new DataSet();

                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "VAROpcion", 0, MySqlDbType.Int32, 3);
                sqlPar.AgregarParametro(ref sqlParametros, "VARUsuario", 1, MySqlDbType.Int32, NumeroEmpleado);
                sqlPar.AgregarParametro(ref sqlParametros, "VARSucursal", 2, MySqlDbType.Int32, 0);
                ds = dtbs.RegresaDataSet("MENUUSUARIO", "Menu", ref pvarError, "MYSQL", sqlParametros);
                resultado.Datos = ds;
                resultado.Error = false;
            }
            catch (MySqlException e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:DataBase - obtenerSucursalesUsuario]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            catch (Exception e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:Exception - obtenerSucursalesUsuario]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            return resultado;
        }


    }
}
