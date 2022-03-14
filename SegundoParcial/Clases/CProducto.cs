namespace SegundoParcial.Clases
{
    public class CProducto
    {
        public int Codigo { get; set; }

        public string CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public decimal PrecioCosto { get; set; }

        public decimal PrecioPublico { get; set; }

        public decimal Stock { get; set; }

        public bool StockNegativo { get; set; }

        public CMarca Marca { get; set; }

        public string MarcaStr => Marca.Descripcion;

        public CRubro Rubro { get; set; }

        public string RubroStr => Rubro.Descripcion;

        public bool EstaEliminado { get; set; }
    }
}
