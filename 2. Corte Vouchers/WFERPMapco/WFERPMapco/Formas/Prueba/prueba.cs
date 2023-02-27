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
using WFERPMapco.Formas.Mensajes;
using WFERPMapco.Objetos.Utilerias;

namespace WFERPMapco.Formas.Prueba
{
    public partial class prueba : Form
    {
        public prueba( MenuParametros par)
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
           
            Mensaje.Show("mensaje",AlertType.Success,this);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Mensaje.Show("mensaje", AlertType.Info,this);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Mensaje.Show("mensaje", AlertType.Warning,this);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Mensaje.Show("mensajehdcghfdgfdhgfdhgfdgfdfgdfg jhgdg djgfdhgfdhfg jgdgfdfg hgfdgf fhg dhgfdfgh dhfgdfhgd fgd hfgd", AlertType.Error,this);
            Mensaje.Show("mensajehdcghfdgfdhgfdhgfdgfdfgdfg jhgdg djgfdhgfdhfg jgdgfdfg hgfdgf fhg dhgfdfgh dhfgdfhgd fgd hfgd", AlertType.Error, this);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
          Alertas.Show("Customized messagebox FadeIn", "title", Alertas.Buttons.RetryCancel, Objetos.Utilerias.Alertas.Icon.Error);
            Alertas.Show("mensajehdcghfdgfdhgfdhgfdgfdfgdfg jhgdg djgfdhgfdhfg jgdgfdfg hgfdgf fhg dhgfdfgh dhfgdfhgd fgd hfgd","titulo culero aslkfjl",Alertas.Buttons.OK,Alertas.Icon.Application);
        }

        private void prueba_Load(object sender, EventArgs e)
        {

        }
    }
}
