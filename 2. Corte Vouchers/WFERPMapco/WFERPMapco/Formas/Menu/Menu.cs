using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFERPMapco.Objetos.Utilerias;

namespace WFERPMapco.Formas.Menu
{
    public partial class Menu : Form
    {

        Resultado resultado = new Resultado();
        Objetos.Datos.Modulos.Catalogos.Ejemplo Datos = new Objetos.Datos.Modulos.Catalogos.Ejemplo();
        Clases.MenuParametros parametrosModulo = new Clases.MenuParametros();
        string formActivoName = "";
        private readonly int SlideOpen = 263;
        private readonly int SlideClose = 65;
        private readonly int borderSize = 2;
        public static Panel panelworking = new Panel();
        public static Form form;
        private int NumeroEmpleado;
        private int idSucursal;
        private DataTable SucursalesUsuario;
        private DataTable PermisosUsuario;
        private DataTable ModulosUsuario;
      
      


        public Menu(Clases.MenuParametros parametros)
        {
            InitializeComponent();
            NumeroEmpleado =(int) parametros.NumeroEmpleado;
            idSucursal =(int) parametros.IdSucursal;
            parametrosModulo = parametros;
            // this.WindowState = FormWindowState.Maximized;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                resultado = Datos.obtenerEjemplo();
                if (!resultado.Error)
                {
                    MessageBox.Show("Todo bien:" + resultado.Datos.Tables[0].Rows[0][0]);
                }
                else
                {
                    MessageBox.Show("Todo mal:" + resultado.Error);
                }
            }
            catch (Exception ERR)
            {
                MessageBox.Show("Ha ocurrido un problema: " + ERR.Message.ToString());
            }
        }

        private void treeMap1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int panelSize = pnlMenu.Size.Width;

