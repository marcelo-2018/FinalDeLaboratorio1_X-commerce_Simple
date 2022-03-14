namespace SegundoParcial.Clases
{
    public class Producto
    {
        public int Codigo { get; set; }

        public string CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public decimal PrecioCosto { get; set; }

        public decimal PrecioPublico { get; set; }

        public decimal Stock { get; set; }

        public bool EstaEliminado { get; set; }

        public string EstaEliminadoStr => EstaEliminado ? "SI" : "NO";


        public Marca Marca { get; set; }

        public string MarcaStr => Marca.Descripcion;

        public Rubro Rubro { get; set; }

        public string RubroStr => Rubro.Descripcion;

      }
}
