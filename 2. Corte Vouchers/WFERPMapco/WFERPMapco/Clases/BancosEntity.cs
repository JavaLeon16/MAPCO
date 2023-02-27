using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFERPMapco.Clases
{
    public class BancosEntity
    {
        public int Idbanco { get; set; }
        public int IdBancoContable { get; set; }
        public string Banco { get; set; }
        public bool UsaTerminal { get; set; }
        public int Orden { get; set; }
        public bool Mapco { get; set; }
        public double ComisionBancaria { get; set; }
        public bool CapturaManual { get; set; }
        public bool Estatus { get; set; }
        public DateTime FechaInsert { get; set; }
        public DateTime FechaUpdate { get; set; }
        public DateTime FechaBaja { get; set; }
        public int UsuarioInsert { get; set; }
        public int UsuarioUpdate { get; set; }
        public int UsuarioBaja { get; set; }
    }
}
