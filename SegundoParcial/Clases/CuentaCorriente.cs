using System;

namespace SegundoParcial.Clases
{
    public class CuentaCorriente
    {
        public Cliente Cliente { get; set; }

        public string ClienteStr => Cliente.ApyNom;

        public DateTime Fecha { get; set; }

        public string FechaStr => Fecha.ToShortDateString();

        public decimal Monto { get; set; }

        public TipoMovimiento TipoMovimiento { get; set; }
    }
}
