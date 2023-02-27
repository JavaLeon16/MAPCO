using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFERPMapco.Clases;
using WFERPMapco.Objetos.Utilerias;

namespace WFERPMapco.Objetos.Datos.Modulos.Catalogos
{
    public class Operacion
    {
        ParametrosSQLMYSQL sqlPar = new ParametrosSQLMYSQL();
        DATABASEMYSQL dtbs = new DATABASEMYSQL();
        MySqlParameter[] sqlParametros;
        string pvarError;

        /*Guardar-actualizar-eliminar*/
        public Resultado MantenimientoTipoOperacion(int varOpcion,OperacionTipo operacion)
        {
            Resultado resultado = new Resultado();
            try
            {
                sqlParametros = new MySqlParameter[23];
                sqlPar = new ParametrosSQLMYSQL();
                DataSet ds = new DataSet();

                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "varOpcion", 0, MySqlDbType.Int32, varOpcion);
                sqlPar.AgregarParametro(ref sqlParametros, "varIdTipoOperacion", 1, MySqlDbType.Int32, operacion.IdTipoOperacion);
                sqlPar.AgregarParametro(ref sqlParametros, "varIdBanco", 2, MySqlDbType.Int32, operacion.IdBanco);
                sqlPar.AgregarParametro(ref sqlParametros, "varDescripcion", 3, MySqlDbType.VarChar,100, operacion.Descripcion);
                sqlPar.AgregarParametro(ref sqlParametros, "varImporteMaximo", 4, MySqlDbType.Double, operacion.ImporteMaximo);
                sqlPar.AgregarParametro(ref sqlParametros, "varImporteComisionFija", 5, MySqlDbType.Double, operacion.ImporteComisionFija);
                sqlPar.AgregarParametro(ref sqlParametros, "varPorcentajeComision", 6, MySqlDbType.Double, operacion.PorcentajeComision);
                sqlPar.AgregarParametro(ref sqlParametros, "varPorcentajeProteccion", 7, MySqlDbType.Double, operacion.PorcentajeProteccion);
                sqlPar.AgregarParametro(ref sqlParametros, "varTipoOperacion", 8, MySqlDbType.Bit, operacion.IdTO);
                sqlPar.AgregarParametro(ref sqlParametros, "varEsPromocion", 9, MySqlDbType.Bit, operacion.EsPromocion);
                sqlPar.AgregarParametro(ref sqlParametros, "varCompraMinima", 10, MySqlDbType.Double, operacion.CompraMinima);
                sqlPar.AgregarParametro(ref sqlParametros, "varMeses", 11, MySqlDbType.Int32, operacion.Meses);
                sqlPar.AgregarParametro(ref sqlParametros, "varKlaveKarum", 12, MySqlDbType.VarChar,10, operacion.KlaveKarum);
                sqlPar.AgregarParametro(ref sqlParametros, "varPorcentajeComisionFinancieraMapco", 13, MySqlDbType.Double, operacion.PorcentajeComisionFinancieraMapco);
                sqlPar.AgregarParametro(ref sqlParametros, "varCapturaManual", 14, MySqlDbType.Int32, operacion.CapturaManual);
                sqlPar.AgregarParametro(ref sqlParametros, "varIdDispositivo", 15, MySqlDbType.Int32, operacion.IdDispositivo);
                sqlPar.AgregarParametro(ref sqlParametros, "varUsuarioInsert", 16, MySqlDbType.Int32, operacion.UsuarioInsert);
                sqlPar.AgregarParametro(ref sqlParametros, "varFechaInsert", 17, MySqlDbType.DateTime, operacion.FechaInsert);
                sqlPar.AgregarParametro(ref sqlParametros, "varEstatus", 18, MySqlDbType.Bit, operacion.Estatus);
                sqlPar.AgregarParametro(ref sqlParametros, "varUsuarioUpdate", 19, MySqlDbType.Int32, operacion.UsuarioUpdate);
                sqlPar.AgregarParametro(ref sqlParametros, "varFechaUpdate", 20, MySqlDbType.DateTime, operacion.FechaUpdate);
                sqlPar.AgregarParametro(ref sqlParametros, "varUsuarioBaja", 21, MySqlDbType.Int32, operacion.UsuarioBaja);
                sqlPar.AgregarParametro(ref sqlParametros, "varFechaBaja", 22, MySqlDbType.DateTime, operacion.FechaBaja);
                ds = dtbs.RegresaDataSet("MantenimientoTipoOperacion", "TipoOperacionT", ref pvarError, "MYSQL", sqlParametros);
                resultado.Datos = ds;
                resultado.Error = false;
            }
            catch (MySqlException e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:DataBase - obtenerTipoOperacion]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            catch (Exception e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:Exception - obtenerTipoOperacion]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            return resultado;
        }

