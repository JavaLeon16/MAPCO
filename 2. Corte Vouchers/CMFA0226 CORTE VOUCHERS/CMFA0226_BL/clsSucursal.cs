using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MPO_DAL;
using MySQLDAL;

namespace CMFA0226_BL
{
    public class ClsSucursal
    {
        #region Propiedades
        //IDSUCURSAL

        private string _IdSucursal;
        public string IdSucursal
        {
            get { return _IdSucursal; }
            set { _IdSucursal = value; }
        }

        private  string _NombreSuc;
        public  string NombreSuc
        {
            get { return _NombreSuc; }
            set { _NombreSuc = value; }
        }

        private  string _IP;
        public  string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }




        #endregion

        #region Metodos Publicos

        public static List<ClsSucursal> ListSucursal()
        {
            List<ClsSucursal> SucursalList = new List<ClsSucursal>();
            DataTable Table = new DataTable();

            try
            {
                MPO_DAL.Data DataAccess = new MPO_DAL.Data(System.Configuration.ConfigurationManager.ConnectionStrings["CMFA0226.Properties.Settings.CMFA0226_Conn00"].ToString());
                //Table = DataAccess.ExecuteQuery("SELECT num, suc, ip FROM empr WHERE actrm='S' and zonub <> '' AND num <> 12 ORDER BY zonub, suc");
                Table = DataAccess.ExecuteQuery("SELECT num, suc, ip FROM empr where  ip <> '' and actexe='S' and  zonub <>'' ORDER BY suc");
                    DataAccess.CloseConnection();
                    foreach (DataRow Row in Table.Rows)
                    {
                        SucursalList.Add(FillSucursal(Row));
                    }
                    return SucursalList;
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex.InnerException); }
        }


            //DATOS DE LA SUCURSAL ACTUAL
            public static DataTable ListSucursalId(string _IdEmp)
            {
                DataTable Table = new DataTable("SUCUDIR");

                try
                {
                    MySQLDAL.Data DataAccess = new MySQLDAL.Data(System.Configuration.ConfigurationManager.ConnectionStrings["CMFA0226.Properties.Settings.CMFA0226_Conn00"].ToString());
                    //Data DataAccess = new Data(System.Configuration.ConfigurationManager.ConnectionStrings["CMDC0302.Properties.Settings.ConnString"].ToString());
                    //Table = DataAccess.ExecuteQuery("SELECT Num, Nom, Suc, Pob, Tel, RFC, Dir FROM Empr WHERE Num='" + _IdEmp + "' ");
                    Table = DataAccess.ExecuteQuery("SELECT Num, Nom, Suc, Pob, Tel, RFC, Dir FROM empresa WHERE Num='" + _IdEmp + "' ");
                    DataAccess.CloseConnection();

                    return Table;
                }
                catch (Exception Ex) { throw new Exception(Ex.Message, Ex.InnerException); }
            }

        #endregion

        #region Metodos Privados

        private static ClsSucursal FillSucursal(DataRow Row)
        {
            ClsSucursal Sucursal = new ClsSucursal();
            try
            {
                Sucursal.IdSucursal = Convert.ToString(Row["num"]);
                Sucursal.NombreSuc = Convert.ToString(Row["suc"]).Trim();
                Sucursal.IP = Convert.ToString(Row["ip"]).Trim();

                return Sucursal;
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex.InnerException); }
        }

        #endregion
    }
}