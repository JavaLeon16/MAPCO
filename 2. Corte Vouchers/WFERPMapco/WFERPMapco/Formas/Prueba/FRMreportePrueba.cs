using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFERPMapco.Objetos.DataSets.rptPrueba;
using WFERPMapco.Objetos.Datos.Modulos.Capturas;
using WFERPMapco.Objetos.Utilerias;

namespace WFERPMapco.Formas.Prueba
{
    public partial class FRMreportePrueba : Form
    {
        public FRMreportePrueba()
        {
            InitializeComponent();
          //this.
          //      #007bff
        }

        private void FRMreportePrueba_Load(object sender, EventArgs e)
        {
            this.rptContainer.Refresh();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

            Resultado resultado = new Resultado();
            ReportePrueba datos = new ReportePrueba();
            string filtro;
            try
            {
                filtro = txtFiltro.Text;
                resultado = datos.obtenerDatos(filtro);

                if(!resultado.Error)
                {
                    cargarReporte(resultado.Datos);
                }
                else
                {
                    Alertas.Show("Ha ocurrido un problema" + resultado.MensajeError, "Error!", Alertas.Buttons.OK, Alertas.Icon.Error);
                }
                
            }
            catch(Exception err)
            {
                Alertas.Show("Ha ocurrido un problema"+err.Message,"Error!",Alertas.Buttons.OK,Alertas.Icon.Error);
            }
        }

        private void cargarReporte(DataSet dts)
        {

           LocalReport reporte = new LocalReport();
           var serverReport = rptContainer.ServerReport;
            ReportParameter[] arp = new ReportParameter[1];
            try
            {
                DataTable dt = dts.Tables[0];
                string filtro = txtFiltro.Text;
                

                rptContainer.ProcessingMode = ProcessingMode.Local;
                string appPath = Application.StartupPath;
                string dbPath = @"\Objetos\Reportes\rptPrueba.rdlc";
                rptContainer.LocalReport.ReportPath = appPath+dbPath;
                DsPrueba ds = new DsPrueba();
                ReportDataSource rdsListadoPrueba = new ReportDataSource("Ds_Prueba", dt);
                arp[0]= new ReportParameter("Filtro", filtro.Trim());
                rptContainer.LocalReport.DataSources.Clear();
                rptContainer.LocalReport.SetParameters(arp);
                rptContainer.LocalReport.DataSources.Add(rdsListadoPrueba);


                rptContainer.RefreshReport() ;
            }
            catch (Exception err)
            {
                Alertas.Show(err.Message);
            }
        }
    }
}
