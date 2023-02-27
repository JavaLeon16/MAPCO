using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WFERPMapco.Clases;
using WFERPMapco.Objetos.Datos.Modulos.Catalogos;
using WFERPMapco.Objetos.Utilerias;

namespace WFERPMapco.Formas.Ficha
{
    public partial class Ficha : Form
    {
        Resultado resultado = new Resultado();
        BancoContable banco = new BancoContable();
        Movimiento movimiento = new Movimiento();
        Cuenta cuenta = new Cuenta();
        DataTable datat = new DataTable();
        Objetos.Datos.Modulos.Capturas.Fichas fichas = new Objetos.Datos.Modulos.Capturas.Fichas();
        List<Fichas> list = new List<Fichas>();
        List<Fichas> listAux = new List<Fichas>();
        int contador = 0;
        bool esEditado = false;
        bool existeFicha = false;
        int rowEditar = 0;
        bool esConsulta = false;

        public Ficha(MenuParametros parametros)
        {
            InitializeComponent();
        }

        private void Ficha_Load(object sender, EventArgs e)
        {
            Init();
        }

        #region Combos
        private void cargaBanco()
        {
            resultado = banco.obtenerBanco();
            if (!resultado.Error)
            {
                datat = resultado.Datos.Tables[0];
                cmbBanco.DisplayMember = "Banco";
                cmbBanco.ValueMember = "IdBancoContable";
                cmbBanco.DataSource = datat;
                resultado = cuenta.obtenerCuenta(int.Parse(cmbBanco.SelectedValue.ToString()));
                if (!resultado.Error)
                {
                    txtCuenta.Text = resultado.Datos.Tables[0].Rows[0][0].ToString();
                }
            }
            else
            {
                Alertas.Show("Algo salio mal: " + resultado.Error);
            }
            cmbBanco.SelectedIndex = 0;
        }

        private void cargaMovimientos()
        {
            resultado = movimiento.obtenerMovimientos();
            if (!resultado.Error)
            {
                datat = resultado.Datos.Tables[0];
                cmbMovimiento.DisplayMember = "Movimiento";
                cmbMovimiento.ValueMember = "IdTipoMovimientoFicha";
                cmbMovimiento.DataSource = datat;                
            }
            else
            {
                Alertas.Show("Todo mal:" + resultado.Error);
            }
            cmbMovimiento.SelectedIndex = 0;
        }
        #endregion

        #region eventos
        private void txtFicha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if ((int)e.KeyChar == (int)Keys.Enter)
            {               
                if(txtFicha.Text == "")
                {
                    txtFicha.Focus();
                }
                else
                {
                    for (int i = 0; i < gridFichas.RowCount; i++)
                    {
                        if (Convert.ToInt32(gridFichas.Rows[i].Cells[0].Value) == Convert.ToInt32(txtFicha.Text))
                        {                            
                            existeFicha = true;
                        }
                    }
                    if (!existeFicha)
                    {                        
                        cmbBanco.Focus();
                        cmbBanco.DroppedDown = true;
                    }
                    else
                    {
                        Alertas.Show("La ficha que ingreso ya esta capturada.");
                        txtFicha.Text = "";
                        txtFicha.Focus();
                        existeFicha = false;
                    }
                }
            }
        }

