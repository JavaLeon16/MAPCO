using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SysERPMapco
{
    public class DATABASESQL
    {
        /* ACTUALIZACIÓN: 24/10/2019 | KAREN
         * Se creó el método CadenaConexion para poder añadir otra base de datos cuando se especifique.
         * Se creó el metodo RegresaDataSet con el parámetro NombreConexion, cuando el método trae ese parámetro, ingresa a ese método. 
         */

        #region CadenaConexion
        //string cad = "Data Source=172.16.15.45;Initial Catalog=dbChecador;User ID=sa;Password=Ciipd3t3c.SqlAdmin-Pa$$!";
        //string cad = "Data Source=ADMONNNN-PC;Initial Catalog=ENTREGAS;User ID=sa;Password=desarrollo2008";
        //string cad = "Data Source=172.16.2.127;Initial Catalog=ENTREGAS;User ID=sa;Password=desarrollo2008";
        //string cad = System.Configuration.ConfigurationManager.ConnectionStrings["Encuestas"].ConnectionString;
        //string cad = ConfigurationManager.ConnectionStrings["SelloCasaConnection"].ConnectionString;
        string cad = string.Empty;
        public string CadenaConexion(string NombreConexion)
        {
            cad = ConfigurationManager.ConnectionStrings[string.IsNullOrEmpty(NombreConexion) ? "SelloCasaConnection" : NombreConexion].ConnectionString;
            return cad;
        }

        #endregion

        #region AddParameters
        public void AddParameters(ref SqlCommand COM, SqlParameter[] PARS)
        {
            COM.Parameters.Clear();
            for (int i = 0; i < PARS.Length; i++)
            {
                COM.Parameters.Add(PARS[i]);
            }
        }
        #endregion

        #region Objetos de Datos
        public SqlParameter[] PAR;
        public SqlConnection CON = new SqlConnection();

        public SqlDataReader REG1;
        public SqlDataReader REG2;

        public SqlDataAdapter DA = new SqlDataAdapter();

        public SqlCommand COM1 = new SqlCommand();
        public SqlCommand COM2 = new SqlCommand();

        public SqlTransaction TRAN1;
        public SqlTransaction TRAN2;

        public DataSet DS1;
        public DataSet DS2;

        public bool ERRORCONEXION = false;
        #endregion

        #region EjecutarSqlSP
        public int EjecutaSqlSP(string parvarstrNombreSqlSP, ref string pvarStrMensajeError, params SqlParameter[] parArrayParametrosSP)
        {
            int pCant = parArrayParametrosSP.Length;
            SqlConnection CON = new SqlConnection();
            SqlCommand COM1 = new SqlCommand();


            CON.ConnectionString = CadenaConexion(null);
            try
            {
                CON.Open();
                COM1.Connection = CON;
            }
            catch
            {
                ERRORCONEXION = true;
            }

            COM1.CommandText = parvarstrNombreSqlSP;
            COM1.CommandTimeout = 1200;
            COM1.CommandType = CommandType.StoredProcedure;
            COM1.Parameters.AddRange(parArrayParametrosSP);


            COM1.Connection = CON;

            return COM1.ExecuteNonQuery();
        }
        
        public int EjecutaSqlSP(string parvarstrNombreSqlSP, ref string pvarStrMensajeError, string NombreConexion ,params SqlParameter[] parArrayParametrosSP)
        {
            int pCant = parArrayParametrosSP.Length;
            SqlConnection CON = new SqlConnection();
            SqlCommand COM1 = new SqlCommand();


            CON.ConnectionString = CadenaConexion(NombreConexion);
            try
            {
                CON.Open();
                COM1.Connection = CON;
            }
            catch
            {
                ERRORCONEXION = true;
            }

            COM1.CommandText = parvarstrNombreSqlSP;
            COM1.CommandTimeout = 1200;
            COM1.CommandType = CommandType.StoredProcedure;
            COM1.Parameters.AddRange(parArrayParametrosSP);


            COM1.Connection = CON;

            return COM1.ExecuteNonQuery();
        }

        #endregion

        #region RegresaDataSet
        public void RegresaDataSet(ref DataSet ds, string parvarStrQuerySQL, string parvarStrNombreTabla, ref string pvarStrMensajeError)
        {

            SqlConnection CON = new SqlConnection();
            SqlCommand COM1 = new SqlCommand();
            DataSet RESULTADO = new DataSet();
            SqlDataAdapter dta = new SqlDataAdapter();

    
            CON.ConnectionString = CadenaConexion(null);
            try
            {
                CON.Open();
                COM1.CommandTimeout = 1200;
                COM1.Connection = CON;
            }
            catch
            {
                ERRORCONEXION = true;
            }

            dta = new SqlDataAdapter(parvarStrQuerySQL, CON);

            dta.Fill(RESULTADO, parvarStrNombreTabla);

            CON.Close();
            CON.Dispose();

            ds = RESULTADO;
        }
        #endregion

        #region RegresaDataSet
        public DataSet RegresaDataSet(string parvarStrNombreSqlSP, string parvarStrNombreTabla, ref string pvarStrMensajeError, params SqlParameter[] parArrayParametrosSP)
        {
            int pCant = parArrayParametrosSP.Length;
            SqlConnection CON = new SqlConnection();
            SqlCommand COM1 = new SqlCommand();
            DataSet RESULTADO = new DataSet();
            SqlDataAdapter dta = new SqlDataAdapter();

            CON.ConnectionString = CadenaConexion(null);
            try
            {
                CON.Open();
                COM1.Connection = CON;
            }
            catch (Exception e)
            {
                ERRORCONEXION = true;
            }


            COM1.CommandText = parvarStrNombreSqlSP;
            COM1.CommandTimeout = 1200;
            COM1.CommandType = CommandType.StoredProcedure;

            COM1.Parameters.AddRange(parArrayParametrosSP);


            try
            {
                dta.SelectCommand = COM1;
            }
            catch (Exception E)
            {

            }

            dta.Fill(RESULTADO, parvarStrNombreTabla);

            CON.Close();
            CON.Dispose();

            return RESULTADO;

        }
        #endregion

        #region RegresaDataSet - Específico BDD
        public DataSet RegresaDataSet(string parvarStrNombreSqlSP, string parvarStrNombreTabla, ref string pvarStrMensajeError, string NombreConexion, params SqlParameter[] parArrayParametrosSP)
        {
            int pCant = parArrayParametrosSP.Length;
            SqlConnection CON = new SqlConnection();
            SqlCommand COM1 = new SqlCommand();
            DataSet RESULTADO = new DataSet();
            SqlDataAdapter dta = new SqlDataAdapter();

            CON.ConnectionString = CadenaConexion(NombreConexion);
            try
            {
                CON.Open();
                COM1.Connection = CON;
            }
            catch (Exception e)
            {
                ERRORCONEXION = true;
            }


            COM1.CommandText = parvarStrNombreSqlSP;
            COM1.CommandTimeout = 1200;
            COM1.CommandType = CommandType.StoredProcedure;

            COM1.Parameters.AddRange(parArrayParametrosSP);


            try
            {
                dta.SelectCommand = COM1;
               
            }
            catch (Exception E)
            {

            }

            dta.Fill(RESULTADO, parvarStrNombreTabla);

            CON.Close();
            CON.Dispose();

            return RESULTADO;

        }
        #endregion

        #region InitParameters
        public void InitParameters(int COUNT)
        {
            PAR = new SqlParameter[COUNT];
            for (int i = 0; i < PAR.Length; i++)
            {
                PAR[i] = new SqlParameter();
            }
        }
        #endregion

        #region Constructor
        public DATABASESQL()
        {

        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            COM1.Connection.Close();
            COM2.Connection.Close();
            if (REG1 != null)
            {
                if (!REG1.IsClosed)
                {
                    REG1.Close();
                }
            }
            if (REG2 != null)
            {
                if (!REG2.IsClosed)
                {
                    REG2.Close();
                }
            }
            CON.Close();
        }
        #endregion
    }
}
