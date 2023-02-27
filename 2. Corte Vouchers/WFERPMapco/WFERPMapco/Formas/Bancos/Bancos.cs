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

namespace WFERPMapco.Formas.Bancos
{
    public partial class Bancos : Form
    {
        // VARIABLES
        private debug objDebug = new debug();
        private Banco banco = new Banco();
        private BancoContable bancoContable = new BancoContable();
        private Resultado resultado = new Resultado();
        private string textoGuardar = "Guardar", textoActualizar = "Actualizar";
        private enum TipoAcion
        {
            Registrar = 1,
            Actualizar = 2,
            Eliminar = 3
        };

        // CONSTRUCTORES

        public Bancos()
        {
            InitializeComponent();
        }

        public Bancos(MenuParametros parametros)
        {
            InitializeComponent();
        }

        // METODOS

        private void getBancos(string NomBanco = "")
        {
            resultado = banco.obtenerBancos(NomBanco);
            if (!resultado.Error)
            {
                if (resultado.Datos != null && resultado.Datos.Tables.Count > 0)
                {
                    gridBancos.DataSource = resultado.Datos.Tables[0];
                }
            }
            else
            {
                Alertas.Show("Algo salió mal: " + resultado.Error);
            }
        }

        private void getBancosContables()
        {
            resultado = bancoContable.obtenerBanco();
            if (!resultado.Error)
            {
                if (resultado.Datos != null && resultado.Datos.Tables.Count > 0)
                {
                    cmbBancoContable.DisplayMember = "Banco";
                    cmbBancoContable.ValueMember = "IdBancoContable";
                    cmbBancoContable.DataSource = resultado.Datos.Tables[0];
                    cmbBancoContable.SelectedIndex = 0;
                }
            }
            else
            {
                Alertas.Show("Algo salió mal: " + resultado.Error);
            }
        }

        private bool camposLlenos()
        {
            return cmbBancoContable.SelectedIndex >= 0 && txtNomBanco.Text.Trim() != "" && txtComisionBancaria.Value > 0;
        }

        private void limpiarCampos()
        {
            txtIdBanco.Text = "";
            cmbBancoContable.SelectedIndex = 0;
            txtNomBanco.Text = "";
            txtComisionBancaria.Value = 0;
            chkUsaTerminal.Checked = false;
            chkMapco.Checked = false;
            chkCapturaManual.Checked = false;
            btnGuardar.Text = textoGuardar;
        }

        private void accionBanco(
            int Opcion, int IdBanco, int IdBancoContable, string NomBanco, bool UsaTerminal, int Orden,
            bool Mapco, decimal ComisionBancaria, bool CapturaManual, int Usuario
        )
        {
            resultado = banco.accionBanco(Opcion, IdBanco, IdBancoContable, NomBanco, UsaTerminal, Orden, Mapco, ComisionBancaria, CapturaManual, Usuario);
            if (!resultado.Error)
            {
                if (resultado.Datos != null && resultado.Datos.Tables.Count > 0)
                {
                    string idBanco = resultado.Datos.Tables[0].Rows[0]["IdBanco"].ToString().Trim();
                    limpiarCampos();
                    getBancos();
                    if (Opcion == (int)TipoAcion.Registrar)
                    {
                        Alertas.Show("Banco registrado correctamente: " + idBanco);
                    }
                    else if (Opcion == (int)TipoAcion.Actualizar)
                    {
                        Alertas.Show("Banco actualizado correctamente: " + IdBanco.ToString().Trim());
                    }
                    else if (Opcion == (int)TipoAcion.Eliminar)
                    {
                        Alertas.Show("Banco eliminado correctamente: " + IdBanco.ToString().Trim());
                    }
                }
            }
            else
            {
                Alertas.Show("Algo salió mal: " + resultado.Error);
            }
        }