        /*Guardar-actualizar-eliminar*/
        /*public Resultado MantenimientoTipoOperacion(int varOpcion, int varIdTipoOperacion, int varIdBanco, 
                                                    string varDescripcion, double varImporteMaximo, double varImporteComisionFija,
                                                    double varPorcentajeComision, double varPorcentajeProteccion, bool varTipoOperacion, 
                                                    bool varEsPromocion, double varCompraMinima, int varMeses, string varKlaveKarum, 
                                                    double varPorcentajeComisionFinancieraMapco, bool varCapturaManual, int varIdDispositivo, 
                                                    int varUsuarioInsert, DateTime varFechaInsert, bool varEstatus, int varUsuarioUpdate,
                                                    DateTime varFechaUpdate, int varUsuarioBaja, DateTime varFechaBaja)
        {
            Resultado resultado = new Resultado();
            try
            {
                sqlParametros = new MySqlParameter[1];
                sqlPar = new ParametrosSQLMYSQL();
                DataSet ds = new DataSet();

                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "varOpcion", 0, MySqlDbType.Int32, varOpcion);
                sqlPar.AgregarParametro(ref sqlParametros, "varIdTipoOperacion", 1, MySqlDbType.Int32, varIdTipoOperacion);
                sqlPar.AgregarParametro(ref sqlParametros, "varIdBanco", 1, MySqlDbType.Int32, varIdBanco);
                sqlPar.AgregarParametro(ref sqlParametros, "varDescripcion", 1, MySqlDbType.VarChar,100, varDescripcion);
                sqlPar.AgregarParametro(ref sqlParametros, "varImporteMaximo", 1, MySqlDbType.Double, varImporteMaximo);
                sqlPar.AgregarParametro(ref sqlParametros, "varImporteComisionFija", 1, MySqlDbType.Double, varImporteComisionFija);
                sqlPar.AgregarParametro(ref sqlParametros, "varPorcentajeComision", 1, MySqlDbType.Double, varPorcentajeComision);
                sqlPar.AgregarParametro(ref sqlParametros, "varPorcentajeProteccion", 1, MySqlDbType.Double, varPorcentajeProteccion);
                sqlPar.AgregarParametro(ref sqlParametros, "varTipoOperacion", 1, MySqlDbType.Bit, varTipoOperacion);
                sqlPar.AgregarParametro(ref sqlParametros, "varEsPromocion", 1, MySqlDbType.Bit, varEsPromocion);
                sqlPar.AgregarParametro(ref sqlParametros, "varCompraMinima", 1, MySqlDbType.Double, varCompraMinima);
                sqlPar.AgregarParametro(ref sqlParametros, "varMeses", 1, MySqlDbType.Int32, varMeses);
                sqlPar.AgregarParametro(ref sqlParametros, "varKlaveKarum", 1, MySqlDbType.VarChar,10, varKlaveKarum);
                sqlPar.AgregarParametro(ref sqlParametros, "varPorcentajeComisionFinancieraMapco", 1, MySqlDbType.Double, varPorcentajeComisionFinancieraMapco);
                sqlPar.AgregarParametro(ref sqlParametros, "varCapturaManual", 1, MySqlDbType.Int32, varCapturaManual);
                sqlPar.AgregarParametro(ref sqlParametros, "varIdDispositivo", 1, MySqlDbType.Int32, varIdDispositivo);
                sqlPar.AgregarParametro(ref sqlParametros, "varUsuarioInsert", 1, MySqlDbType.Int32, varUsuarioInsert);
                sqlPar.AgregarParametro(ref sqlParametros, "varFechaInsert", 1, MySqlDbType.DateTime, varFechaInsert);
                sqlPar.AgregarParametro(ref sqlParametros, "varEstatus", 1, MySqlDbType.Bit, varEstatus);
                sqlPar.AgregarParametro(ref sqlParametros, "varUsuarioUpdate", 1, MySqlDbType.Int32, varUsuarioUpdate);
                sqlPar.AgregarParametro(ref sqlParametros, "varFechaUpdate", 1, MySqlDbType.DateTime, varFechaUpdate);
                sqlPar.AgregarParametro(ref sqlParametros, "varUsuarioBaja", 1, MySqlDbType.Int32, varUsuarioBaja);
                sqlPar.AgregarParametro(ref sqlParametros, "varFechaBaja", 1, MySqlDbType.DateTime, varFechaBaja);
                ds = dtbs.RegresaDataSet("MantenimientoTipoOperacion", "TipoOperacionT", ref pvarError, "MYSQL", sqlParametros);
                resultado.Datos = ds;
                resultado.Error = false;*/

        /*
         varOpcion int, varIdTipoOperacion int, varIdBanco int, varDescripcion varchar(100), 
        varImporteMaximo double, varImporteComisionFija double, 
        varPorcentajeComision double,
        varPorcentajeProteccion double, varTipoOperacion bit, 
        varEsPromocion bit, varCompraMinima double, varMeses int,
        varKlaveKarum varchar(10), varPorcentajeComisionFinancieraMapco double,
        varCapturaManual bit, varIdDispositivo int, varUsuarioInsert int, varFechaInsert datetime,
        varEstatus bit, varUsuarioUpdate int, varFechaUpdate datetime, varUsuarioBaja int, varFechaBajadatetime datetime                 
         */
        /*}
        catch (MySqlException e)
        {
            resultado.Error = true;
            resultado.MensajeError = "[ERROR:DataBase - obtenerTipoOperacion]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
            resultado.Excepcion = e;
        }
        catch (Exception e)
        {
            resultado.Error = true;
            resultado.MensajeError = "[ERROR:Exception - obtenerTipoOperacion]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
            resultado.Excepcion = e;
        }
        return resultado;
    }*/


        /*CONSULTAS*/
        public Resultado obtenerTipoOperacion()
        {
            Resultado resultado = new Resultado();
            try
            {
                sqlParametros = new MySqlParameter[1];
                sqlPar = new ParametrosSQLMYSQL();
                DataSet ds = new DataSet();

                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "varOpcion", 0, MySqlDbType.Int32, 1);
                ds = dtbs.RegresaDataSet("GetTipoOperacion", "TipoOperacionT", ref pvarError, "MYSQL", sqlParametros);
                resultado.Datos = ds;
                resultado.Error = false;
            }
            catch (MySqlException e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:DataBase - obtenerTipoOperacion]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            catch (Exception e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:Exception - obtenerTipoOperacion]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            return resultado;
        }
    }
}
