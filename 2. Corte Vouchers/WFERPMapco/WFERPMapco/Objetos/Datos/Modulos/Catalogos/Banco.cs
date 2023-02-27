using MySql.Data.MySqlClient;
using System;
using System.Data;
using WFERPMapco.Objetos.Utilerias;

namespace WFERPMapco.Objetos.Datos.Modulos.Catalogos
{
    public class Banco
    {
        ParametrosSQLMYSQL sqlPar = new ParametrosSQLMYSQL();
        DATABASEMYSQL dtbs = new DATABASEMYSQL();
        MySqlParameter[] sqlParametros;
        string pvarError;


        /*CONSULTAS*/
        public Resultado obtenerBancos(string NombreBanco = "")
        {
            Resultado resultado = new Resultado();
            try
            {
                sqlParametros = new MySqlParameter[2];
                sqlPar = new ParametrosSQLMYSQL();
                DataSet ds = new DataSet();

                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "VAROpcion", 0, MySqlDbType.Int32, 1);
                sqlPar.AgregarParametro(ref sqlParametros, "VARNomBanco", 1, MySqlDbType.VarChar, 50, NombreBanco.Trim());
                ds = dtbs.RegresaDataSet("GetBancos", "BancoT", ref pvarError, "MYSQL", sqlParametros);
                resultado.Datos = ds;
                resultado.Error = false;
            }
            catch (MySqlException e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:DataBase - obtenerBanco]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            catch (Exception e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:Exception - obtenerBanco]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            return resultado;
        }

        /*ACCIONES*/
        public Resultado accionBanco(
            int Opcion, int IdBanco, int IdBancoContable, string NomBanco, bool UsaTerminal, 
            int Orden, bool Mapco, decimal ComisionBancaria, bool CapturaManual, int Usuario
        )
        {
            Resultado resultado = new Resultado();
            try
            {
                sqlParametros = new MySqlParameter[10];
                sqlPar = new ParametrosSQLMYSQL();
                DataSet ds = new DataSet();

                //Se agregan los parametros necesarios
                sqlPar.AgregarParametro(ref sqlParametros, "VAROpcion", 0, MySqlDbType.Int32, Opcion); // (Opcion) 1=Registrar, 2=Actualizar, 3=Eliminar
                sqlPar.AgregarParametro(ref sqlParametros, "VARIdBanco", 1, MySqlDbType.Int32, IdBanco);
                sqlPar.AgregarParametro(ref sqlParametros, "VARIdBancoContable", 2, MySqlDbType.Int32, IdBancoContable);
                sqlPar.AgregarParametro(ref sqlParametros, "VARNomBanco", 3, MySqlDbType.VarChar, 50, NomBanco.Trim());
                sqlPar.AgregarParametro(ref sqlParametros, "VARUsaTerminal", 4, MySqlDbType.Bit, UsaTerminal);
                sqlPar.AgregarParametro(ref sqlParametros, "VAROrden", 5, MySqlDbType.Int32, Orden);
                sqlPar.AgregarParametro(ref sqlParametros, "VARMapco", 6, MySqlDbType.Bit, Mapco);
                sqlPar.AgregarParametro(ref sqlParametros, "VARComisionBancaria", 7, MySqlDbType.Decimal, ComisionBancaria);
                sqlPar.AgregarParametro(ref sqlParametros, "VARCapturaManual", 8, MySqlDbType.Bit, CapturaManual);
                sqlPar.AgregarParametro(ref sqlParametros, "VARUsuario", 9, MySqlDbType.Int32, Usuario);
                ds = dtbs.RegresaDataSet("ModBancos", "BancoT", ref pvarError, "MYSQL", sqlParametros);
                
                resultado.Datos = ds;
                resultado.Error = false;
            }
            catch (MySqlException e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:DataBase - " + (Opcion == 1 ? "registrar" : Opcion == 2 ? "actualizar" : "eliminar") + "Banco]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            catch (Exception e)
            {
                resultado.Error = true;
                resultado.MensajeError = "[ERROR:Exception - " + (Opcion == 1 ? "registrar" : Opcion == 2 ? "actualizar" : "eliminar") + "Banco]= " + e.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
                resultado.Excepcion = e;
            }
            return resultado;
        }
    }
}
