using SegundoParcial.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SegundoParcial
{
    public static class Program
    {
        public static List<Factura> Facturas = new List<Factura>();
        public static List<SegundoParcial.Clases.Producto> Productos = new List<SegundoParcial.Clases.Producto>();
        public static List<SegundoParcial.Clases.CuentaCorriente> CuentaCorrientes = new List<SegundoParcial.Clases.CuentaCorriente>();
        public static List<Marca> Marcas = new List<Marca>();
        public static List<Rubro> Rubros = new List<Rubro>();
        public static List<Cliente> Clientes = new List<Cliente>();

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CargaInicialMarcas();
            CargaInicialRubro();
            CargaInicialProductos();
            CargaInicialClientes();
            CargaInicialCuentaCorriente();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login flogin = new Login();
            flogin.Show();
            Application.Run();
        }

        private static void CargaInicialClientes()
        {
            Clientes.Add(new Cliente()
            {
                Apellido = "Sosa",
                Nombre = "Roberto",
                Dni = "12345678",
            });

            Clientes.Add(new Cliente()
            {
                Apellido = "Alvarez",
                Nombre = "Diego",
                Dni = "44345678",
            });

            Clientes.Add(new Cliente()
            {
                Apellido = "Ruiz",
                Nombre = "Martina",
                Dni = "55345678",
            });

            Clientes.Add(new Cliente()
            {
                Apellido = "Romero",
                Nombre = "Carla",
                Dni = "77345678",
            });
        }

        private static void CargaInicialCuentaCorriente()
        {
            CuentaCorrientes.Add(new Clases.CuentaCorriente()
            {
                Cliente = Clientes[0],
                Fecha = DateTime.Now,
                Monto = 0.00m,
                TipoMovimiento = TipoMovimiento.Ingreso
            });

            CuentaCorrientes.Add(new Clases.CuentaCorriente()
            {
                Cliente = Clientes[1],
                Fecha = DateTime.Now,
                Monto = 0.00m,
                TipoMovimiento = TipoMovimiento.Ingreso
            });

            CuentaCorrientes.Add(new Clases.CuentaCorriente()
            {
                Cliente = Clientes[2],
                Fecha = DateTime.Now,
                Monto = 0.00m,
                TipoMovimiento = TipoMovimiento.Ingreso
            });

            CuentaCorrientes.Add(new Clases.CuentaCorriente()
            {
                Cliente = Clientes[3],
                Fecha = DateTime.Now,
                Monto = 0.00m,
                TipoMovimiento = TipoMovimiento.Ingreso
            });
        }

        private static void CargaInicialProductos()
        {
            Productos.Add(new SegundoParcial.Clases.Producto
            {
                Codigo = 1,
                CodigoBarra = "123456",
                Descripcion = "Jugo Citric naranja x3lt",
                PrecioCosto = 100m,
                PrecioPublico = 245m,
                Stock = 10m,
                EstaEliminado = false,
                Marca = Marcas[0],
                Rubro = Rubros[0]
            });

            Productos.Add(new SegundoParcial.Clases.Producto
            {
                Codigo = 2,
                CodigoBarra = "222222",
                Descripcion = "Azúcar x1Kg",
                PrecioCosto = 30m,
                PrecioPublico = 50m,
                Stock = 20,
                EstaEliminado = false,
                Marca = Marcas[1],
                Rubro = Rubros[0]
            });

            Productos.Add(new SegundoParcial.Clases.Producto
            {
                Codigo = 3,
                CodigoBarra = "333333",
                Descripcion = "Leche Milkaut entera/desc",
                PrecioCosto = 30m,
                PrecioPublico = 56.99m,
                Stock = 10,
                EstaEliminado = false,
                Marca = Marcas[2],
                Rubro = Rubros[0]
            });

            Productos.Add(new SegundoParcial.Clases.Producto
            {
                Codigo = 4,
                CodigoBarra = "444444",
                Descripcion = "Harina Favorita 3/0 x 1kg",
                PrecioCosto = 20.55m,
                PrecioPublico = 36.55m,
                Stock = 5,
                EstaEliminado = false,
                Marca = Marcas[3],
                Rubro = Rubros[0]
            });

            Productos.Add(new SegundoParcial.Clases.Producto
            {
                Codigo = 5,
                CodigoBarra = "555555",
                Descripcion = "Arroz Luchetti largo fino x500g",
                PrecioCosto = 20.55m,
                PrecioPublico = 38m,
                Stock = 5,
                EstaEliminado = false,
                Marca = Marcas[4],
                Rubro = Rubros[0]
            });

            Productos.Add(new SegundoParcial.Clases.Producto
            {
                Codigo = 6,
                CodigoBarra = "666666",
                Descripcion = "Lavandina ayudín x 1lt",
                PrecioCosto = 15m,
                PrecioPublico = 33.98m,
                Stock = 5,
                EstaEliminado = false,
                Marca = Marcas[5],
                Rubro = Rubros[2]
            });

            Productos.Add(new SegundoParcial.Clases.Producto
            {
                Codigo = 7,
                CodigoBarra = "777777",
                Descripcion = "Detergente Magistral x300 ml",
                PrecioCosto = 30m,
                PrecioPublico = 64m,
                Stock = 15,
                EstaEliminado = false,
                Marca = Marcas[5],
                Rubro = Rubros[2]
            });
        }

        private static void CargaInicialMarcas()
        {
            Marcas.Add(new Marca
            {
                Codigo = "0001",
                Descripcion = "Citric",
            });

            Marcas.Add(new Marca
            {
                Codigo = "0002",
                Descripcion = "Copito",
            });

            Marcas.Add(new Marca
            {
                Codigo = "0003",
                Descripcion = "Milkaut",
            });

            Marcas.Add(new Marca
            {
                Codigo = "0004",
                Descripcion = "Favorita",
            });

            Marcas.Add(new Marca
            {
                Codigo = "0005",
                Descripcion = "Luchetti",
            });

            Marcas.Add(new Marca
            {
                Codigo = "0006",
                Descripcion = "Ayudín",
            });

            Marcas.Add(new Marca
            {
                Codigo = "0007",
                Descripcion = "Magistral",
            });
        }

        public static void CargaInicialRubro()
        {
            Rubros.Add(new Rubro
            {
                Codigo = "0001",
                Descripcion = "Alimentos",
            });

            Rubros.Add(new Rubro
            {
                Codigo = "0002",
                Descripcion = "Bebidas",
            });

            Rubros.Add(new Rubro
            {
                Codigo = "0003",
                Descripcion = "Limpieza",
            });

            Rubros.Add(new Rubro
            {
                Codigo = "0004",
                Descripcion = "Otros",
            });
        }
    }
}
