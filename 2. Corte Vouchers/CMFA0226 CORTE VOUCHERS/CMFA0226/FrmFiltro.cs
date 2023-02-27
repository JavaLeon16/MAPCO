using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.VisualBasic;
using System.IO;
using System.Reflection;
using CMFA0226_BL;


namespace CMFA0226
{
    public partial class FrmFiltro : Form
    {
        public string NomUsu;
        public string RFC;
        public string Domicilio;
        public string NombEmpresa;
        string NumEmp, ne;
        string stringToPrint;

        public DataTable DatosEncabezado;
        public DataTable DatosDetalle;
        public DataTable DatosEmpresa;

        List<ClsVouchers> LstCajas;

        string Constring = "";

        public FrmFiltro()
        {
            InitializeComponent();

            #region Variables
            string NomExe;
            string Ip;
            string Fecha;
            string CodUsu;
            string Nivel;
          
            bool VALIDA;
            
            #endregion

            try
            {
                //Auto 
                //string[] Var = Microsoft.VisualBasic.Interaction.Command().Split(',');

                ////Manual      
                //Constring = "CMFA0225,172.16.34.1,53,20/02/20,995,99,SISTEMAS,05277,31,1";
                Constring = "CMFA0225,127.0.0.1,mapco,20/02/20,995,99,SISTEMAS,05277,31,1";
                string[] Var = Constring.Split(',');


                if (Var[0].ToString().Trim() == "")
                {
                    VALIDA = true;
                }
                else
                {
                    VALIDA = false;
                    NomExe = Var[0].ToString().Trim();
                    Ip = Var[1].ToString().Trim();
                    NumEmp = Var[2].ToString().Trim();
                    slblVersion.Text = ShowAssemblyVersion(typeof(FrmFiltro));
                    ne = Var[2].ToString().Trim();
                    Fecha = Var[3].ToString().Trim();
                    CodUsu = Var[4].ToString().Trim();
                    Nivel = Var[5].ToString().Trim();
                    NomUsu = Var[6].ToString().Trim();

                    //Conexion MySQL <Sucursal Local>
                    //**************************
                    //Constring = "server=" + Ip + ";uid=user;pwd=mapcouser;database=" + NumEmp + Fecha.Substring
                    Constring = "server=" + Ip + ";uid=root;pwd=root;database=" + NumEmp; //*/ + Fecha.Substring(Fecha.LastIndexOf('/') + 1, 2).ToString().Trim() + "BASE; Allow Zero Datetime=True";

                    //Conexion sqlserver
                    //Constring = "server=" + Ip + ";uid=sa;pwd=sa;database=" + NumEmp + Fecha.Substring
                    //(Fecha.LastIndexOf('/') + 1, 2).ToString().Trim() + "BASE";// Allow Zero Datetime=True";

                    ////**New connection string en el CONFIGURATIONMANAGER**                  
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.ConnectionStrings.ConnectionStrings.Remove("CMFA0226.Properties.Settings.CMFA0226_Conn00");
                    ConnectionStringSettings connStrSettings = new ConnectionStringSettings

                    ("CMFA0226.Properties.Settings.CMFA0226_Conn00", Constring.Trim());
                    config.ConnectionStrings.ConnectionStrings.Add(connStrSettings);
                    config.Save(ConfigurationSaveMode.Full);
                    ConfigurationManager.RefreshSection("connectionStrings");


                    //Cargar datos de la Sucursal Acceso                        
                    DataSet DSEMPR = new DataSet();
                    DSEMPR.Tables.Add(CMFA0226_BL.ClsSucursal.ListSucursalId(NumEmp));
                    for (int i = 0; i < DSEMPR.Tables[0].Rows.Count; i++)
                    {
                        NombEmpresa = DSEMPR.Tables[0].Rows[i]["Suc"].ToString();
                        NumEmp = NumEmp + " - " + NombEmpresa;
                        RFC = DSEMPR.Tables[0].Rows[i]["RFC"].ToString();
                        Domicilio = DSEMPR.Tables[0].Rows[i]["Dir"].ToString() + DSEMPR.Tables[0].Rows[i]["Pob"].ToString();
                    }
                }
                ClsVouchers.cadenaConexion = Constring;
                LstCajas = ClsVouchers.ListTiposMov();
                clsVouchersBindingSource.DataSource = LstCajas;
                slblUsuarioexee.Text = NomUsu;
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private string ShowAssemblyVersion(Type type)
        {
            Assembly asm = Assembly.GetAssembly(type);
            string objVersion = "";
            if (asm != null)
            {
                AssemblyName asmName = asm.GetName();
                objVersion = String.Format("Version={1}", asmName.Name, asmName.Version);
                return objVersion;
            }
            return objVersion;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btngenerar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal totalcreditoventas = 0;
                decimal totalcreditocancelacion=0;

                decimal totaldebitoventas=0;
                decimal totaldebitocancelacion=0;

                decimal totalamericaventas=0;
                decimal totalamericacancelacion=0;

                int contadorventasccredito=0;
                int contadorcancelacredito=0;

                int contadorventasdebito=0;
                int contadorcanceladebito=0;

                decimal totalventasgeneral = 0;
                decimal totalcancelaciongeneral = 0;

                int contadoramericaventas=0;
                int contadoramericacancelaciones=0;
                int contadortotalventas=0;
                int contadortotalcancelaciones=0;

                ClsVouchers.cadenaConexion = Constring;//Mandamos Cadena de conexion
                DatosEmpresa = ClsVouchers.empresa(ne);//Traemos datos de empresa

                ClsVouchers.cadenaConexion = Constring;//Mandamos Cadena de conexion

                if (ImprimecheckBox.Checked == true)
                {
                    DatosEncabezado = ClsVouchers.EncabezadoVoucher(dtpFechaInicio.Value, Convert.ToInt32(clsVouchersComboBox.SelectedValue));//EncabezadoVoucher
                    ClsVouchers.cadenaConexion = Constring;
                    DatosDetalle = ClsVouchers.VouchersDetalle(dtpFechaInicio.Value, Convert.ToInt32(clsVouchersComboBox.SelectedValue));//DetalleVoucher
                }
                else
                {
                    DatosEncabezado = ClsVouchers.EncabezadoVoucherN(dtpFechaInicio.Value, Convert.ToInt32(clsVouchersComboBox.SelectedValue));//EncabezadoVoucher
                    ClsVouchers.cadenaConexion = Constring;
                    DatosDetalle = ClsVouchers.VouchersDetalleN(dtpFechaInicio.Value, Convert.ToInt32(clsVouchersComboBox.SelectedValue));//DetalleVoucher
                }

                if (DatosEmpresa.Rows.Count == 0)
                { MessageBox.Show("No se encontraron Datos de la empresa", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                if (DatosEncabezado.Rows.Count == 0)
                { MessageBox.Show("No se encontraron Datos del encabezado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                if (DatosDetalle.Rows.Count == 0)
                { MessageBox.Show("No se encontraron Datos del detalle", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                //impresion en pantalla
                if (ImprimecheckBox.Checked == true)
                {
                    try
                    {
                        FrmVisor reporte = new FrmVisor(1);
                        reporte.fecha = dtpFechaInicio.Value.ToString("dd/MM/yyyy");
                        reporte.SUCURSAL = NombEmpresa + "       Caja: "+clsVouchersComboBox.Text;

                        if (DatosDetalle.Rows.Count != 0)
                        {
                            reporte.tabla = DatosDetalle;
                            reporte.Show();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    catch (Exception Ex) { MessageBox.Show(Ex.Message); }
                }
                else
                {
                    DataTable impresora = ClsVouchers.impresora(Convert.ToString(clsVouchersComboBox.SelectedValue));

                    if (impresora.Rows[0]["RutaImpresion"].ToString() == "")
                    { 
                        MessageBox.Show("No se encontro impresora registrada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                        return; 
                    }
                    else
                    {
                        try
                        {
                            //System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("CMD.EXE", @"/rundll32 printui.dll,PrintUIEntry /Gw /in /n " + @"\\172.16.3.137\Karentiketerax");
                            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("CMD.EXE", @"/rundll32 printui.dll,PrintUIEntry /Gw /in /n " + impresora.Rows[0]["RutaImpresion"].ToString());
                            info.Verb = "open";
                            System.Diagnostics.Process.Start(info);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se hizo conexion con la impresora.\n\rComuniquese al Departamento de Sistemas.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\ERP\\MyFile.txt");
                    sw.WriteLine(((char)0x1b) + "!" + ((char)17)); //INICIALIZA EL AUMENTO DE TAMAÑO EN LETRA
                    sw.WriteLine("BANORTE".PadLeft(((40 - ("BANORTE".Length)) / 2) + ("BANORTE".Length), ' '));  //LINEA(S) DE TEXTO

                    sw.WriteLine(((char)0x1b) + "!" + ((char)0)); //DESACTIVA EL AUMENTO DE TAMAÑO DE LETRA
                    sw.WriteLine(((char)0x1b) + "@"); //INICIALIZA POR DEFAULT LA IMPRESORA
                    sw.WriteLine(DatosEncabezado.Rows[0]["fecha"].ToString().PadLeft(((40 - (DatosEncabezado.Rows[0]["fecha"].ToString().Length)) / 2) + (DatosEncabezado.Rows[0]["fecha"].ToString().Length), ' '));
                    sw.WriteLine(char.ConvertFromUtf32(13) + char.ConvertFromUtf32(10)); //linea en blanco

                    #region Ticket
                    //*** encabezado
                    sw.WriteLine(DatosEmpresa.Rows[0]["nom"].ToString().PadLeft(((40 - (DatosEmpresa.Rows[0]["nom"].ToString().Length)) / 2) + (DatosEmpresa.Rows[0]["nom"].ToString().Length), ' '));
                    sw.WriteLine(DatosEmpresa.Rows[0]["suc"].ToString().PadLeft(((40 - (DatosEmpresa.Rows[0]["suc"].ToString().Length)) / 2) + (DatosEmpresa.Rows[0]["suc"].ToString().Length), ' '));
                    sw.WriteLine(DatosEmpresa.Rows[0]["rfc"].ToString().PadLeft(((40 - (DatosEmpresa.Rows[0]["rfc"].ToString().Length)) / 2) + (DatosEmpresa.Rows[0]["rfc"].ToString().Length), ' '));
                    sw.WriteLine(DatosEmpresa.Rows[0]["Direccion"].ToString().PadLeft(((40 - (DatosEmpresa.Rows[0]["Direccion"].ToString().Length)) / 2) + (DatosEmpresa.Rows[0]["Direccion"].ToString().Length), ' '));
                    sw.WriteLine(DatosEmpresa.Rows[0]["tel"].ToString().PadLeft(((40 - (DatosEmpresa.Rows[0]["tel"].ToString().Length)) / 2) + (DatosEmpresa.Rows[0]["tel"].ToString().Length), ' '));
                    sw.WriteLine(DatosEncabezado.Rows[0]["idcaja"].ToString().PadLeft(((40 - (DatosEncabezado.Rows[0]["idcaja"].ToString().Length)) / 2) + (DatosEncabezado.Rows[0]["idcaja"].ToString().Length), ' '));
                    sw.WriteLine(char.ConvertFromUtf32(13) + char.ConvertFromUtf32(10)); //linea en blanco

                    sw.WriteLine(((char)0x1b) + "!" + ((char)17)); //INICIALIZA EL AUMENTO DE TAMAÑO EN LETRA
                    sw.WriteLine("TOTALIZACION".PadLeft(((40 - ("TOTALIZACION".Length)) / 2) + ("TOTALIZACION".Length), ' '));  //LINEA(S) DE TEXTO
                    sw.WriteLine(((char)0x1b) + "!" + ((char)0)); //DESACTIVA EL AUMENTO DE TAMAÑO DE LETRA
                    sw.WriteLine(((char)0x1b) + "@"); //INICIALIZA POR DEFAULT LA IMPRESORA

                    string a = string.Empty;
                    for (int i = 0; i < DatosEncabezado.Rows.Count; i++)
                    {
                        if (DatosEncabezado.Rows[i]["Descripcion"].ToString() == "CREDITO")
                        {
                            if (DatosEncabezado.Rows[i]["tipo"].ToString() == "VENTA")
                            {
                                totalcreditoventas = Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]);
                                contadorventasccredito = Convert.ToInt32(DatosEncabezado.Rows[i]["cstatus"]);
                                sw.WriteLine("CREDITO".PadLeft(((40 - ("CREDITO".Length)) / 2) + ("CREDITO".Length), ' '));

                                sw.WriteLine("               " + " NUMERO" + "         " + "  IMPORTE");
                                a = "VENTA           ";
                                a = a + DatosEncabezado.Rows[i]["cstatus"].ToString().PadLeft(((6 - (DatosEncabezado.Rows[i]["cstatus"].ToString().Length))) + (DatosEncabezado.Rows[i]["cstatus"].ToString().Length), ' ');
                                a = a + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"])).ToString("#,##0.00").PadLeft(((18 - (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length))) + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length), ' ');
                                sw.WriteLine(a);
                                a = string.Empty;
                            }
                            if (DatosEncabezado.Rows[i]["tipo"].ToString() == "CANCELACION")
                            {
                                totalcreditocancelacion = Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]);
                                contadorcancelacredito = Convert.ToInt32(DatosEncabezado.Rows[i]["cstatus"]);

                                a = "CANCELACION     ";
                                a = a + DatosEncabezado.Rows[i]["cstatus"].ToString().PadLeft(((6 - (DatosEncabezado.Rows[i]["cstatus"].ToString().Length))) + (DatosEncabezado.Rows[i]["cstatus"].ToString().Length), ' ');
                                a = a + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"])).ToString("#,##0.00").PadLeft(((18 - (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length))) + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length), ' ');
                                sw.WriteLine(a);
                                a = string.Empty;
                                //sw.WriteLine("  CANCELACION    "+ DatosEncabezado.Rows[i]["cstatus"] + "          "+  totalcreditocancelacion.ToString("#,##0.00"));

                                a = "TOTAL           ";
                                a = a + (contadorventasccredito + contadorcancelacredito).ToString().PadLeft(((6 - ((contadorventasccredito + contadorcancelacredito).ToString().Length))) + ((contadorventasccredito + contadorcancelacredito).ToString().Length), ' ');
                                a = a + (totalcreditoventas).ToString("#,##0.00").PadLeft(((18 - (totalcreditoventas.ToString("#,##0.00").Length))) + (totalcreditoventas.ToString("#,##0.00").Length), ' ');
                                sw.WriteLine(a);
                                a = string.Empty;
                                // sw.WriteLine("  TOTAL          " + (contadorventasccredito + contadorcancelacredito) + "         " + (totalcreditoventas - totalcreditocancelacion).ToString("#,##0.00"));
                            }

                        }
                        if (DatosEncabezado.Rows[i]["Descripcion"].ToString() == "DEBITO")
                        {
                            if (DatosEncabezado.Rows[i]["tipo"].ToString() == "VENTA")
                            {
                                totaldebitoventas = Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]);
                                contadorventasdebito = Convert.ToInt32(DatosEncabezado.Rows[i]["cstatus"]);
                                sw.WriteLine("DEBITO".PadLeft(((40 - ("DEBITO".Length)) / 2) + ("DEBITO".Length), ' '));

                                a = "VENTA           ";
                                a = a + DatosEncabezado.Rows[i]["cstatus"].ToString().PadLeft(((6 - (DatosEncabezado.Rows[i]["cstatus"].ToString().Length))) + (DatosEncabezado.Rows[i]["cstatus"].ToString().Length), ' ');
                                a = a + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"])).ToString("#,##0.00").PadLeft(((18 - (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length))) + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length), ' ');
                                sw.WriteLine(a);
                                a = string.Empty;

                                //sw.WriteLine("  VENTA          " + DatosEncabezado.Rows[i]["cstatus"]+"         " + totaldebitoventas.ToString("#,##0.00"));
                            }
                            if (DatosEncabezado.Rows[i]["tipo"].ToString() == "CANCELACION")
                            {
                                totaldebitocancelacion = Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]);
                                contadorcanceladebito = Convert.ToInt32(DatosEncabezado.Rows[i]["cstatus"]);

                                a = "CANCELACION     ";
                                a = a + DatosEncabezado.Rows[i]["cstatus"].ToString().PadLeft(((6 - (DatosEncabezado.Rows[i]["cstatus"].ToString().Length))) + (DatosEncabezado.Rows[i]["cstatus"].ToString().Length), ' ');
                                a = a + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"])).ToString("#,##0.00").PadLeft(((18 - (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length))) + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length), ' ');
                                sw.WriteLine(a);
                                a = string.Empty;
                                //sw.WriteLine("  CANCELACION    "  + DatosEncabezado.Rows[i]["cstatus"] +"          "+ totaldebitocancelacion.ToString("#,##0.00"));

                                a = "TOTAL           ";
                                a = a + (contadorventasdebito + contadorcanceladebito).ToString().PadLeft(((6 - (contadorventasdebito + contadorcanceladebito.ToString().Length))) + (contadorventasdebito + contadorcanceladebito.ToString().Length), ' ');
                                a = a + (totaldebitoventas).ToString("#,##0.00").PadLeft(((18 - (totaldebitoventas.ToString("#,##0.00").Length))) + (totaldebitoventas.ToString("#,##0.00").Length), ' ');
                                sw.WriteLine(a);
                                a = string.Empty;

                                //sw.WriteLine("  TOTAL          " + (contadorventasdebito + totaldebitocancelacion) + "         " +(totaldebitoventas - totaldebitocancelacion).ToString("#,##0.00"));
                            }
                        }
                        if (DatosEncabezado.Rows[i]["Descripcion"].ToString() == "AMERICAN EXPRESS")
                        {
                            if (DatosEncabezado.Rows[i]["tipo"].ToString() == "VENTA")
                            {
                                totalamericaventas = Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]);
                                contadoramericaventas = Convert.ToInt32(DatosEncabezado.Rows[i]["cstatus"]);
                                sw.WriteLine("AMERICAN EXPRESS".PadLeft(((40 - ("AMERICAN EXPRESS".Length)) / 2) + ("AMERICAN EXPRESS".Length), ' '));

                                a = "VENTA           ";
                                a = a + DatosEncabezado.Rows[i]["cstatus"].ToString().PadLeft(((6 - (DatosEncabezado.Rows[i]["cstatus"].ToString().Length))) + (DatosEncabezado.Rows[i]["cstatus"].ToString().Length), ' ');
                                a = a + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"])).ToString("#,##0.00").PadLeft(((18 - (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length))) + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length), ' ');
                                sw.WriteLine(a);
                                a = string.Empty;
                                //sw.WriteLine("  VENTA          " + DatosEncabezado.Rows[i]["cstatus"] +"          "+totalamericaventas.ToString("#,##0.00"));
                            }
                            if (DatosEncabezado.Rows[i]["tipo"].ToString() == "CANCELACION")
                            {
                                contadoramericacancelaciones = Convert.ToInt32(DatosEncabezado.Rows[i]["cstatus"]);
                                totalamericacancelacion = Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]);

                                a = "CANCELACION     ";
                                a = a + DatosEncabezado.Rows[i]["cstatus"].ToString().PadLeft(((6 - (DatosEncabezado.Rows[i]["cstatus"].ToString().Length))) + (DatosEncabezado.Rows[i]["cstatus"].ToString().Length), ' ');
                                a = a + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"])).ToString("#,##0.00").PadLeft(((18 - (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length))) + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length), ' ');
                                sw.WriteLine(a);
                                a = string.Empty;
                                //sw.WriteLine("  CANCELACION    "  + DatosEncabezado.Rows[i]["cstatus"]+"          " + totalamericacancelacion.ToString("#,##0.00"));

                                a = "TOTAL           ";
                                a = a + (contadoramericaventas + contadoramericacancelaciones).ToString().PadLeft(((6 - (contadoramericaventas + contadoramericacancelaciones.ToString().Length))) + (contadoramericaventas + contadoramericacancelaciones.ToString().Length), ' ');
                                a = a + (totalamericaventas).ToString("#,##0.00").PadLeft(((18 - (totalamericaventas.ToString("#,##0.00").Length))) + (totalamericaventas.ToString("#,##0.00").Length), ' ');
                                sw.WriteLine(a);
                                a = string.Empty;
                                //sw.WriteLine("  TOTAL          " + (contadoramericaventas + contadoramericacancelaciones) + "          " + (totalamericaventas - totalamericacancelacion).ToString("#,##0.00"));
                            }
                        }
                        if (DatosEncabezado.Rows[i]["Descripcion"].ToString() == "Total")
                        {
                            if (DatosEncabezado.Rows[i]["tipo"].ToString() == "VENTA")
                            {
                                contadortotalventas = contadorventasccredito + contadorventasdebito + contadoramericaventas;
                                totalventasgeneral = Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]);
                                sw.WriteLine("TOTAL GENERAL".PadLeft(((40 - ("TOTAL GENERAL".Length)) / 2) + ("TOTAL GENERAL".Length), ' '));

                                a = "VENTA           ";
                                a = a + (contadortotalventas).ToString().PadLeft(((6 - (contadortotalventas.ToString().Length))) + (contadortotalventas.ToString().Length), ' ');
                                a = a + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"])).ToString("#,##0.00").PadLeft(((18 - (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length))) + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length), ' ');
                                sw.WriteLine(a);
                                a = string.Empty;
                                //sw.WriteLine("  VENTA          " + contadortotalventas + "         " + totalventasgeneral.ToString("#,##0.00"));
                            }
                            if (DatosEncabezado.Rows[i]["tipo"].ToString() == "CANCELACION")
                            {
                                contadortotalcancelaciones = contadorcancelacredito + contadorcanceladebito + contadoramericacancelaciones;
                                totalcancelaciongeneral = Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]);

                                a = "CANCELACION     ";
                                a = a + (contadortotalcancelaciones).ToString().PadLeft(((6 - (contadortotalcancelaciones.ToString().Length))) + (contadortotalcancelaciones.ToString().Length), ' ');
                                a = a + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"])).ToString("#,##0.00").PadLeft(((18 - (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length))) + (Convert.ToDecimal(DatosEncabezado.Rows[i]["importe"]).ToString("#,##0.00").Length), ' ');
                                sw.WriteLine(a);
                                a = string.Empty;
                                //sw.WriteLine("  CANCELACION    " + contadortotalcancelaciones + "         " + totalcancelaciongeneral.ToString("#,##0.00"));

                                a = "TOTAL           ";
                                a = a + (contadortotalventas + contadortotalcancelaciones).ToString().PadLeft(((6 - (contadortotalventas + contadortotalcancelaciones.ToString().Length))) + (contadortotalventas + contadortotalcancelaciones.ToString().Length), ' ');
                                a = a + (totalventasgeneral).ToString("#,##0.00").PadLeft(((18 - (totalventasgeneral.ToString("#,##0.00").Length))) + (totalventasgeneral.ToString("#,##0.00").Length), ' ');
                                sw.WriteLine(a);
                                a = string.Empty;
                                //sw.WriteLine("  TOTAL          " + (contadortotalventas + contadortotalcancelaciones) + "         " + (totalventasgeneral - totalcancelaciongeneral).ToString("#,##0.00"));
                            }
                        }
                    }

