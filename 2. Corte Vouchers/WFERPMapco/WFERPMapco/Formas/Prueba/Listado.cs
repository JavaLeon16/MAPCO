using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFERPMapco.Objetos.Datos.Modulos.Capturas;
using WFERPMapco.Objetos.Utilerias;
using WFERPMapco.Clases;
using System.Linq;

namespace WFERPMapco.Formas.Prueba
{
    public partial class Listado : Form
    {
        public Listado(Clases.MenuParametros parametros)
        {
            InitializeComponent();
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

                if (!resultado.Error)
                {
                    // List<DataRow> rlist = resultado.Datos.Tables[0].AsEnumerable().ToList(
                    // List<WFERPMapco.Clases.Prueba> list = new List<Clases.Prueba>();
                    // list = (List<Clases.Prueba>)resultado.Datos.Tables[0].AsEnumerable().ToList();
                    List<WFERPMapco.Clases.Prueba> list = resultado.Datos.Tables[0].AsEnumerable().Select(m => new Clases.Prueba()
                    {
                        idPrueba = m.Field<int>("idPrueba"),
                        Descripcion = m.Field<string>("Descripcion"),
                        Fecha = m.Field<DateTime>("Fecha"),
                    }).ToList();


                    grvListado.DataSource = list;
                    //DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                    //{
                    //    button.Name = "ejemplo";
                    //    button.HeaderText = "Editar";
                    //    button.Text = "Edit";
                    //    button.UseColumnTextForButtonValue = true; //dont forget this line
                    //    this.grvListado.Columns.Add(button);
                    //}
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
    }
}
