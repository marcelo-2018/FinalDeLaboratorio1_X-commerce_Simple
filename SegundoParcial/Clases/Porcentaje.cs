namespace SegundoParcial.Clases
{
    public static class Porcentaje
    {
        public static decimal Calcular(decimal valor, decimal porcentaje)
        {
            decimal resultado = 0m;

            resultado = (valor * porcentaje) / 100;

            return resultado;
        }
    }
}
