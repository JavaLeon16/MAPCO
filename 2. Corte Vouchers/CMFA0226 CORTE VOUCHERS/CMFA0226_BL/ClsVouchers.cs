using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySQLDAL;
using MySql.Data;

namespace CMFA0226_BL
{
    public class ClsVouchers
    {
        #region Propiedades

        //Propiedades Combo Cajas
        private int _Numcaja;
        public int Numcaja
        {
            get { return _Numcaja; }
            set { _Numcaja = value; }
        }

        private string _DescripcionCaja;
        public string DescripcionCaja
        {
            get { return _DescripcionCaja; }
            set { _DescripcionCaja = value; }
        }
        #endregion
        public static string cadenaConexion = "";
        #region Metodos Publicos
        public static DataTable EncabezadoVoucher(DateTime FechaIni,int idcaja)
        {
            DataTable Table = new DataTable();
            try
            {
                MySQLDAL.Data DataAccess = new MySQLDAL.Data(cadenaConexion);
                string Query = "";
                Query = " select " +
                          " * "+ 
                          " from (select"+
                            " C1.Descripcion,"+
                            " c1.tipo,"+
                            " ifnull(m.importe,0) importe,"+
                            " ifnull(m.fecha, '" + FechaIni.ToString("yyy-MM-dd") +"') fecha,"+
                            " concat('CAJA: ',ifnull(m.idcaja," + idcaja + " ))idcaja,"+
                            " ifnull(m.caja,'0')caja,"+
                            " ifnull(m.CStatus,0) CStatus,"+
                            " ifnull(m.agrupador,0) agrupador,"+
                            " c1.orden"+
                     " from cortevoucherorden c1"+
                    " left join ("+
                    " SELECT  tipooperacion,agrupador, sum(importe) as importe,fecha, idcaja,caja,statusDetalle,count(statusDetalle) CStatus"+ 
                    " FROM (select concat(vd.tmref,'--',tmv.des) as Movimiento,"+
                    " case when op.descripcion='AMERICAN EXPRESS'  then 'AMERICAN EXPRESS'"+
                    " when op.tipooperacion = 1 then 'CREDITO' when op.tipooperacion = 2  then 'DEBITO' END AS TIPOOPERACION, EsPromocion IdEsPromocion, if(op.espromocion=0, 'SIN PROMOCION','PROMOCION') ESPROMOCION,"+ 
                    " case when op.descripcion='AMERICAN EXPRESS'"+ 
                    " then 0 else op.tipooperacion end as agrupador,ifnull(V.IMPORTE,0) as importe,v.fecha as fecha, c.idcaja, caja, if(V.status=1,'VENTA', 'CANCELACION') Status, if(Vd.status=1,'VENTA', 'CANCELACION') StatusDetalle"+
                    " from voucher V"+
                    " inner join voucherdetalle VD  on VD.idvoucher=V.idvoucher inner join tmov tmv on tmv.tm=vd.tmref"+ 
                    " inner join banco b on v.idbanco=b.idbanco"+
                    //" inner join operaciontarjeta op on op.idoperaciontarjeta=V.IdOperacionTarjeta and op.status=1" + 
                    " inner join operaciontarjeta op on op.idoperaciontarjeta=V.IdOperacionTarjeta "+ 
                    " inner join caja c on v.idcaja= c.idcaja"+
                    " where  v.idcaja=" + idcaja + " and Vd.status <>2 and left(V.fecha,10)='" + FechaIni.ToString("yyy-MM-dd") + "') AS K" +
                    " group by  agrupador,statusdetalle) as M on M.tipooperacion=c1.descripcion and  M.StatusDetalle=c1.tipo"+
                    " union all"+
                    " select"+ 
                    " 'Total' AS descripcion,"+
                    " c1.tipo,"+
                    " ifnull(sum(m.importe),0) as importe,'"+
                     FechaIni.ToString("yyy-MM-dd") + "' as fecha,"+
                     idcaja + " as idcaja,"+ idcaja + " as caja, " +
                    " 0 as CStatus,"+
                    " 3 as agrupador,"+
                    " 100 as orden"+
                    " from cortevoucherorden c1"+
            " left join ("+
            " SELECT  tipooperacion,agrupador, ifnull(sum(importe),0) as importe,fecha, idcaja,caja,statusDetalle,count(statusDetalle) CStatus"+ 
            " FROM (select concat(vd.tmref,'--',tmv.des) as Movimiento,"+ 
            " case when op.descripcion='AMERICAN EXPRESS'  then 'AMERICAN EXPRESS'"+ 
            " when op.tipooperacion = 1 then 'CREDITO' when op.tipooperacion = 2  then 'DEBITO' END AS TIPOOPERACION, EsPromocion IdEsPromocion, if(op.espromocion=0, 'SIN PROMOCION','PROMOCION') ESPROMOCION,"+ 
            " case when op.descripcion='AMERICAN EXPRESS'"+  
            " then 0 else op.tipooperacion end as agrupador, ifnull(V.IMPORTE,0) as importe,v.fecha as fecha, c.idcaja, caja, if(V.status=1,'VENTA', 'CANCELACION') Status, if(Vd.status=1,'VENTA', 'CANCELACION') StatusDetalle"+
            " from voucher  V"+
            " inner join voucherdetalle VD  on VD.idvoucher=V.idvoucher inner join tmov tmv on tmv.tm=vd.tmref"+
            " inner join banco b on v.idbanco=b.idbanco"+ 
            " inner join operaciontarjeta op on op.idoperaciontarjeta=V.IdOperacionTarjeta"+
            " inner join caja c on v.idcaja= c.idcaja"+
            " where  v.idcaja=" + idcaja + " and Vd.status <>2 and left(V.fecha,10)='" + FechaIni.ToString("yyy-MM-dd") + "') AS K" +
            " group by  agrupador,statusdetalle) as M on M.tipooperacion=c1.descripcion and  M.StatusDetalle=c1.tipo"+
            " group by c1.tipo"+
            " ) as j"+
            " order by orden,tipo desc ";
                Table = DataAccess.ExecuteQuery(Query);
                DataAccess.CloseConnection();
                return Table;
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex.InnerException); }
        }

