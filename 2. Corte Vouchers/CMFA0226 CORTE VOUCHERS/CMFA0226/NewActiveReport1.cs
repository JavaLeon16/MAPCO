using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace CMFA0226
{
    /// <summary>
    /// Summary description for NewActiveReport1.
    /// </summary>
    public partial class NewActiveReport1 : DataDynamics.ActiveReports.ActiveReport
    {
        public  string SUCURSAL = string.Empty;
        public string fecha = string.Empty;
        public int p = 0;
        public NewActiveReport1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void reportHeader1_Format(object sender, EventArgs e)
        {
            p = p+1;
            txtpag.Text = Convert.ToString(p);
            lblfecha.Text = lblfecha.Text + fecha;
            lblsucursal.Text = lblsucursal.Text +SUCURSAL;
            lblalafecha.Text = lblalafecha.Text + " " + DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
