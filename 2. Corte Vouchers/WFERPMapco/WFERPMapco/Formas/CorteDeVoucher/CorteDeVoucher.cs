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
    public partial class CorteDeVoucher : Form
    {
        Clases.MenuParametros ParaModulo;
        MySqlParameter[] p;
        DATABASEMYSQL dATABASEMYSQL = new DATABASEMYSQL();
        CorteDeVoucherParametros _Filtros;
        DataSet ds;

        int pAccion = 0;
        string pvarError;
        string pClaveEmpresa = null;

        public CorteDeVoucher(Clases.MenuParametros _Parametros)
        {
            ParaModulo = _Parametros;
            pClaveEmpresa = _Parametros.IdEmpresa.ToString();
            InitializeComponent();
        }



        private void CorteDeVouchers_Load(object sender, EventArgs e)
        {
            LoadCbx(1, cbxCaja, "IdCaja", "Caja");
        }

        private void LoadCbx(int accion, ComboBox cbo, string ValueMember, string DisplayMember)
        {
            pAccion = accion;
            DataSet ds = ReturnDataset();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                cbo.DataSource = ds.Tables[0];
                cbo.ValueMember = ValueMember;
                cbo.DisplayMember = DisplayMember;
                cbo.SelectedIndex = 0;

            }
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


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            pAccion = 3;
            ds = new DataSet();
            ds = ReturnDataset();
            if (ds.Tables[0].Rows.Count > 0)
            {
                _Filtros = new CorteDeVoucherParametros();
                _Filtros.Title = "VOUCHERS";
                _Filtros.nombreEmpleado = ParaModulo.NumeroEmpleado.ToString();
                _Filtros.condiciones = $"Fecha: {dtpFechaInicio.Value.ToString("dd/MM/yyyy")}";
                _Filtros.ClaveEmpresa = ParaModulo.IdEmpresa;
                CorteDeVouchersRpt mdl = new CorteDeVouchersRpt(ds, _Filtros);
                mdl.ShowDialog(this);
            }
            else
            {
                Alertas.Show("No se encontraron resultados con los filtros seleccionados.", "Aviso!", Alertas.Buttons.OK, Alertas.Icon.Error);
            }
        }
    }
}