        private void cmbMovimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtImporte.Focus();
        }

        private void cmbBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                resultado = cuenta.obtenerCuenta(int.Parse(cmbBanco.SelectedValue.ToString()));
                if (!resultado.Error)
                {
                    txtCuenta.Text = resultado.Datos.Tables[0].Rows[0][0].ToString();
                    cmbMovimiento.Focus();
                    cmbMovimiento.DroppedDown = true;
                }
                else
                {
                    Alertas.Show("Ocurrio un error");
                }

            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                

                if (txtImporte.Text == "")
                {
                    txtImporte.Focus();
                }
                else
                {
                    if (esEditado)
                    {                        
                        Fichas fichas = new Fichas();
                        fichas.IdFicha = int.Parse(txtFicha.Text);
                        fichas.Cuenta = txtCuenta.Text;
                        fichas.Banco = cmbBanco.Text;
                        fichas.Movimiento = cmbMovimiento.Text;
                        fichas.Importe = double.Parse(txtImporte.Text);
                        fichas.Consecutivo = gridFichas.Rows[rowEditar].Cells[5].Value.ToString();
                        fichas.IdTipoMovimientoFicha = int.Parse(cmbMovimiento.SelectedValue.ToString());
                        fichas.IdBanco = int.Parse(cmbBanco.SelectedValue.ToString());
                        fichas.UsuarioInsert = 9999;
                        fichas.FechaInsert = fechaFicha.Value;
                        fichas.FechaCorte = fechaCorte.Value;
                        fichas.UsuarioUpdate = 9999;
                        fichas.FechaUpdate = DateTime.Now;
                        fichas.UsuarioBaja = 9999;
                        fichas.FechaBaja = DateTime.Now;
                        fichas.Estatus = true;
                        fichas.EsConsulta = list[rowEditar].EsConsulta;
                        list[rowEditar] = fichas;                            
                        
                        if (esConsulta)
                        {
                            List<Fichas> lista = new List<Fichas>();
                            lista.Add(fichas);
                            limpiar();
                            txtFicha.Enabled = true;
                            txtFicha.Focus();
                            EliminarUpdateFicha(lista, false);;

                        }
                        else
                        {
                            gridFichas.DataSource = list.ToList();
                        }
                        esEditado = false;

                    }
                    else
                    {
                        contador++;
                        list.Add(new Clases.Fichas
                        {
                            IdFicha = int.Parse(txtFicha.Text),
                            Cuenta = txtCuenta.Text,
                            Banco = cmbBanco.Text,
                            Movimiento = cmbMovimiento.Text,
                            Importe = double.Parse(txtImporte.Text),
                            Consecutivo = contador.ToString("D03"),
                            IdTipoMovimientoFicha = int.Parse(cmbMovimiento.SelectedValue.ToString()),
                            IdBanco = int.Parse(cmbBanco.SelectedValue.ToString()),
                            UsuarioInsert = 9999,
                            FechaInsert = fechaFicha.Value,
                            FechaCorte = fechaCorte.Value,
                            UsuarioUpdate = 0,
                            FechaUpdate = fechaFicha.Value,
                            UsuarioBaja = 0,
                            FechaBaja = fechaFicha.Value,
                            Estatus = true,
                            EsConsulta = false
                        });
                        gridFichas.DataSource = list.ToList();
                        limpiar();
                    }

                    SumarImporte();                    
                }
            }
        }

        private void cmbBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultado = cuenta.obtenerCuenta(int.Parse(cmbBanco.SelectedValue.ToString()));
            if (!resultado.Error)
            {
                txtCuenta.Text = resultado.Datos.Tables[0].Rows[0][0].ToString();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (gridFichas.Rows.Count > 0)
            {

                string js = JsonConvert.SerializeObject(list.ToList());
                resultado = fichas.GuardaFichas(1,js);
                if (!resultado.Error)
                {
                    //txtCuenta.Text = resultado.Datos.Tables[0].Rows[0][0].ToString();                    
                    Alertas.Show("Las fichas fueron guardadas exitosamente");
                    cargaGridFichas();
                }
                else
                {
                    Alertas.Show("Las fichas fueron guardadas debido a un error.");
                }                             
                
            }
            else
            {
                Alertas.Show("Debes agregar fichas para poder guardar ");
            }
        }

        private void gridFichas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridFichas.Rows.Count > 0)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 17)
                {
                    if (e.ColumnIndex == 17)
                    {
                        txtFicha.Text = gridFichas.Rows[e.RowIndex].Cells[0].Value.ToString();
                        cmbBanco.SelectedValue = gridFichas.Rows[e.RowIndex].Cells[7].Value.ToString();
                        cmbMovimiento.SelectedValue = gridFichas.Rows[e.RowIndex].Cells[6].Value.ToString();
                        txtCuenta.Text = gridFichas.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtImporte.Text = gridFichas.Rows[e.RowIndex].Cells[4].Value.ToString();
                        esConsulta = bool.Parse(gridFichas.Rows[e.RowIndex].Cells[16].Value.ToString());
                        if(esConsulta)
                        {
                            txtFicha.Enabled = false;
                            cmbBanco.Focus();
                            cmbBanco.DroppedDown = true;
                        }
                        else
                        {
                            txtFicha.Focus();
                        }                        
                        esEditado = true;
                        rowEditar = e.RowIndex;
                    }
                    else
                    {
                        if (Convert.ToBoolean(gridFichas.Rows[e.RowIndex].Cells[16].Value.ToString()))
                        {                            
                            List<Fichas> lista = new List<Fichas>();
                            lista.Add(new Clases.Fichas
                            {                                
                                IdFicha = int.Parse(gridFichas.Rows[e.RowIndex].Cells[0].Value.ToString()),
                                Consecutivo = gridFichas.Rows[e.RowIndex].Cells[5].Value.ToString(),
                                FechaInsert = fechaFicha.Value,
                                UsuarioBaja = 9999,
                                FechaBaja = DateTime.Now,
                                Estatus = false,
                                EsConsulta = Convert.ToBoolean(gridFichas.Rows[e.RowIndex].Cells[16].Value.ToString())
                            });
                            EliminarUpdateFicha(lista,true);                            
                        }
                        else
                        {
                            list.RemoveAt(e.RowIndex);
                            gridFichas.DataSource = list.ToList();
                        }
                        SumarImporte();
                    }
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fechaFicha_ValueChanged(object sender, EventArgs e)
        {

            cargaGridFichas();
        }

        #endregion

        #region metodos
        private void limpiar()
        {
            txtFicha.Text = "";
            txtCuenta.Text = "";
            txtImporte.Text = "";
            cmbBanco.SelectedIndex = 0;
            cmbMovimiento.SelectedIndex = 0;
            txtFicha.Focus();
        }

        private void SumarImporte()
        {

            double totalImporte = 0;
            totalImporte = (double)gridFichas.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[4].Value));
            txtTotalImporte.Text = totalImporte.ToString();
        }

        private void Init()
        {
            cargaBanco();
            cargaMovimientos();
            txtCuenta.Enabled = false;
            fechaFicha.Value = DateTime.Now;
            fechaCorte.Value = DateTime.Now;
        }

        private void EliminarUpdateFicha(List<Fichas> lista, bool eliminaOActualiza)
        {
            string message;
            string js = JsonConvert.SerializeObject(lista.ToList());
            resultado = fichas.GuardaFichas(1, js);

            if (!resultado.Error)
            {                
                if (esEditado)
                    message = "La ficha se modifico correctamente";
                else
                    message = "La ficha se elimino correctamente";
                Alertas.Show(message);
                cargaGridFichas();
            }
            else
            {
                Alertas.Show("Las fichas fueron guardadas debido a un error.");
            }
        }

        private void cargaGridFichas()
        {
            DateTime fecha = fechaFicha.Value;
            try
            {
                resultado = fichas.ConsultarFichas(fecha);

                if (!resultado.Error)
                {
                    //txtCuenta.Text = resultado.Datos.Tables[0].Rows[0][0].ToString();
                    list = resultado.Datos.Tables[0].AsEnumerable().Select(m => new Fichas()
                    {
                        IdFicha = m.Field<int>("Ficha"),
                        Cuenta = m.Field<string>("Cuenta"),
                        Banco = m.Field<string>("Banco"),
                        Movimiento = m.Field<string>("Movimiento"),
                        Importe = m.Field<double>("Importe"),
                        Consecutivo = m.Field<string>("Consecutivo"),
                        IdTipoMovimientoFicha = m.Field<int>("IdTipoMovimientoFicha"),
                        IdBanco = m.Field<int>("IdBanco"),
                        UsuarioInsert = m.Field<int>("UsuarioInsert"),
                        FechaInsert = m.Field<DateTime>("FechaInsert"),
                        FechaCorte = m.Field<DateTime>("FechaCorte"),
                        Estatus = m.Field<bool>("Estatus"),
                        EsConsulta = true
                    }).ToList();
                    gridFichas.DataSource = list.ToList();

                    if (gridFichas.Rows.Count > 0)
                        contador = int.Parse(gridFichas.Rows[gridFichas.Rows.Count - 1].Cells[5].Value.ToString());

                    SumarImporte();
                }
                else
                {
                    Alertas.Show("Ha ocurrido un problema" + resultado.MensajeError, "Error!", Alertas.Buttons.OK, Alertas.Icon.Error);
                }

            }
            catch (Exception err)
            {
                Alertas.Show("Ha ocurrido un problema" + err.Message, "Error!", Alertas.Buttons.OK, Alertas.Icon.Error);
            }
        }
        #endregion
    }
}
