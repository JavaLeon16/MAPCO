using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFERPMapco.Formas.CorteDeVoucher;
using WFERPMapco.Objetos.Datos;
using WFERPMapco.Objetos.Utilerias;

namespace WFERPMapco.Formas.CorteDeVoucher
{
    public partial class CorteDeVouchersRpt : Form
    {
        DATABASEMYSQL dATABASEMYSQL = new DATABASEMYSQL();
        MySqlParameter[] p;
        DataSet _ds;
        CorteDeVoucherParametros _Filtros;

        int pAccion = 0;
        string pvarError;
        string pClaveEmpresa = null;


        public CorteDeVouchersRpt(DataSet ds, CorteDeVoucherParametros filtros)
        {
            _ds = ds;
            _Filtros = filtros;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CorteDeVouchersRpt_Load(object sender, EventArgs e)
        {
            CargarReporte(_ds);
            this.rv1.RefreshReport();
        }

        private DataSet ReturnDataset()
        {
            DataSet ds = new DataSet();
            try
            {
                CorteDeVoucherParametros parametros = new CorteDeVoucherParametros();
                p = parametros.GetParameters(pAccion, pClaveEmpresa);

                return dATABASEMYSQL.RegresaDataSet("GetCorteDeVouchers", "tblDatos", ref pvarError, p);
            }
            catch (Exception err)
            {
                Alertas.Show("Ha ocurrido un problema: " + err.Message, "Error!", Alertas.Buttons.OK, Alertas.Icon.Error);
                return ds;
            }
        }

        private void CargarReporte(DataSet dtsDataReport)
        {
            try
            {
                string reportName = "RptCorteDeVoucher";

                rv1.ProcessingMode = ProcessingMode.Local;
                string appPath = Application.StartupPath;
                string dbPath = @"\Objetos\Reportes\" + reportName + ".rdlc";
                rv1.LocalReport.ReportPath = appPath + dbPath;


                pAccion = 2;
                pClaveEmpresa = _Filtros.ClaveEmpresa.ToString();
                DataSet dsDatosEmpresa = ReturnDataset();

                DataTable dtDatosEmpresa = dsDatosEmpresa.Tables[0];
                DataTable dtDatosReporte = dtsDataReport.Tables[0];

                ReportDataSource rdsDatosEmpresa = new ReportDataSource("DatosEmpresa", dtDatosEmpresa);
                ReportDataSource rdsDatosReporte = new ReportDataSource("DatosReporte", dtDatosReporte);

                ReportParameter[] arp = new ReportParameter[3];
                arp[0] = new ReportParameter("numeroEmpleado", _Filtros.nombreEmpleado.ToString());
                arp[1] = new ReportParameter("Title", _Filtros.Title);
                arp[2] = new ReportParameter("condiciones", _Filtros.condiciones);

                rv1.LocalReport.DataSources.Clear();
                rv1.LocalReport.SetParameters(arp);
                rv1.LocalReport.DataSources.Add(rdsDatosEmpresa);
                rv1.LocalReport.DataSources.Add(rdsDatosReporte);

                rv1.RefreshReport();
            }
            catch (Exception err)
            {
                //Alertas.Show(err.ToString());
                MessageBox.Show(err.ToString());
            }
        }
    }
}