                    sw.WriteLine(((char)0x1b) + "!" + ((char)17)); //INICIALIZA EL AUMENTO DE TAMAÑO EN LETRA
                    sw.WriteLine("DETALLE".PadLeft(((40 - ("DETALLE".Length)) / 2) + ("DETALLE".Length), ' '));  //LINEA(S) DE TEXTO
                    sw.WriteLine(((char)0x1b) + "!" + ((char)0)); //DESACTIVA EL AUMENTO DE TAMAÑO DE LETRA
                    sw.WriteLine(((char)0x1b) + "@"); //INICIALIZA POR DEFAULT LA IMPRESORA

                    sw.WriteLine(((char)0x1b) + "!" + ((char)17)); //INICIALIZA EL AUMENTO DE TAMAÑO EN LETRA
                    sw.WriteLine("SIN PROMOCIONES".PadLeft(((40 - ("SIN PROMOCIONES".Length)) / 2) + ("SIN PROMOCIONES".Length), ' '));  //LINEA(S) DE TEXTO
                    sw.WriteLine(((char)0x1b) + "!" + ((char)0)); //DESACTIVA EL AUMENTO DE TAMAÑO DE LETRA
                    sw.WriteLine(((char)0x1b) + "@"); //INICIALIZA POR DEFAULT LA IMPRESORA
                    sw.WriteLine("        " + "    No.TARJETA " + "     " + "     IMPORTE");
                    int varpro = 0;
                    for (int i = 0; i < DatosDetalle.Rows.Count; i++)
                    {
                        if (DatosDetalle.Rows[i]["ESPROMOCION"].ToString() == "SIN PROMOCION")
                        {
                            a = a + DatosDetalle.Rows[i]["statusdetalle"].ToString().PadRight(((16 - (DatosDetalle.Rows[i]["statusdetalle"].ToString().Length))) + (DatosDetalle.Rows[i]["statusdetalle"].ToString().Length), ' ');
                            a = a + DatosDetalle.Rows[i]["NumeroTarjeta"].ToString().PadLeft(((6 - (DatosDetalle.Rows[i]["NumeroTarjeta"].ToString().Length))) + (DatosDetalle.Rows[i]["NumeroTarjeta"].ToString().Length), ' ');
                            a = a + (Convert.ToDecimal(DatosDetalle.Rows[i]["importe"])).ToString("#,##0.00").PadLeft(((18 - (Convert.ToDecimal(DatosDetalle.Rows[i]["importe"]).ToString("#,##0.00").Length))) + (Convert.ToDecimal(DatosDetalle.Rows[i]["importe"]).ToString("#,##0.00").Length), ' ');
                            sw.WriteLine(a);
                            a = string.Empty;

                            // sw.WriteLine(DatosDetalle.Rows[i]["statusdetalle"].ToString() + "      " + DatosDetalle.Rows[i]["NumeroTarjeta"].ToString() + "      " + (Convert.ToDecimal(DatosDetalle.Rows[i]["importe"])).ToString("#,##0.00"));
                        }
                        if (DatosDetalle.Rows[i]["ESPROMOCION"].ToString() == "PROMOCION")
                        {
                            varpro = 1;
                        }
                    }

