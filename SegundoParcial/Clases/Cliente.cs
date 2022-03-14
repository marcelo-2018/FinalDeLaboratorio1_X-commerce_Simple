namespace SegundoParcial.Clases
{
    public class Cliente
    {
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string ApyNom => $"{Apellido} {Nombre}";

        public string Dni { get; set; }

        public bool EstaEliminado { get; set; }

        public string EstaEliminadoStr => EstaEliminado? "SI" : "NO";
    }
}
