using System;

namespace WFERPMapco.Clases
{
    public class OperacionTipo
    {
        public int IdTipoOperacion { set; get; }
        public int IdBanco { set; get; }
        public string Banco { set; get; }
        public string Descripcion { set; get; }
        public double ImporteMaximo { set; get; }
        public double ImporteComisionFija { set; get; }
        public double PorcentajeComision { set; get; }
        public double PorcentajeProteccion { set; get; }
        public bool IdTO { set; get; }
        public string TipoOperacion { set; get; }
        public bool EsPromocion { set; get; }
        public double CompraMinima { set; get; }
        public int Meses { set; get; }
        public bool Estatus { set; get; }
        public string KlaveKarum { set; get; }
        public double PorcentajeComisionFinancieraMapco { set; get; }
        public bool CapturaManual { set; get; }
        public int IdDispositivo { set; get; }
        public string Dispositivo { set; get; }
        public int UsuarioInsert { get; set; }
        public DateTime FechaInsert { get; set; }
        public int UsuarioUpdate { get; set; }
        public DateTime FechaUpdate { get; set; }
        public int UsuarioBaja { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}
