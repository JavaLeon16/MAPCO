using System;
using System.Collections.Generic;
using System.Data;


namespace WFERPMapco.Clases
{
   public  class MenuParametros
    {
        public int? IdSucursal { get; set; }
        public string IpServidor { get; set; }
        public string BaseDatos { get; set; }
        public int? IdEmpresa { get; set; }
        public DataTable DtPermisos { get; set; }
        public int? NumeroEmpleado { get; set; }
        public string Modulo { get; set; }
        public List<Clases.Sucursales> LSucursales { get; set; }
        public DataTable SucursalesUsuario { get; set; }

        public DateTime Fecha { get; set; }
    }
}