        //private void actualizarBanco(
        //    int IdBanco, int IdBancoContable, string NomBanco, bool UsaTerminal, int Orden,
        //    bool Mapco, decimal ComisionBancaria, bool CapturaManual, int Usuario
        //)
        //{
        //    resultado = banco.accionBanco(Opcion, IdBanco, IdBancoContable, NomBanco, UsaTerminal, Orden, Mapco, ComisionBancaria, CapturaManual, Usuario);
        //    if (!resultado.Error)
        //    {
        //        if (resultado.Datos != null && resultado.Datos.Tables.Count > 0)
        //        {
        //            limpiarCampos();
        //            getBancos();
        //            Alertas.Show("Banco actualizado correctamente: " + IdBanco.ToString().Trim());
        //        }
        //    }
        //    else
        //    {
        //        Alertas.Show("Algo salió mal: " + resultado.Error);
        //    }
        //}

        //private void eliminarBanco(

        //)
        //{

        //}

        // EVENTOS FORM

        private void Bancos_Load(object sender, EventArgs e)
        {
            getBancos();
            getBancosContables();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (camposLlenos())
            {
                if (btnGuardar.Text == textoGuardar && txtIdBanco.Text == "")
                {
                    // REGISTRAR DATOS DE BANCO
                    accionBanco(
                        (int)TipoAcion.Registrar, 0, int.Parse(cmbBancoContable.SelectedValue.ToString()), txtNomBanco.Text, chkUsaTerminal.Checked,
                        0, chkMapco.Checked, txtComisionBancaria.Value, chkCapturaManual.Checked, objDebug.NumeroEmpleado
                    );
                }
                else if (btnGuardar.Text == textoActualizar && txtIdBanco.Text != "")
                {
                    // ACTUALIZAR DATOS DE BANCO
                    accionBanco(
                        (int)TipoAcion.Actualizar, int.Parse(txtIdBanco.Text), int.Parse(cmbBancoContable.SelectedValue.ToString()), txtNomBanco.Text,
                        chkUsaTerminal.Checked, 0, chkMapco.Checked, txtComisionBancaria.Value, chkCapturaManual.Checked, objDebug.NumeroEmpleado
                    );
                }
            }
            else
            {
                Alertas.Show("Favor de capturar todos los campos necesarios");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void gridBancos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridBancos.Rows.Count > 0)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 15)
                {
                    DataGridViewRow fila = gridBancos.Rows[e.RowIndex];
                    if (e.ColumnIndex == 15)
                    {
                        // EDITAR DATOS DE BANCO
                        txtIdBanco.Text = fila.Cells[0].Value.ToString().Trim();
                        cmbBancoContable.SelectedValue = fila.Cells[1].Value.ToString().Trim();
                        txtNomBanco.Text = fila.Cells[2].Value.ToString().Trim();
                        txtComisionBancaria.Value = decimal.Parse(fila.Cells[6].Value.ToString().Trim());
                        chkUsaTerminal.Checked = fila.Cells[3].Value.ToString().Trim() == "0" ? false : true;
                        chkMapco.Checked = fila.Cells[5].Value.ToString().Trim() == "0" ? false : true;
                        chkCapturaManual.Checked = fila.Cells[7].Value.ToString().Trim() == "0" ? false : true;
                        btnGuardar.Text = textoActualizar;
                    }
                    else if (e.ColumnIndex == 16)
                    {
                        // ELIMINAR DATOS DE BANCO
                        if (
                            MessageBox.Show(
                                "¿Desea eliminar el banco seleccionado (" + fila.Cells[2].Value.ToString().Trim() + ")?", 
                                "Eliminar Banco", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
                        )
                        {
                            accionBanco(
                                (int)TipoAcion.Eliminar, int.Parse(fila.Cells[0].Value.ToString().Trim()), 
                                0, "", false, 0, false, 0, false, objDebug.NumeroEmpleado
                            );
                        }
                    }

                }
            }
        }
    }
}