        public static DataTable VouchersDetalle(DateTime FechaIni, int idcaja)//
        {
            DataTable Table = new DataTable();
            try
            {
                MySQLDAL.Data DataAccess = new MySQLDAL.Data(cadenaConexion);
                string Query = "";
                Query = "select concat(vd.tmref,'--',tmv.des) as Movimiento," +
                                " V.numeroautorizacion,FECHA," +
                                " op.Descripcion as OperacionTarjeta," +
                                " EsPromocion IdEsPromocion," +
                                " if(op.espromocion=0, 'SIN PROMOCION','PROMOCION') ESPROMOCION," +
                                " v.NumeroTarjeta," +
                                " v.importe," +
                                " b.Banco," +
                                " vd.tmref, " +
                                " vd.folref," +
                                " vd.FecRef, " +
                                " c.idcaja," +
                                " caja," +
                    " if(V.status=1,'VENTA', 'CNCL.' ) Status," +
                    " if(Vd.status=1,'VENTA', 'CNCL.') StatusDetalle" +
                        " from voucher  V" +
                        " inner join voucherdetalle VD  on VD.idvoucher=V.idvoucher" +
                        " inner join tmov tmv on tmv.tm=vd.tmref" +
                        " inner join banco b on v.idbanco=b.idbanco" +
                        " inner join operaciontarjeta op on op.idoperaciontarjeta=V.IdOperacionTarjeta" +
                        " inner join caja c on v.idcaja= c.idcaja" +
                        " where  v.idcaja=" + idcaja + " and left(V.fecha,10) = '" + FechaIni.ToString("yyy-MM-dd") + "'" +
                        " and Vd.status <> 2 order by EsPromocion,statusdetalle desc";
                Table = DataAccess.ExecuteQuery(Query);
                DataAccess.CloseConnection();
                return Table;
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex.InnerException); }
        }


        public static DataTable EncabezadoVoucherN(DateTime FechaIni, int idcaja)
        {
            DataTable Table = new DataTable();
            try
            {
                MySQLDAL.Data DataAccess = new MySQLDAL.Data(cadenaConexion);
                string Query = "";
                Query = " select " +
                          " * " +
                          " from (select" +
                            " C1.Descripcion," +
                            " c1.tipo," +
                            " ifnull(m.importe,0) importe," +
                            " ifnull(m.fecha, '" + FechaIni.ToString("yyy-MM-dd") + "') fecha," +
                            " concat('CAJA: ',ifnull(m.idcaja," + idcaja + " ))idcaja," +
                            " ifnull(m.caja,'0')caja," +
                            " ifnull(m.CStatus,0) CStatus," +
                            " ifnull(m.agrupador,0) agrupador," +
                            " c1.orden" +
                     " from cortevoucherorden c1" +
                    " left join (" +
                    " SELECT  tipooperacion,agrupador, sum(importe) as importe,fecha, idcaja,caja,statusDetalle,count(statusDetalle) CStatus" +
                    " FROM (select 0 as Movimiento," +
                    " case when op.descripcion='AMERICAN EXPRESS'  then 'AMERICAN EXPRESS'" +
                    " when op.tipooperacion = 1 then 'CREDITO' when op.tipooperacion = 2  then 'DEBITO' END AS TIPOOPERACION, EsPromocion IdEsPromocion, if(op.espromocion=0, 'SIN PROMOCION','PROMOCION') ESPROMOCION," +
                    " case when op.descripcion='AMERICAN EXPRESS'" +
                    " then 0 else op.tipooperacion end as agrupador,ifnull(V.IMPORTE,0) as importe,v.fecha as fecha, c.idcaja, caja, if(V.status=1,'VENTA', 'CANCELACION') Status, if(V.status=1,'VENTA', 'CANCELACION') StatusDetalle" +
                    " from voucher V" +
                    " inner join banco b on v.idbanco=b.idbanco" +
                    //" inner join operaciontarjeta op on op.idoperaciontarjeta=V.IdOperacionTarjeta and op.status=1" +
                    " inner join operaciontarjeta op on op.idoperaciontarjeta=V.IdOperacionTarjeta " +
                    " inner join caja c on v.idcaja= c.idcaja" +
                    " where  v.idcaja=" + idcaja + " and V.status <>2 and left(V.fecha,10)='" + FechaIni.ToString("yyy-MM-dd") + "') AS K" +
                    " group by  agrupador,statusdetalle) as M on M.tipooperacion=c1.descripcion and  M.StatusDetalle=c1.tipo" +
                    " union all" +
                    " select" +
                    " 'Total' AS descripcion," +
                    " c1.tipo," +
                    " ifnull(sum(m.importe),0) as importe,'" +
                     FechaIni.ToString("yyy-MM-dd") + "' as fecha," +
                     idcaja + " as idcaja," + idcaja + " as caja, " +
                    " 0 as CStatus," +
                    " 3 as agrupador," +
                    " 100 as orden" +
                    " from cortevoucherorden c1" +
            " left join (" +
            " SELECT  tipooperacion,agrupador, ifnull(sum(importe),0) as importe,fecha, idcaja,caja,statusDetalle,count(statusDetalle) CStatus" +
            " FROM (select 0 as Movimiento," +
            " case when op.descripcion='AMERICAN EXPRESS'  then 'AMERICAN EXPRESS'" +
            " when op.tipooperacion = 1 then 'CREDITO' when op.tipooperacion = 2  then 'DEBITO' END AS TIPOOPERACION, EsPromocion IdEsPromocion, if(op.espromocion=0, 'SIN PROMOCION','PROMOCION') ESPROMOCION," +
            " case when op.descripcion='AMERICAN EXPRESS'" +
            " then 0 else op.tipooperacion end as agrupador, ifnull(V.IMPORTE,0) as importe,v.fecha as fecha, c.idcaja, caja, if(V.status=1,'VENTA', 'CANCELACION') Status, if(V.status=1,'VENTA', 'CANCELACION') StatusDetalle" +
            " from voucher  V" +
            " inner join banco b on v.idbanco=b.idbanco" +
            " inner join operaciontarjeta op on op.idoperaciontarjeta=V.IdOperacionTarjeta " +
            " inner join caja c on v.idcaja= c.idcaja" +
            " where  v.idcaja=" + idcaja + " and V.status <>2 and left(V.fecha,10)='" + FechaIni.ToString("yyy-MM-dd") + "') AS K" +
            " group by  agrupador,statusdetalle) as M on M.tipooperacion=c1.descripcion and  M.StatusDetalle=c1.tipo" +
            " group by c1.tipo" +
            " ) as j" +
            " order by orden,tipo desc ";
                Table = DataAccess.ExecuteQuery(Query);
                DataAccess.CloseConnection();
                return Table;
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex.InnerException); }
        }

        public static DataTable VouchersDetalleN(DateTime FechaIni, int idcaja)//
        {
            DataTable Table = new DataTable();
            try
            {
                MySQLDAL.Data DataAccess = new MySQLDAL.Data(cadenaConexion);
                string Query = "";
                Query = "select 0 as Movimiento," +
                                " V.numeroautorizacion,FECHA," +
                                " op.Descripcion as OperacionTarjeta," +
                                " EsPromocion IdEsPromocion," +
                                " if(op.espromocion=0, 'SIN PROMOCION','PROMOCION') ESPROMOCION," +
                                " v.NumeroTarjeta," +
                                " v.importe," +
                                " b.Banco," +
                                " c.idcaja," +
                                " caja," +
                    " if(V.status=1,'VENTA', 'CNCL.' ) Status," +
                    " if(V.status=1,'VENTA', 'CNCL.') StatusDetalle" +
                        " from voucher  V" +
                        " inner join banco b on v.idbanco=b.idbanco" +
                        " inner join operaciontarjeta op on op.idoperaciontarjeta=V.IdOperacionTarjeta" +
                        " inner join caja c on v.idcaja= c.idcaja" +
                        " where  v.idcaja=" + idcaja + " and left(V.fecha,10) = '" + FechaIni.ToString("yyy-MM-dd") + "'" +
                        " and V.status <> 2 order by EsPromocion,statusdetalle desc";
                Table = DataAccess.ExecuteQuery(Query);
                DataAccess.CloseConnection();
                return Table;
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex.InnerException); }
        }

        public static DataTable impresora(string caja)
        {
            DataTable Table = new DataTable();
            try
            {
                MySQLDAL.Data DataAccess = new MySQLDAL.Data(cadenaConexion);
                Table = DataAccess.ExecuteQuery("select Caja,RutaImpresion  from caja where idcaja=" + caja + "");
                DataAccess.CloseConnection();

                return Table;
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex.InnerException); }
        }
        public static DataTable empresa(string numemp)
        {
            DataTable Table = new DataTable();
            try
            {
                MySQLDAL.Data DataAccess = new MySQLDAL.Data(cadenaConexion);
                Table = DataAccess.ExecuteQuery("select  nom,suc,concat(dir,',','C.P.',pos,',',pob) as Direccion,concat('Telefono',':',tel) as tel,concat('R.F.C.',rfc) AS rfc  from empr where Num='" + numemp + "'");
                DataAccess.CloseConnection();

                return Table;
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex.InnerException); }
        }

        public static List<ClsVouchers> ListTiposMov()
        {
            List<ClsVouchers> TiposMov = new List<ClsVouchers>();
            DataTable Table = new DataTable();

            try
            {
                MySQLDAL.Data DataAccess = new MySQLDAL.Data(cadenaConexion);
                Table = DataAccess.ExecuteQuery("select idcaja,Caja from caja where status=1 order by idcaja");
                DataAccess.CloseConnection();
                foreach (DataRow Row in Table.Rows)
                {
                    TiposMov.Add(FillCajas(Row));
                }
                return TiposMov;
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex.InnerException); }
        }

        public static DataTable VersionExe()
        {
            try
            {
                DataTable Datos = new DataTable();
                MySQLDAL.Data DataAccess = new MySQLDAL.Data(cadenaConexion);
                Datos = DataAccess.ExecuteQuery("select * from revi where exe='CMFA0406'");
                DataAccess.CloseConnection();
                return Datos;
            }
            catch (Exception Ex) { throw new Exception("Configuracion Actualiza Exe --" + Ex.Message, Ex.InnerException); }
        }

        public static DataTable RutaExe()
        {
            try
            {
                DataTable Datos = new DataTable();
                MySQLDAL.Data DataAccess = new MySQLDAL.Data(cadenaConexion);
                Datos = DataAccess.ExecuteQuery("select * from config where ide='Rutaexes'");
                DataAccess.CloseConnection();
                return Datos;
            }
            catch (Exception Ex) { throw new Exception("Configuracion Actualiza Exe --" + Ex.Message, Ex.InnerException); }
        }
        #endregion
        #region MetodosPrivados
        private static ClsVouchers FillCajas(DataRow Row)
        {
            ClsVouchers Cajas = new ClsVouchers();
            try
            {
                Cajas.Numcaja = Convert.ToInt32(Row["idcaja"]);
                Cajas.DescripcionCaja = Convert.ToString(Row["Caja"]).Trim();
                return Cajas;
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex.InnerException); }
        }
        #endregion
    }
}
