using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFERPMapco.Clases;
using WFERPMapco.Objetos.Datos.Modulos.Catalogos;
using WFERPMapco.Objetos.Utilerias;

namespace WFERPMapco.Formas.TipoOperacion
{
    public partial class TipoOperacion : Form
    {
        Resultado resultado = new Resultado();
        Banco banco = new Banco();
        Dispositivo dispositivo = new Dispositivo();
        DataTable datat = new DataTable();
        List<OperacionTipo> list = new List<OperacionTipo>();
        Operacion operacion = new Operacion();
        OperacionTipo operacionTipo = new OperacionTipo();
        bool chkEP = false;
        bool chkCM = false;
        int IdTipoOper = 0;
        public TipoOperacion(MenuParametros parametros)
        {
            InitializeComponent();
        }

        #region Metodos
        private void comboBancos()
        {
            resultado = banco.obtenerBancos();
            if (!resultado.Error)
            {
                datat = resultado.Datos.Tables[0];
                DataRow row = datat.NewRow();
                cmbBanco.DisplayMember = "Banco";
                cmbBanco.ValueMember = "IdBanco";
                row["Banco"] = "SELECCIONA BANCO...";
                row["IdBanco"] = 0;
                datat.Rows.InsertAt(row, 0);
                cmbBanco.DataSource = datat;
            }
            else
            {
                Alertas.Show("Algo Salido Mal En El Combo Bancos");
            }
        }
        private void comboDispositivos()
        {
            resultado = dispositivo.obtenerDispositivo();
            if (!resultado.Error)
            {
                datat = resultado.Datos.Tables[0];
                DataRow row = datat.NewRow();
                cmbDispositivo.DisplayMember = "NombreDispositivo";
                cmbDispositivo.ValueMember = "IdDispositivo";
                row["NombreDispositivo"] = "SELEC.. DISPOSITIVO...";
                datat.Rows.InsertAt(row, 0);
                cmbDispositivo.DataSource = datat;
            }
            else
            {
                Alertas.Show("Algo Salido Mal En El Combo Dispositivos");
            }
        }

        private void comboTipoOperacion()
        {
            cmbTipoOperacion.DisplayMember = "Operacion";
            cmbTipoOperacion.ValueMember = "TipoOperacion";
            var items = new[]
            {
                new { TipoOperacion = true, Operacion = "VENTA A CONTADO"},
                new { TipoOperacion = false, Operacion = "VENTA A CREDITO"}
            };
            cmbTipoOperacion.DataSource = items;
        }

        private void cargaGridTipoOperacion()
        {
            try
            {
                resultado = operacion.obtenerTipoOperacion();
                if (!resultado.Error)
                {
                    list = resultado.Datos.Tables[0].AsEnumerable().Select(m => new OperacionTipo()
                    {
                        IdTipoOperacion = m.Field<int>("IdTipoOperacion"),
                        IdBanco = m.Field<int>("IdBanco"),
                        Banco = m.Field<string>("Banco"),
                        Descripcion = m.Field<string>("Descripcion"),
                        ImporteMaximo = m.Field<double>("ImporteMaximo"),
                        ImporteComisionFija = m.Field<double>("ImporteComisionFija"),
                        PorcentajeComision = m.Field<double>("PorcentajeComision"),
                        PorcentajeProteccion = m.Field<double>("PorcentajeProteccion"),
                        IdTO = m.Field<bool>("IdTO"),
                        TipoOperacion = m.Field<string>("TipoOperacion"),
                        EsPromocion = Convert.ToBoolean(m.Field<int>("EsPromocion")),
                        CompraMinima = m.Field<double>("CompraMinima"),
                        Meses = m.Field<int>("Meses"),
                        Estatus = m.Field<bool>("Estatus"),
                        KlaveKarum = m.Field<string>("KlaveKarum"),
                        PorcentajeComisionFinancieraMapco = m.Field<double>("PorcentajeComisionFinancieraMapco"),
                        CapturaManual = m.Field<bool>("CapturaManual"),
                        IdDispositivo = m.Field<int>("IdDispositivo"),
                        Dispositivo = m.Field<string>("NombreDispositivo")
                    }).ToList();
                    gridTipoOperacion.DataSource = list.ToList();
                }
            }
            catch (Exception err)
            {

                Alertas.Show("Ha ocurrido un problema" + err.Message, "Error!", Alertas.Buttons.OK, Alertas.Icon.Error);
            }
        }

        private void init()
        {
            comboBancos();
            comboDispositivos();
            comboTipoOperacion();
            cargaGridTipoOperacion();
        }

        private void limpiar()
        {
            cmbBanco.SelectedValue = 0;
            txtDescripcion.Text = string.Empty;
            txtImpMax.Text = string.Empty;
            txtImpComFija.Text = string.Empty;
            txtPorCom.Text = string.Empty;
            txtPorcentProt.Text = string.Empty;
            cmbTipoOperacion.SelectedValue = true;
            chkCapturaManual.Checked = false;
            chkEsPromocion.Checked = false;
            txtCompMin.Text = string.Empty;
            txtMeses.Text = string.Empty;
            txtClaveKarum.Text = string.Empty;
            txtPorcenComFinMap.Text = string.Empty;
            cmbDispositivo.SelectedValue = 0;
            IdTipoOper = 0;
        }
        #endregion

        #region Eventos

        private void TipoOperacion_Load(object sender, EventArgs e)
        {
            init();
        }

