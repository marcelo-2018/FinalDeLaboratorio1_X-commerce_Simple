namespace SegundoParcial.Clases
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Factura
    {
        // Constructor
        public Factura()
        {
            if (Items == null)
                Items = new List<Item>();
        }

        public Factura(int numeroFactura)
            : this()
        {
            Numero = numeroFactura;
        }

        public int Numero { get; set; }

        public DateTime Fecha { get; set; }

        public string FechaStr => Fecha.ToShortDateString();

        public Cliente Cliente { get; set; }

        public string ClienteStr => Cliente.ApyNom;

        public decimal SubTotal => Items.Sum(x => x.SubTotalItem);

        public decimal Descuento { get; set; }

        public decimal Total => SubTotal - Porcentaje.Calcular(SubTotal, Descuento);

        public decimal TotalFacturar { get; set; }

        public List<Item> Items { get; set; }
    }
}
