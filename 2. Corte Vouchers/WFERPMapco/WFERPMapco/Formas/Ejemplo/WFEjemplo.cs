using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFERPMapco.Objetos.Utilerias;

namespace WFERPMapco.Formas.Ejemplo
{
    public partial class WFEjemplo : Form
    {

        Resultado resultado = new Resultado();
        Objetos.Datos.Modulos.Catalogos.Ejemplo Datos = new Objetos.Datos.Modulos.Catalogos.Ejemplo();

        public WFEjemplo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                resultado = Datos.obtenerEjemplo();
                if (!resultado.Error)
                {
                    MessageBox.Show("Todo bien:" + resultado.Datos.Tables[0].Rows[0][0]) ;
                }
                else
                {
                    MessageBox.Show("Todo mal:" + resultado.Error);
                }
            }
            catch(Exception ERR)
            {
                MessageBox.Show("Ha ocurrido un problema: "+ERR.Message.ToString());
            }
        }
    }
}
