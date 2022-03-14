namespace SegundoParcial.Clases
{
    public class Item
    {
        public int CodigoProducto { get; set; }

        public string DescripcionProducto { get; set; }

        public decimal PrecioVentaProducto { get; set; }

        public decimal Cantidad { get; set; }

        public decimal SubTotalItem => PrecioVentaProducto * Cantidad;
    }
}