            FontAwesome.Sharp.IconButton btn = new FontAwesome.Sharp.IconButton();
            btn.Text = "Ejemplo";
            btn.Name = "1";

            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.IconColor = Color.Black;
            btn.IconChar = (FontAwesome.Sharp.IconChar)62489;
            btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // btn.bor
            btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);
            btn.Size = new Size(panelSize - 40, 30);
            btn.Click += botonEvento;

            pnlMenu.Controls.Add(btn);


            FlowLayoutPanel npanel = new FlowLayoutPanel();
            npanel.Visible = true;
            npanel.Name = "mnuPanel" + btn.Name;
            npanel.Size = new Size(panelSize - 41, 90);
            npanel.BackColor = Color.Black;
            npanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            npanel.AutoSize = true;
            npanel.AutoSizeMode = AutoSizeMode.GrowOnly;
            npanel.FlowDirection = FlowDirection.LeftToRight;
            npanel.AutoScroll = true;

            Button btn2 = new Button();
            btn2.Text = "HOLA MUNDO";
            btn2.Size = new Size(panelSize - 15, 30);
            npanel.Controls.Add(btn2);
            pnlMenu.Controls.Add(npanel);





        }

        private void btnSlide_Click(object sender, EventArgs e)
        {
            MenuBurger();
        }

        private void MenuBurger()
        {

            if (this.pnlMenu.Width > 200) //Collapse menu
            {

                foreach (FontAwesome.Sharp.IconButton menuButton in pnlMenu.Controls.OfType<FontAwesome.Sharp.IconButton>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Size = new Size(50, 40);
                    // menuButton.Padding = new Padding(0);
                }
                pnlMenu.Width = SlideClose;
                pnlHead.Width = SlideClose;
                btnSlide.Location = new Point(10, 5);
                pictureBox1.Visible = false;
                label1.Visible = false;
                tbcPages.Location = new Point(66, tbcPages.Location.Y);
                tbcPages.Width += 197;

                //   panelInfoUsuario.Visible = false;


            }
            else
            { //Expand menu
                foreach (Button menuButton in pnlMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    // menuButton.Padding = new Padding(10, 0, 0, 0);
                    menuButton.Size = new Size(248, 40);
                }
                btnSlide.Location = new Point(216, 9);
                pnlMenu.Width = SlideOpen;
                pnlHead.Width = SlideOpen;
                pictureBox1.Visible = true;
                label1.Visible = true;
                tbcPages.Location = new Point(263, tbcPages.Location.Y);
                tbcPages.Width -= 197;
                // panelInfoUsuario.Visible = true;
                // btnMenu.Dock = DockStyle.None;

            }



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //BUSCA INFORMACION DEL USUARIO, SUCURSALES Y PERMISOS DE MODULOS
            ObtenerMenuUsuario();
            ObtenerSucursalesUsuario();
            ObtenerPermisosUsuario();
        }

        private void pnlHead_Paint(object sender, PaintEventArgs e)
        {

        }

        private void botonEvento(object sender, EventArgs e)
        {
            try
            {
                FontAwesome.Sharp.IconButton btn = (FontAwesome.Sharp.IconButton)sender;
                btn.ContextMenuStrip.Visible = true;


                //Location= btn.PointToScreen
                int panelX = pnlMenu.Location.X;
                int panelY = pnlMenu.Location.Y;
                int botonw = btn.Width;
                int botonx = btn.Location.X;
                int botony = btn.Location.Y;
                int mnux = panelX + botonx + botonw;
                int mnuy = panelY + botony;
                Point npoin = new Point();
                npoin.X = mnux;
                npoin.Y = mnuy;
                btn.ContextMenuStrip.Show(PointToScreen(npoin));
                
                // MessageBox.Show(mnux+" -  "+ mnuy);


            }
            catch (Exception err)
            {
                MessageBox.Show("Ha ocurrido un problema: " + err.Message.ToString());
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void botonesPrincipales(DataTable dtMenu)
        {
            
            DataTable dtPrincipales = dtMenu.AsEnumerable().Where(r => r.Field<int>("idPrincipal") == 0).CopyToDataTable();

            if (dtPrincipales.Rows.Count > 0)
            {
                int panelSize = pnlMenu.Size.Width;

                foreach (DataRow dr in dtPrincipales.Rows)
                {


                    FontAwesome.Sharp.IconButton btn = new FontAwesome.Sharp.IconButton();
                    btn.Text = dr["Display"].ToString();
                    btn.Tag = dr["Display"].ToString();
                    btn.Name = dr["IdModulo"].ToString();

                    /*--------------------------------- T O O L  T I P----------------------------------------*/
                    ToolTip tt = new ToolTip();
                    tt.AutomaticDelay = 5000;
                    tt.InitialDelay = 1000;
                    tt.ReshowDelay = 500;
                    tt.ShowAlways = true;

                    tt.SetToolTip(btn, dr["Display"].ToString());

                    /*--------------------------------- A P A R I E N C I A ----------------------------------------*/
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);
                    btn.Size = new Size(248, 40);
                    btn.BackColor = System.Drawing.ColorTranslator.FromHtml("#003e87");
                    btn.ForeColor = Color.WhiteSmoke;
                    btn.Padding = new Padding(0);

                    /*---------------------------------I C O N O ----------------------------------------*/
                    btn.IconColor = Color.WhiteSmoke;
                    btn.IconChar = (FontAwesome.Sharp.IconChar)Convert.ToInt32(dr["Icon"].ToString());
                    btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    btn.IconSize = 38;

                    /*--------------------------------- E V  E N T O ----------------------------------------*/
                    btn.Click += botonEvento;

                    /*--------------------------------- M E N U  S T R I P----------------------------------------*/
                    ContextMenuStrip ms = new ContextMenuStrip();

                    //Los relacionados al menu principal
                    DataTable detalles;
                    int resdt = dtMenu.AsEnumerable().Where(r => r.Field<int>("idPrincipal") == Convert.ToInt32(dr["idModulo"])).Count();
                    if (resdt  > 0)
                    {
                        detalles = dtMenu.AsEnumerable().Where(r => r.Field<int>("idPrincipal") == Convert.ToInt32(dr["idModulo"])).CopyToDataTable();
                        /*-------------------------------- S U B  M E N U S --------------------------------*/
                        //LOS SUB MENUS
                        foreach (DataRow SM in detalles.Rows)
                        {

                            int submenus = dtMenu.AsEnumerable().Where(r => r.Field<int>("idPrincipal") == Convert.ToInt32(SM["idModulo"])).Count();


                            if (submenus > 0)
                            {
                                DataTable detalleSub = dtMenu.AsEnumerable().Where(r => r.Field<int>("idPrincipal") == Convert.ToInt32(SM["idModulo"])).CopyToDataTable();
                                ToolStripMenuItem submenu = new ToolStripMenuItem();


                                submenu.Size = new Size(248, 80);
                                submenu.Text = "           " + SM["Display"].ToString();

                                submenu.BackColor = Color.FromArgb(0, 62, 135);
                                submenu.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);
                                submenu.ForeColor = Color.WhiteSmoke;
                                (submenu.DropDown as ToolStripDropDownMenu).ShowImageMargin = false;

                                foreach (DataRow subd in detalleSub.Rows)
                                {
                                    FontAwesome.Sharp.IconToolStripButton tsb = new FontAwesome.Sharp.IconToolStripButton();
                                    tsb.Name = subd["idModulo"].ToString();
                                    tsb.Text = "   " + subd["Display"];
                                    tsb.Tag = "   " + subd["Modulo"];
                                    tsb.IconChar = FontAwesome.Sharp.IconChar.Gamepad;
                                    tsb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                                    tsb.IconColor = Color.WhiteSmoke;
                                    tsb.Size = new Size(248, 80);
                                    //tsb.IconSize = 50;
                                    tsb.BackColor = System.Drawing.ColorTranslator.FromHtml("#003e87");
                                    tsb.Height = 40;
                                    tsb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    tsb.Padding = new Padding(0);
                                    tsb.ForeColor = Color.WhiteSmoke;
                                    tsb.Click += botonEventoSM;
                                    tsb.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);

                                    submenu.DropDownItems.Add(tsb);
                                    submenu.DropDown.BackColor = System.Drawing.ColorTranslator.FromHtml("#003e87");


                                }


                                ms.Items.Add(submenu);
                            }
                            else
                            {

                                FontAwesome.Sharp.IconToolStripButton tsb = new FontAwesome.Sharp.IconToolStripButton();
                                tsb.Name = SM["idModulo"].ToString();
                                tsb.Text = "   " + SM["Display"];
                                tsb.Tag = "   " + SM["Modulo"];
                                tsb.IconChar = (FontAwesome.Sharp.IconChar)Convert.ToInt32(SM["Icon"]);
                                tsb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                                tsb.IconColor = Color.WhiteSmoke;
                                tsb.Size = new Size(248, 80);
                                tsb.IconSize = 50;
                                tsb.BackColor = System.Drawing.ColorTranslator.FromHtml("#003e87");
                                tsb.Height = 40;
                                tsb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                tsb.Click += botonEventoSM;
                                ms.Items.Add(tsb);


                            }
                        }


                    }







                    /*-------------------------------- A C I O N E S ---------------------------------*/


                    ms.ImageScalingSize = new Size(30, 30);
                    ms.Size = new Size(248, 80);
                    ms.BackColor = Color.FromArgb(0, 62, 135);
                    ms.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);
                    ms.ForeColor = Color.WhiteSmoke;
                    ms.ShowImageMargin = false;
                    btn.ContextMenuStrip = ms;

                    pnlMenu.Controls.Add(btn);
                }
            }
            else
            {
                MessageBox.Show("No se han encontrado modulos relacionados al usuario");
            }
        }

        private void botonEventoSM(object sender, EventArgs e)
        {
            try
            {
                FontAwesome.Sharp.IconToolStripButton btn = (FontAwesome.Sharp.IconToolStripButton)sender;

                int idMenu = Convert.ToInt32(btn.Name);
                string forma = btn.Tag.ToString();

                //string namespaceName = "WFERPMapco.Formas.";
                // var frm = Activator.CreateInstance(Type.GetType(namespaceName)) as Form;
                //Form frm =  (Form)(Assembly.GetExecutingAssembly().CreateInstance(namespaceName));
                //frm.Show();


                //se limpia datatable de permisos de clase de parametros que se enviara al modulo
                parametrosModulo.DtPermisos = null;

                //Busca los permisos del modulo en el listado de permisos
                parametrosModulo.DtPermisos = PermisosUsuario.AsEnumerable()
                                                .Where(r => r.Field<int>("idModulo") == idMenu)
                                                .CopyToDataTable();

                

                string formtocall = btn.Tag.ToString();
                System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                Type[] types = myAssembly.GetTypes();
                foreach (Type type in types)
                {
                    if (type.BaseType.FullName == "System.Windows.Forms.Form")
                    {
                        if (type.Name == formtocall.Trim())
                        {
                            var form = Activator.CreateInstance(Type.GetType(type.FullName), parametrosModulo) as Form;
                            addPage(form);
                            break;
                        }
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Ha ocurrido un problema: " + err.Message.ToString());
            }
        }

        private void addPage(Form frm)
        {

            TabPage tb = new TabPage(frm.Text + "      ");
            frm.TopLevel = false;
            frm.Parent = tb;
            frm.Visible = true;
            frm.Dock = DockStyle.Fill;

        
            tbcPages.TabPages.Add(tb);
            tbcPages.SelectedTab=tb;
            


        }

        private void tbcPages_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                var tabPage = this.tbcPages.TabPages[e.Index];
                var tabRect = this.tbcPages.GetTabRect(e.Index);
                tabRect.Inflate(-2, -2);
              //  if (e.Index == this.tbcPages.TabCount -1) // Add button to the last TabPage only
              //  {
                    var closeImage = new Bitmap(Properties.Resources.close);
                    e.Graphics.DrawImage(closeImage,
                        (tabRect.Right - closeImage.Width),
                        tabRect.Top + (tabRect.Height - closeImage.Height) / 2);
                    TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                        tabRect, tabPage.ForeColor, TextFormatFlags.Left);
               // }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void tbcPages_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void tbcPages_MouseDown(object sender, MouseEventArgs e)
        {
            for (var i = 0; i < this.tbcPages.TabPages.Count; i++)
            {
                var tabRect = this.tbcPages.GetTabRect(i);
                tabRect.Inflate(-2, -2);
                var closeImage = new Bitmap(Properties.Resources.close);
                var imageRect = new Rectangle(
                    (tabRect.Right - closeImage.Width),
                    tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
                    closeImage.Width,
                    closeImage.Height);
                if (imageRect.Contains(e.Location))
                {
                    this.tbcPages.TabPages.RemoveAt(i);
                    break;
                }
            }
        }

        private void ObtenerMenuUsuario()
        {
            Resultado resultado = new Resultado();
            Objetos.Datos.Modulos.Capturas.Menu datos = new Objetos.Datos.Modulos.Capturas.Menu();

            try
            {
                int numeroempleado = NumeroEmpleado;
                resultado = datos.ObtenerMenu(NumeroEmpleado,idSucursal );
                if (!resultado.Error)
                {
                    if (resultado.Datos.Tables[0].Rows.Count > 0)
                    {
                        ModulosUsuario = resultado.Datos.Tables[0];
                        botonesPrincipales(resultado.Datos.Tables[0]);
                    }
                    else
                    {
                        Alertas.Show("No se encontraron permisos de acceso en esta sucursal","No hay permisos en Sucursal",Alertas.Buttons.OK);
                    }
                }
                else
                {
                    Alertas.Show(resultado.MensajeError.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty), "Error al cargar Menu", Alertas.Buttons.OK, Alertas.Icon.Error);
                }
            }
            catch(Exception err)
            {
                Alertas.Show(err.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty), "Error al cargar Menu", Alertas.Buttons.OK, Alertas.Icon.Error);
            }
        }

        private void ObtenerSucursalesUsuario()
        {
            Resultado resultado = new Resultado();
            Objetos.Datos.Modulos.Capturas.Menu datos = new Objetos.Datos.Modulos.Capturas.Menu();

            try
            {
                resultado = datos.obtenerSucursalesUsuario(NumeroEmpleado);
                if (!resultado.Error)
                {
                    if (resultado.Datos.Tables[0].Rows.Count > 0)
                    {
                        SucursalesUsuario = resultado.Datos.Tables[0];
                        parametrosModulo.SucursalesUsuario = SucursalesUsuario;
                    }
                }
                else
                {
                    Alertas.Show(resultado.MensajeError.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty), "Error al cargar Menu", Alertas.Buttons.OK, Alertas.Icon.Error);
                }
            }
            catch (Exception err)
            {
                Alertas.Show(err.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty), "Error al cargar Menu", Alertas.Buttons.OK, Alertas.Icon.Error);
            }
        }

        private void CargaParametros()
        {

        }

        private void ObtenerPermisosUsuario()
        {
            Resultado resultado = new Resultado();
            Objetos.Datos.Modulos.Capturas.Menu datos = new Objetos.Datos.Modulos.Capturas.Menu();

            try
            {
                resultado = datos.obtenerPermisosUsuario(NumeroEmpleado,idSucursal);
                if (!resultado.Error)
                {
                    if (resultado.Datos.Tables[0].Rows.Count > 0)
                    {
                        PermisosUsuario = resultado.Datos.Tables[0];
                    }
                }
                else
                {
                    Alertas.Show(resultado.MensajeError.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty), "Error al cargar permisos", Alertas.Buttons.OK, Alertas.Icon.Error);
                }
            }
            catch (Exception err)
            {
                Alertas.Show(err.Message.Replace("'", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty), "Error al cargar permisos", Alertas.Buttons.OK, Alertas.Icon.Error);
            }
        }
    }
}
