using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFERPMapco.Formas.CorteDeVoucher
{
    public class CorteDeVoucherParametros
    {
        public string nombreEmpleado { get; set; }
        public string Title { get; set; }
        public string condiciones { get; set; }
        public int? ClaveEmpresa { get; set; }

        MySqlParameter[] _parameters;

        public MySqlParameter[] GetParameters(int pAccion, string pClaveEmpresa)
        {
            _parameters = new MySqlParameter[2];
            _parameters[0] = new MySqlParameter("VAROpcion", pAccion);
            _parameters[1] = new MySqlParameter("VARClaveEmpresa", pClaveEmpresa);

            return _parameters;
        }
    }
}
