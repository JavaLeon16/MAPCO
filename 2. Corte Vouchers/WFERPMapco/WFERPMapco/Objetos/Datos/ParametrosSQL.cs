using System;
using System.Data;
using System.Data.SqlClient;

namespace SysERPMapco
{
    public class ParametrosSQL
    {

        DATABASESQL dtbs = new DATABASESQL();
        DataSet DtsDatos = new DataSet();
        /* Último cambio añadido, por si truena algo:
         * Cada método puede recibir nulos, en el campo p_Valor, para poder ingresar un DBNull.Value
         25/10/2019 | Karen.
         */



        #region "Metodos De la Clase"

        // Agrega parametro de tipo uniqueidentifier

        public void AgregarParametro(ref SqlParameter[] p_Parametro, string p_NombreParamentro, int p_iPosicion, SqlDbType p_TipoDato, Guid pValor)
        {
            p_Parametro[p_iPosicion] = new SqlParameter();
            p_Parametro[p_iPosicion].ParameterName = p_NombreParamentro;
            p_Parametro[p_iPosicion].SqlDbType = p_TipoDato;
            p_Parametro[p_iPosicion].Direction = ParameterDirection.Input;
            p_Parametro[p_iPosicion].Value = pValor;
        }
        // Agrega parametro de tipo double

        public void AgregarParametro(ref SqlParameter[] p_Parametro, string p_NombreParamentro, int p_iPosicion, SqlDbType p_TipoDato, DataTable Table)
        {
            p_Parametro[p_iPosicion] = new SqlParameter();
            p_Parametro[p_iPosicion].ParameterName = p_NombreParamentro;
            p_Parametro[p_iPosicion].SqlDbType = p_TipoDato;
            p_Parametro[p_iPosicion].Direction = ParameterDirection.Input;
            p_Parametro[p_iPosicion].Value = Table;
        }

        //AGREGA PARAMETRO TIPO VARBINARY
        public void AgregarParametro(ref SqlParameter[] p_Parametro, string p_NombreParamentro, int p_iPosicion, SqlDbType p_TipoDato, byte[] pValor)
        {
            p_Parametro[p_iPosicion] = new SqlParameter();
            p_Parametro[p_iPosicion].ParameterName = p_NombreParamentro;
            p_Parametro[p_iPosicion].SqlDbType = p_TipoDato;
            p_Parametro[p_iPosicion].Direction = ParameterDirection.Input;
            p_Parametro[p_iPosicion].Value = pValor;
        }

        // Agrega parametro de tipo Entero
        public void AgregarParametro(ref SqlParameter[] p_Parametro, string p_NombreParamentro, int p_iPosicion, SqlDbType p_TipoDato, int? p_Valor)
        {
            p_Parametro[p_iPosicion] = new SqlParameter();
            p_Parametro[p_iPosicion].ParameterName = p_NombreParamentro;
            p_Parametro[p_iPosicion].SqlDbType = p_TipoDato;
            p_Parametro[p_iPosicion].Direction = ParameterDirection.Input;
            p_Parametro[p_iPosicion].Value = p_Valor;
            if (p_Valor == null)
            {
                p_Parametro[p_iPosicion].Value = DBNull.Value;
            }
            else
            {
                p_Parametro[p_iPosicion].Value = p_Valor;
            }
        }

        // Agrega parametro de tipo double

        public void AgregarParametro(ref SqlParameter[] p_Parametro, string p_NombreParamentro, int p_iPosicion, SqlDbType p_TipoDato, double? p_Valor)
        {
            p_Parametro[p_iPosicion] = new SqlParameter();
            p_Parametro[p_iPosicion].ParameterName = p_NombreParamentro;
            p_Parametro[p_iPosicion].SqlDbType = p_TipoDato;
            p_Parametro[p_iPosicion].Direction = ParameterDirection.Input;
            if (p_Valor == null)
            {
                p_Parametro[p_iPosicion].Value = DBNull.Value;
            }
            else
            {
                p_Parametro[p_iPosicion].Value = p_Valor;
            }
        }

        public void AgregarParametro(ref SqlParameter[] p_Parametro, string p_NombreParamentro, int p_iPosicion, SqlDbType p_TipoDato, decimal? p_Valor)
        {
            p_Parametro[p_iPosicion] = new SqlParameter();
            p_Parametro[p_iPosicion].ParameterName = p_NombreParamentro;
            p_Parametro[p_iPosicion].SqlDbType = p_TipoDato;
            p_Parametro[p_iPosicion].Direction = ParameterDirection.Input;
            if (p_Valor == null)
            {
                p_Parametro[p_iPosicion].Value = DBNull.Value;
            }
            else
            {
                p_Parametro[p_iPosicion].Value = p_Valor;
            }
        }