        private void txtImpMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtImpComFija_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtPorCom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtPorcentProt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtCompMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtMeses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPorcenComFinMap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        #endregion

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            crearObjeto();
            try
            {
                //EnviarObjeto
                if(operacionTipo.IdTipoOperacion == 0)
                    resultado = operacion.MantenimientoTipoOperacion(1,operacionTipo);
                else
                    resultado = operacion.MantenimientoTipoOperacion(2, operacionTipo);

                if (!resultado.Error)
                {
                    Alertas.Show("Se guardo operacion correctamente!");
                    limpiar();
                    cargaGridTipoOperacion();
                }
                IdTipoOper = 0;

            }
            catch (Exception err)
            {

                Alertas.Show("Ha ocurrido un problema" + err.Message, "Error!", Alertas.Buttons.OK, Alertas.Icon.Error);
            }
        }

        private void crearObjeto()
        {
            if (chkEsPromocion.Checked == true)
            {
                chkEP = true;
            }
            if (chkCapturaManual.Checked == true)
            {
                chkCM = true;
            }
            
            operacionTipo.IdTipoOperacion = IdTipoOper;
            operacionTipo.IdBanco = int.Parse(cmbBanco.SelectedValue.ToString());
            operacionTipo.Descripcion = txtDescripcion.Text;
            operacionTipo.ImporteMaximo = double.Parse(txtImpMax.Text);
            operacionTipo.ImporteComisionFija = double.Parse(txtImpComFija.Text);
            operacionTipo.PorcentajeComision = double.Parse(txtPorCom.Text);
            operacionTipo.PorcentajeProteccion = double.Parse(txtPorcentProt.Text);
            operacionTipo.IdTO = bool.Parse(cmbTipoOperacion.SelectedValue.ToString());
            operacionTipo.TipoOperacion = cmbTipoOperacion.Text;
            operacionTipo.CapturaManual = chkCM;
            operacionTipo.EsPromocion = chkEP;
            operacionTipo.CompraMinima = double.Parse(txtCompMin.Text);
            operacionTipo.Meses = int.Parse(txtMeses.Text);
            operacionTipo.Estatus = true;
            operacionTipo.KlaveKarum = txtClaveKarum.Text;
            operacionTipo.PorcentajeComisionFinancieraMapco = double.Parse(txtPorcenComFinMap.Text);            
            operacionTipo.IdDispositivo = int.Parse(cmbDispositivo.SelectedValue.ToString());
            operacionTipo.UsuarioInsert = 9999;
            operacionTipo.FechaInsert = DateTime.Now;
            operacionTipo.UsuarioUpdate = 9999;
            operacionTipo.FechaUpdate = DateTime.Now;
            operacionTipo.UsuarioBaja = 9999;
            operacionTipo.FechaBaja = DateTime.Now;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void gridTipoOperacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridTipoOperacion.Rows.Count > 0)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 25 )
                {
                    if (e.ColumnIndex == 25)
                    {
                        IdTipoOper = (int)gridTipoOperacion.Rows[e.RowIndex].Cells[0].Value;
                        cmbBanco.SelectedValue = (int)gridTipoOperacion.Rows[e.RowIndex].Cells[1].Value;
                        txtDescripcion.Text = gridTipoOperacion.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtImpMax.Text = gridTipoOperacion.Rows[e.RowIndex].Cells[4].Value.ToString();
                        txtImpComFija.Text = gridTipoOperacion.Rows[e.RowIndex].Cells[5].Value.ToString();
                        txtPorCom.Text = gridTipoOperacion.Rows[e.RowIndex].Cells[6].Value.ToString();
                        txtPorcentProt.Text = gridTipoOperacion.Rows[e.RowIndex].Cells[7].Value.ToString();
                        cmbTipoOperacion.SelectedValue = (bool)gridTipoOperacion.Rows[e.RowIndex].Cells[8].Value;
                        chkEsPromocion.Checked = (bool)gridTipoOperacion.Rows[e.RowIndex].Cells[10].Value;
                        txtCompMin.Text = gridTipoOperacion.Rows[e.RowIndex].Cells[11].Value.ToString();
                        txtMeses.Text = gridTipoOperacion.Rows[e.RowIndex].Cells[12].Value.ToString();
                        txtClaveKarum.Text = gridTipoOperacion.Rows[e.RowIndex].Cells[14].Value.ToString();
                        chkCapturaManual.Checked = (bool)gridTipoOperacion.Rows[e.RowIndex].Cells[16].Value;
                        txtPorcenComFinMap.Text = gridTipoOperacion.Rows[e.RowIndex].Cells[15].Value.ToString();
                        cmbDispositivo.SelectedValue = (int)gridTipoOperacion.Rows[e.RowIndex].Cells[17].Value;
                    }
                    else
                    {
                        OperacionTipo opert = new OperacionTipo();
                        opert.IdTipoOperacion = (int)gridTipoOperacion.Rows[e.RowIndex].Cells[0].Value;
                        opert.Estatus = false;
                        opert.UsuarioBaja = 9999;
                        opert.FechaBaja = DateTime.Now;
                        DialogResult dr = MessageBox.Show("Esta Seguro que desea eliminar el registro?", "Title", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            try
                            {
                                resultado = operacion.MantenimientoTipoOperacion(3, opert);
                                if (!resultado.Error)
                                {
                                    Alertas.Show("Se elimino registro correctamente!");
                                    cargaGridTipoOperacion();
                                }
                            }
                            catch (Exception err)
                            {

                                Alertas.Show("Ha ocurrido un problema" + err.Message, "Error!", Alertas.Buttons.OK, Alertas.Icon.Error);
                            }
                        }
                    }
                }
            }
        }
    }
}