                    if (varpro == 1)
                    {
                        sw.WriteLine(((char)0x1b) + "!" + ((char)17)); //INICIALIZA EL AUMENTO DE TAMAÑO EN LETRA
                        sw.WriteLine("CON PROMOCIONES".PadLeft(((40 - ("CON PROMOCIONES".Length)) / 2) + ("CON PROMOCIONES".Length), ' '));  //LINEA(S) DE TEXTO
                        sw.WriteLine(((char)0x1b) + "!" + ((char)0)); //DESACTIVA EL AUMENTO DE TAMAÑO DE LETRA
                        sw.WriteLine(((char)0x1b) + "@"); //INICIALIZA POR DEFAULT LA IMPRESORA
                        sw.WriteLine("        " + "    No.TARJETA " + "     " + "     IMPORTE");
                        for (int i = 0; i < DatosDetalle.Rows.Count; i++)
                        {
                            if (DatosDetalle.Rows[i]["ESPROMOCION"].ToString() == "PROMOCION")
                            {

                                a = a + DatosDetalle.Rows[i]["statusdetalle"].ToString().PadRight(((16 - (DatosDetalle.Rows[i]["statusdetalle"].ToString().Length))) + (DatosDetalle.Rows[i]["statusdetalle"].ToString().Length), ' ');
                                a = a + DatosDetalle.Rows[i]["NumeroTarjeta"].ToString().PadLeft(((6 - (DatosDetalle.Rows[i]["NumeroTarjeta"].ToString().Length))) + (DatosDetalle.Rows[i]["NumeroTarjeta"].ToString().Length), ' ');
                                a = a + (Convert.ToDecimal(DatosDetalle.Rows[i]["importe"])).ToString("#,##0.00").PadLeft(((18 - (Convert.ToDecimal(DatosDetalle.Rows[i]["importe"]).ToString("#,##0.00").Length))) + (Convert.ToDecimal(DatosDetalle.Rows[i]["importe"]).ToString("#,##0.00").Length), ' ');
                                sw.WriteLine(a);
                                a = string.Empty;

                                //sw.WriteLine(DatosDetalle.Rows[i]["statusdetalle"].ToString() + "      " + DatosDetalle.Rows[i]["NumeroTarjeta"].ToString() + "      " + (Convert.ToDecimal(DatosDetalle.Rows[i]["importe"])).ToString("#,##0.00"));
                            }
                        }
                    }
                    sw.WriteLine(char.ConvertFromUtf32(13) + char.ConvertFromUtf32(10)); //linea en blanco
                    sw.WriteLine("FIN DEL REPORTE".PadLeft(((40 - ("FIN DEL REPORTE".Length)) / 2) + ("FIN DEL REPORTE".Length), ' '));  //LINEA(S) DE TEXTO