        // Agrega parametro de tipo boleano

        public void AgregarParametro(ref SqlParameter[] p_Parametro, string p_NombreParamentro, int p_iPosicion, SqlDbType p_TipoDato, bool? p_Valor)
        {
            p_Parametro[p_iPosicion] = new SqlParameter();
            p_Parametro[p_iPosicion].ParameterName = p_NombreParamentro;
            p_Parametro[p_iPosicion].SqlDbType = p_TipoDato;
            p_Parametro[p_iPosicion].Direction = ParameterDirection.Input;
            if (p_Valor == null)
            {
                p_Parametro[p_iPosicion].Value = DBNull.Value;
            }
            else
            {
                p_Parametro[p_iPosicion].Value = p_Valor;
            }
        }


        public void AgregarParametroBit(ref SqlParameter[] p_Parametro, string p_NombreParamentro, int p_iPosicion, SqlDbType p_TipoDato, bool p_Valor)
        {
            p_Parametro[p_iPosicion] = new SqlParameter();
            p_Parametro[p_iPosicion].ParameterName = p_NombreParamentro;
            p_Parametro[p_iPosicion].SqlDbType = p_TipoDato;
            p_Parametro[p_iPosicion].Direction = ParameterDirection.Output;
            p_Parametro[p_iPosicion].Value = p_Valor;
        }



        // Agrega parametro de tipo fecha
        public void AgregarParametro(ref SqlParameter[] p_Parametro, string p_NombreParamentro, int p_iPosicion, SqlDbType p_TipoDato, DateTime ? p_Valor)
        {
            p_Parametro[p_iPosicion] = new SqlParameter();
            p_Parametro[p_iPosicion].ParameterName = p_NombreParamentro;
            p_Parametro[p_iPosicion].SqlDbType = p_TipoDato;
            p_Parametro[p_iPosicion].Direction = ParameterDirection.Input;
            if (p_Valor == null)
            {
                p_Parametro[p_iPosicion].Value = DBNull.Value;
            }
            else
            {
                p_Parametro[p_iPosicion].Value = p_Valor;
            }
        }

        public void AgregarParametro(ref SqlParameter[] p_Parametro, string p_NombreParamentro, int p_iPosicion, SqlDbType p_TipoDato, int p_sSizeVarchar, string p_Valor)
        {
            p_Parametro[p_iPosicion] = new SqlParameter();
            p_Parametro[p_iPosicion].ParameterName = p_NombreParamentro;
            p_Parametro[p_iPosicion].SqlDbType = p_TipoDato;
            p_Parametro[p_iPosicion].Size = p_sSizeVarchar;
            p_Parametro[p_iPosicion].Direction = ParameterDirection.Input;
            if (p_Valor == null)
            {
                p_Parametro[p_iPosicion].Value = DBNull.Value;
            }
            else
            {
                p_Parametro[p_iPosicion].Value = p_Valor;
            }
        }


        public void EjecutaSP(SqlParameter[] p_Parametro, string p_NombreSP, ref string p_StrError)
        {
            try
            {
                dtbs.EjecutaSqlSP(p_NombreSP, ref p_StrError, p_Parametro);
            }
            catch (System.OverflowException Err)
            {
                p_StrError = Err.Message;
            }
        }

        public DataSet RegresaDataset(SqlParameter[] p_Parametro, string p_NombreSP, string p_NombreTabla, ref string p_StrError)
        {
            try
            {

                DtsDatos = dtbs.RegresaDataSet(p_NombreSP, p_NombreTabla, ref p_StrError, p_Parametro);
            }
            catch (System.OverflowException Err)
            {
                p_StrError = Err.Message;
            }
            return DtsDatos;
        }
        public DataSet RegresaDataset(string p_SQLQuery, string p_NombreTabla, ref string p_StrError)
        {
            try
            {
                dtbs.RegresaDataSet(ref DtsDatos, p_SQLQuery, p_NombreTabla, ref p_StrError);
            }
            catch (System.OverflowException Err)
            {
                p_StrError = Err.Message;
            }
            return DtsDatos;
        }

        #endregion
    }
}