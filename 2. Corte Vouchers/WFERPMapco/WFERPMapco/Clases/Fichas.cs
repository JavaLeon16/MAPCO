using System;


namespace WFERPMapco.Clases
{
    public class Fichas
    {
        public int IdFicha { get; set; }
        public string Cuenta { get; set; }
        public string Banco { get; set; }
        public string Movimiento { get; set; }
        public double Importe { get; set; }
        public string Consecutivo { get; set; }
        public int IdTipoMovimientoFicha { get; set; }
        public int IdBanco { get; set; }
        public int UsuarioInsert { get; set; }
        public DateTime FechaInsert { get; set; }
        public DateTime FechaCorte { get; set; }
        public int UsuarioUpdate { get; set; }
        public DateTime FechaUpdate { get; set; }
        public int UsuarioBaja { get; set; }
        public DateTime FechaBaja { get; set; }
        public bool Estatus { get; set; }
        public bool EsConsulta { get; set; }
    }
}