                    sw.WriteLine(char.ConvertFromUtf32(13) + char.ConvertFromUtf32(10) + ((char)0x1d) + "V" + ((char)66) + ((char)0)); //corte
                    sw.Close();

                    #endregion
                    
                    //Printers.RawPrinter OBJ = new Printers.RawPrinter(impresora.Rows[0]["RutaImpresion"].ToString());
                    //Printers.RawPrinter OBJ = new Printers.RawPrinter(@"\\172.16.3.137\Karentiketerax");
                    //OBJ.SendFileToPrinter("C:\\ERP\\MyFile.txt");

                    System.IO.StreamWriter sbat = new System.IO.StreamWriter("C:\\ERP\\MyFile.bat");
                    sbat.WriteLine(@"Copy C:\ERP\MyFile.txt " + @"\\MAPCO1259-PC\TicketMercadotecnia");
                    //sbat.WriteLine(@"Copy C:\ERP\MyFile.txt " + impresora.Rows[0]["RutaImpresion"].ToString());
                    sbat.Close();
                    //Printers.RawPrinter OBJ = new Printers.RawPrinter(@"\\172.16.3.127\pticket");
                    System.Diagnostics.Process.Start(@"C:\ERP\MyFile.bat");

                    MessageBox.Show("La impresion se ha realizado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                progressBar1.Visible = true;
                progressBar1.Value = 100;                
                progressBar1.Value = 0;
                progressBar1.Visible = false;
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ClsVouchers.cadenaConexion = Constring;//Mandamos Cadena de conexion

            //obtenemos la ruta de los exes en el servidor en la tabla config donde ide=Rutaexes
            DataTable RUTAEXE;//Traemos Ruta EXE.
            RUTAEXE = ClsVouchers.RutaExe();

            DataTable VERSIONEXE;//Traemos Version del Exe
            VERSIONEXE = ClsVouchers.VersionExe();

            if (RUTAEXE.Rows.Count == 0)//VALIDAMOS QUE HAYA REGISTROS
            { MessageBox.Show("No se encontro Ruta del Exe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (VERSIONEXE.Rows.Count == 0)//VALIDAMOS QUE HAYA REGISTRO
            { MessageBox.Show("No hay registro del exe en la tabla revi", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            //preguntamos si existe el archivito inf de nuestra aplicacion
            if (System.IO.File.Exists(RUTAEXE.Rows[0]["valor"].ToString() + @"\" + VERSIONEXE.Rows[0]["exe"].ToString() + ".inf") == false)
            {
                //si no lanzamos mensaje avisando que no existe el instalador
                MessageBox.Show("No existe instalador en la ruta configurada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            //preguntamos si existe el archivito inf de nuestra aplicacion
            if (System.IO.File.Exists(@"C:\ERP\CMFA0406.inf") == false || System.IO.File.Exists(@"C:\ERP\CMFA0406.msi") == false)
            {
                //SI ES DIFERENTE COPIAMOS AMBOS ARCHIVOS A NUESTRO LOCAL .INFO Y .MSI
                System.IO.File.Copy(RUTAEXE.Rows[0]["valor"].ToString() + @"\" + VERSIONEXE.Rows[0]["exe"].ToString() + ".msi", @"C:\ERP\CMFA0406.msi", true);
                System.IO.File.Copy(RUTAEXE.Rows[0]["valor"].ToString() + @"\" + VERSIONEXE.Rows[0]["exe"].ToString() + ".inf", @"C:\ERP\CMFA0406.inf", true);

                System.Diagnostics.Process[] PROSSES = System.Diagnostics.Process.GetProcesses();


                foreach (System.Diagnostics.Process P in PROSSES)//BARREMOS SERVICIOS
                {
                    if (P.ProcessName.ToString() == "CA_FEL")
                    {
                        //SI ESTA CORRIENDO EL SERVICO,LO MATAMOS
                        P.Kill(); break;
                    }
                }

                //ejecutamos el instalador  y ya se sale del metodo (return)
                System.Diagnostics.Process.Start(@"C:\ERP\CMFA0406.msi");

                
            }

            //LEEMOS EL ARCHIVO LOCAL
            StreamReader objReader = new StreamReader(@"C:\ERP\CMFA0406.inf");
            string sLine = objReader.ReadLine();
            //COMPARAMOS VERSION DE LA TABLA REVI CON EL ARCHIVITO INFO LOCAL
            if (VERSIONEXE.Rows[0]["rev"].ToString().Trim() != sLine.Substring(9, 8))
            {
                //SI ES DIFERENTE COPIAMOS AMBOS ARCHIVOS A NUESTRO LOCAL .INFO Y .MSI
                System.IO.File.Copy(RUTAEXE.Rows[0]["valor"].ToString() + @"\" + VERSIONEXE.Rows[0]["exe"].ToString() + ".msi", @"C:\ERP\CMFA0406.msi", true);
                System.IO.File.Copy(RUTAEXE.Rows[0]["valor"].ToString() + @"\" + VERSIONEXE.Rows[0]["exe"].ToString() + ".inf", @"C:\ERP\CMFA0406.inf", true);

                System.Diagnostics.Process[] PROSSES = System.Diagnostics.Process.GetProcesses();

               
                foreach (System.Diagnostics.Process P in PROSSES)//BARREMOS SERVICIOS
                {
                    if (P.ProcessName.ToString() == "CA_FEL")
                    {  
                        //SI ESTA CORRIENDO EL SERVICO,LO MATAMOS
                        P.Kill(); break; 
                    }
                }              

                //ejecutamos el instalador  y ya se sale del metodo (return)
                System.Diagnostics.Process.Start(@"C:\ERP\CMFA0406.msi");
            }

        }

        private void FrmFiltro_Load(object sender, EventArgs e)
        {

        }

       
    }
 
}
