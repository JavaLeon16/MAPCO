using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using DataDynamics.ActiveReports.Export.Pdf;
//using DataDynamics.ActiveReports.Export.Xls;
//using DataDynamics.ActiveReports.Export.Html;

namespace CMFA0226
{
    public partial class FrmVisor : Form
    {      
       
        public DataTable tabla;
        public string SUCURSAL ;
        public string fecha ;

        //string filtro;
        int reporte;
        public FrmVisor(int _reporte)
        {
            InitializeComponent();            
            reporte = _reporte;
        }

        private void FrmVisor_Load(object sender, EventArgs e)
        {           
            //Sacamos los datos de la empresa
            //DataTable empresa = Empresas.selectempresa(45);
            if(reporte == 1)
            {
                NewActiveReport1 rpt = new NewActiveReport1();
                rpt.DataSource = tabla;
                rpt.SUCURSAL = SUCURSAL;
                rpt.fecha = fecha;
                //Run and view the report
                rpt.Run(false);
                viewer1.Visible = true;
                viewer1.Document = rpt.Document;
            }
        }

        private void viewer1_ToolClick(object sender, DataDynamics.ActiveReports.Toolbar.ToolClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (e.Tool.Id == 25)
            {
                Object RutaDir = Convert.ToString(Environment.CurrentDirectory);
                saveFileDialog.Filter = "Acrobat Reader (*.pdf)|*.pdf";
                saveFileDialog.Title = "Exportar a archivo";
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    try
                    {
                        string Extfile = (saveFileDialog.FileName.Substring(saveFileDialog.FileName.Length - 3, 3));
                        switch (Extfile.ToUpper())
                        {
                            case "PDF":
                                DataDynamics.ActiveReports.Export.Pdf.PdfExport MyPd = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
                                MyPd.Export(this.viewer1.Document, saveFileDialog.FileName);
                                MyPd.Dispose();
                                break;
                        }
                    }
                    catch (Exception Ex) { throw new Exception(Ex.Message, Ex.InnerException); }
                }
            }
        }        
    }
}