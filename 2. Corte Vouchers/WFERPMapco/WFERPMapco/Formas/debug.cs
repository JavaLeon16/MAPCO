using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFERPMapco.Objetos.Utilerias;

namespace WFERPMapco.Formas
{
    public partial class debug : Form
    {
        //usuario debug
        public int NumeroEmpleado = 9999;
        //sucursal debug
        public int idSucursal = 77;
        //modulo debug <- se necesita para los permisos, debe existir el registro en la tabla accesosusuarios
        public int idModulo = 9;
        //Nombre modulo en caso de no querer obtener el modulo de base de datos
        public string Modulo = "Bancos";
        public DateTime Fecha = DateTime.Now;

        public List<Clases.Sucursales> lSucursales = new List<Clases.Sucursales>();
        public Clases.MenuParametros parametrosModulo = new Clases.MenuParametros();
        public DataTable ModulosUsuario = new DataTable();
        public debug()
        {
            InitializeComponent();
        }

        private void debug_Load(object sender, EventArgs e)
        {
            parametrosModulo.NumeroEmpleado = NumeroEmpleado;
            parametrosModulo.IdSucursal = idSucursal;
            parametrosModulo.Fecha = Fecha;
            LlenaListadoSucursales();

            //CAMBIA CADENA DE CONEXION MYSQL


            // SI SE QUIERE AGREGAR OTRA SUCURSAL MODIFICAR ARCHIVO XML OBJETOS->UTILERIAS->Sucursales.xml
            /*OBTIENE DATOS SERVIDOR*/
            var sucursalFiltrada = (from a in lSucursales
                                    where a.IdSucursal == idSucursal
                                    select new { a.IdSucursal, a.IdEmpresa, a.IdEstado, a.IdMunicipio, a.NombreSucursal, a.CodigoSucursal, a.IP, a.BasedeDatos }
                                     ).ToList();
            parametrosModulo.IpServidor = sucursalFiltrada.First().IP;
            parametrosModulo.BaseDatos = sucursalFiltrada.First().BasedeDatos;
            parametrosModulo.IdEmpresa = sucursalFiltrada.First().IdEmpresa;

            //string cad = "Data Source=" + parametrosModulo.IpServidor + ";Port=3306;Initial Catalog=BDBASE" + parametrosModulo.BaseDatos + "22;User ID=user;Password=mapcouser";
            string cad = "Data Source=" + parametrosModulo.IpServidor + ";Port=3306;Initial Catalog=" + parametrosModulo.BaseDatos + ";User ID=root;Password=";
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //config.ConnectionStrings.ConnectionStrings.(new ConnectionStringSettings(
            //                                              "MYSQL",cad));

            config.ConnectionStrings.ConnectionStrings["MYSQL"].ConnectionString = cad;
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");

            ObtenerMenuUsuario();

            //si se tiene idmodulo se ira por los permisos a la base de datos si no se llenara el datatable de permisos
            if (idModulo > 0)
                ObtenerPermisosUsuario();
            else
                parametrosModulo.DtPermisos = LlenarPermisosManual(0);

            //ABRIR MODULO
            string formtocall = Modulo;
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Type[] types = myAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.BaseType.FullName == "System.Windows.Forms.Form")
                {
                    if (type.Name == formtocall.Trim())
                    {
                        var form = Activator.CreateInstance(Type.GetType(type.FullName), parametrosModulo) as Form;
                        form.Show();
                        break;
                    }
                }
            }



        }

        private void LlenaListadoSucursales()
        {
            SucursalesMapco sucursales = new SucursalesMapco();
            List<Clases.Sucursales> sucur = sucursales.getSucursales();
            lSucursales = sucur;
            parametrosModulo.LSucursales = lSucursales;
        }

        private void ObtenerMenuUsuario()
        {
            Resultado resultado = new Resultado();
            Objetos.Datos.Modulos.Capturas.Menu datos = new Objetos.Datos.Modulos.Capturas.Menu();

            try
            {
                int numeroempleado = NumeroEmpleado;
                resultado = datos.ObtenerMenu(NumeroEmpleado, idSucursal);
                if (!resultado.Error)
                {
                    if (resultado.Datos.Tables[0].Rows.Count > 0)
                    {
                        ModulosUsuario = resultado.Datos.Tables[0];

                    }
                    else
                    {
                        Alertas.Show("No se encontraron permisos de acceso en esta sucursal", "No hay permisos en Sucursal", Alertas.Buttons.OK);
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

        private void ObtenerSucursalesUsuario()
        {
            Resultado resultado;
            Objetos.Datos.Modulos.Capturas.Menu datos = new Objetos.Datos.Modulos.Capturas.Menu();

            try
            {
                resultado = datos.obtenerSucursalesUsuario(NumeroEmpleado);
                if (!resultado.Error)
                {
                    if (resultado.Datos.Tables[0].Rows.Count > 0)
                    {
                        parametrosModulo.SucursalesUsuario = resultado.Datos.Tables[0];
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

        private void ObtenerPermisosUsuario()
        {
            Resultado resultado = new Resultado();
            Objetos.Datos.Modulos.Capturas.Menu datos = new Objetos.Datos.Modulos.Capturas.Menu();

            try
            {
                resultado = datos.obtenerPermisosUsuario(NumeroEmpleado, idSucursal);
                if (!resultado.Error)
                {
                    if (resultado.Datos.Tables[0].Rows.Count > 0)
                    {
                        parametrosModulo.DtPermisos = resultado.Datos.Tables[0];
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

        private DataTable LlenarPermisosManual(int idModulo)
        {
            DataTable dt = new DataTable();


            dt.Clear();

            //COLUMNAS DE PERMISOS
            dt.Columns.Add("IdPermisoModulo");
            dt.Columns.Add("idModulo");
            dt.Columns.Add("Buscar");
            dt.Columns.Add("Insertar");
            dt.Columns.Add("Cancelar");
            dt.Columns.Add("Modificar");
            dt.Columns.Add("Aux1");
            dt.Columns.Add("Aux2");
            dt.Columns.Add("Aux3");
            dt.Columns.Add("Aux4");
            dt.Columns.Add("Aux5");
            dt.Columns.Add("Aux6");

            DataRow dr = dt.NewRow();

            dr[0] = 1;
            dr[1] = 1;
            dr[2] = true;
            dr[3] = true;
            dr[4] = true;
            dr[5] = true;
            dr[6] = true;
            dr[7] = true;
            dr[8] = true;
            dr[9] = true;
            dr[10] =true;
            dr[11] = true; 

            return dt;
        }
    }
}
