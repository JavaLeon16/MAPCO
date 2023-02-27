using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using WFERPMapco.Objetos.Utilerias;
using System.Security.Cryptography;
using System.Configuration;

namespace WFERPMapco.Formas.Login
{
    public partial class Login : Form
    {
        private Clases.MenuParametros parametros = new Clases.MenuParametros();
        private List<Clases.Sucursales> lsucursales = new List<Clases.Sucursales>();

        public Login()
        {
            InitializeComponent();
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            //pnllogo.BackColor = Color.FromArgb(8, 2, 120);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.Red, Color.Black, 90f);
            pnllogo.Paint += new PaintEventHandler(set_background);
            btnLogin.BackColor = Color.FromArgb(98, 166, 10);

            // background: linear - gradient(90deg, rgba(8, 2, 120, 1) 0 %, rgba(9, 9, 121, 1) 42 %, rgba(3, 121, 145, 1) 100 %);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Objetos.Utilerias.SucursalesMapco sucursales = new SucursalesMapco();
            List<Clases.Sucursales> sucur = sucursales.getSucursales();
            lsucursales = sucur;
            parametros.LSucursales = sucur;
            fillListadoSucursales(sucur);
        }

        private void pnllogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fillListadoSucursales(List<Clases.Sucursales> sucursales)
        {
            Resultado resultado = new Resultado();
            Objetos.Datos.Modulos.Capturas.Login datos = new Objetos.Datos.Modulos.Capturas.Login();

            try
            {
                //resultado = datos.obtenerSucursales();

                //if (!resultado.Error)
                //{
                //    if (resultado.Datos.Tables[0].Rows.Count > 0)
                //    {
                //        cbxSucursal.DataSource = resultado.Datos.Tables[0];
                //        cbxSucursal.DisplayMember = "NombreSucursal";
                //        cbxSucursal.ValueMember = "IdSucursal";
                //    }

                cbxSucursal.DataSource = sucursales;
                cbxSucursal.DisplayMember = "NombreSucursal";
                cbxSucursal.ValueMember = "IdSucursal";
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty));
            }
        }


        private void set_background(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(8, 2, 120), Color.FromArgb(57, 128, 227), 65f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Resultado resultado = new Resultado();
            Objetos.Datos.Modulos.Capturas.Login datos = new Objetos.Datos.Modulos.Capturas.Login();
            Clases.MenuParametros parametros = new Clases.MenuParametros();
            int numeroEmpleado = Convert.ToInt32(txtNumeroEmpleado.Text);
            string password = txtPassword.Text.Replace(" ", "").Trim();
            int idSucursal = Convert.ToInt32(cbxSucursal.SelectedValue);
            string passwordValida = "";


            if (numeroEmpleado == 0 || password == "")
            {
                MessageBox.Show("Usuario o Contraseña no validos");
                txtNumeroEmpleado.Focus();
                return;
            }
            if (idSucursal == 0)
            {
                MessageBox.Show("No se ha seleccionado sucursal");
                cbxSucursal.Focus();
                return;
            }

            try
            {

                parametros.IdSucursal = idSucursal;
               var sucursalFiltrada= (from a in lsucursales
                              where a.IdSucursal == idSucursal
                              select new{ a.IdSucursal,a.IdEmpresa,a.IdEstado,a.IdMunicipio,a.NombreSucursal,a.CodigoSucursal,a.IP,a.BasedeDatos}
                                         ).ToList();
                parametros.IpServidor = sucursalFiltrada.First().IP;
                parametros.BaseDatos = sucursalFiltrada.First().BasedeDatos;
                parametros.IdEmpresa = sucursalFiltrada.First().IdEmpresa;

                //  string cad = "Data Source=172.16.33.100;Port=3306;Initial Catalog=BDBASE1022;User ID=user;Password=mapcouser";
                 //  string cad = "Data Source=172.16.33.100;Port=3306;Initial Catalog=BDBASE1022;User ID=user;Password=mapcouser";
               //                  Data Source = 172.16.33.100; Port: 3306; Initial Catalog = BDBASE1022; User ID = user; Password = mapcouser
                string cad = "Data Source=" + parametros.IpServidor + ";Port=3306;Initial Catalog=BDBASE" + parametros.BaseDatos + "22;User ID=user;Password=mapcouser";
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //config.ConnectionStrings.ConnectionStrings.(new ConnectionStringSettings(
                //                                              "MYSQL",cad));

                config.ConnectionStrings.ConnectionStrings["MYSQL"].ConnectionString = cad;
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");


                resultado = datos.obtenerLogin(numeroEmpleado);


                if (!resultado.Error)
                {
                    if (resultado.Datos.Tables[0].Rows.Count > 0)
                    {
                        passwordValida = resultado.Datos.Tables[0].Rows[0]["Contrasena"].ToString();



                        //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password+ "ae6b6a20-4817-4d72-8887-952d5a097993");
                        ////    byte[] authSigninKey = Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM");


                        //byte[] data = Convert.FromBase64String("AD8eZBy/KH9V2+tV/yUPEnsXCLdnzdM01xiDvL3oz2lwASGPGiejeQDUjMKdFU133w==");

                        //using (SHA256CryptoServiceProvider sh = new SHA256CryptoServiceProvider())
                        //{
                        //    byte[] keys=sh.ComputeHash(data)
                        //}



                        if (password == passwordValida)
                        {



                            parametros.IdSucursal = idSucursal;
                            parametros.NumeroEmpleado = numeroEmpleado;
                            parametros.LSucursales = lsucursales;
                            

                            //frmMenu.Shown += (s, args) => this.Hide();

                            //frmMenu.Closed += (s, args) => this.Close();

                            //frmMenu.Show();

                            Program.IdSucursal = idSucursal;
                            Program.NumeroEmpleado = numeroEmpleado;
                            Program.OpenDetailFormOnClose = true;
                            Program.parametros = parametros;
                            this.Close();

                            //MessageBox.Show("CORRECTO");
                        }
                        else
                        {
                            MessageBox.Show("PASSWORD NO CORRESPONDE", "ERROR", MessageBoxButtons.OK);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty));
            }



        }

        private void btnEye_Click(object sender, EventArgs e)
        {

        }
    }
}
