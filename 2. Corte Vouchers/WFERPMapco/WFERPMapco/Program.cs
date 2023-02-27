using System;
using System.Windows.Forms;
using WFERPMapco.Formas;
using WFERPMapco.Formas.Ficha;
using WFERPMapco.Formas.Prueba;

namespace WFERPMapco
{
    static class Program
    {
        public static bool OpenDetailFormOnClose { get; set; }
        public static int NumeroEmpleado { get; set; }
        public static int IdSucursal { get; set; }

        public static Clases.MenuParametros parametros { get; set; }
        /// <summary>
        /// /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OpenDetailFormOnClose = false;
            Application.Run(new debug());

            if(OpenDetailFormOnClose)
            {
                Application.Run(new WFERPMapco.Formas.Menu.Menu(parametros));
            }
        }

    }
}
