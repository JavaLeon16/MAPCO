using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFERPMapco.Formas.Mensajes
{
    public partial class Mensaje : Form
    {
        string varTipo ;
        Point poinScreen;
        int contador = 0;
        public Mensaje(string mensaje, AlertType tipo, Form pForm)
        {
            InitializeComponent();

            switch (tipo) {
                case AlertType.Success:
                    this.BackColor = ColorTranslator.FromHtml("#229756");
                    pnlbar.BackColor= ColorTranslator.FromHtml("#378258");
                    // progressBar1.BackColor = Color.SeaGreen;
                    ipcIcon.IconChar = FontAwesome.Sharp.IconChar.Check;
                    break;
                case AlertType.Info:
                    this.BackColor = ColorTranslator.FromHtml("#3e5f8a");
                    pnlbar.BackColor = ColorTranslator.FromHtml("#324c6e");
                    ipcIcon.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
                    break;
                case AlertType.Warning:
                    this.BackColor = Color.FromArgb(255, 128, 0);
                    pnlbar.BackColor = ColorTranslator.FromHtml("#cc6600");
                    //  progressBar1.BackColor = Color.FromArgb(255, 128, 0);
                    ipcIcon.IconChar = FontAwesome.Sharp.IconChar.ExclamationCircle;
                    break;
                case AlertType.Error:
                    this.BackColor = Color.Crimson;
                   // pnlbar.BackColor = ColorTranslator.FromHtml("#841626");
                    ipcIcon.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
                    tickProgress.Enabled = false;
                    pnlbar.Width = 0;
                  //  lblMensaje.AutoSize = true;
                    if (lblMensaje.Height> this.Height)
                    {
                        this.Height = lblMensaje.Height + 18;
                    }
                    break;
            }
            varTipo = tipo.ToString();
            lblMensaje.Text = mensaje;
            Screen scr = Screen.FromPoint(this.Location);

            contador = Application.OpenForms.OfType<Mensaje>().Count();
            poinScreen = new Point((pForm.Location.X + pForm.Width - this.Width -30), (pForm.Location.Y + pForm.Height- this.Height-30 - (contador*91)));


           
            //this.Location = new Point((pForm.Location.X+pForm.Width)/2,(pForm.Location.Y+pForm.Height)/2);
            //this.Parent = pForm;
          //  this.CenterToParent();
          //  this.Location = ParentForm.Location;
            //progressBar1.ForeColor = Color.FromArgb(255,0,0);
           // progressBar1.BackColor = Color.FromArgb(150,0,0);

        }


      

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Alerta_Load(object sender, EventArgs e)
        {

            //this.Top = -1*(this.Height);
            //    this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 60;

            this.Location = poinScreen;
        }

        public static void Show(string mensaje, AlertType tipo, Form pForm)
        {
            if (tipo == AlertType.Error || tipo == AlertType.Warning)
            {
                new Mensaje(mensaje, tipo, pForm).ShowDialog();
            }
            else
            {
                new Mensaje(mensaje, tipo, pForm).Show();
            }
        }

        private void timeout_Tick(object sender, EventArgs e)
        {
            if(varTipo!="Error")
            {
                this.Close();
            }
        }

        private void tickProgress_Tick(object sender, EventArgs e)
        {
            pnlbar.Width += 14;
        }

        private void Alerta_Click(object sender, EventArgs e)
        {
            desactivarTimer();
        }

        private void desactivarTimer()
        {
            if (varTipo != "Error")
            {
                timeout.Enabled = false;
                pnlbar.Width = 359;
            }
        }

        private void ipcIcon_Click(object sender, EventArgs e)
        {
            desactivarTimer();
        }

        private void pnlbar_Click(object sender, EventArgs e)
        {
            desactivarTimer();
        }

        private void lblMensaje_Click(object sender, EventArgs e)
        {
            desactivarTimer();
        }

        private void Alerta_MouseHover(object sender, EventArgs e)
        {
            desactivarTimer();
        }

        private void lblMensaje_MouseHover(object sender, EventArgs e)
        {
            desactivarTimer();
        }

        private void ipcIcon_MouseHover(object sender, EventArgs e)
        {
            desactivarTimer();
        }

        private void pnlbar_MouseHover(object sender, EventArgs e)
        {
            desactivarTimer();
        }

        private void timerclose_Tick(object sender, EventArgs e)
        {
            if(varTipo =="SUCCESS" || varTipo== "INFO" || varTipo=="NEUTRAL")
            {
                this.Close();
            }
        }
    }


    public enum AlertType
    {
        Success, Info, Warning, Error, Neutral
    }

   
}
