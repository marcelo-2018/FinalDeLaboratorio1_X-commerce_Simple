namespace SegundoParcial.Clases
{
    public class Marca
    {
        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public bool EstaEliminado { get; set; }

        public string EstaEliminadoStr => EstaEliminado ? "SI" : "NO";
    }
}
