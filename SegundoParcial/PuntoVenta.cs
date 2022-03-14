namespace SegundoParcial
{
    using Clases;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class fPuntoVenta : Form
    {
        private Factura _facturaActual;
        private Clases.Producto _productoActual;
        private decimal _total;
        private int indice;

        public fPuntoVenta()
        {
            InitializeComponent();

            _total = 0m;

            indice = 0;

            CrearNuevaFactura();
        }

        private void CrearNuevaFactura()
        {
            _facturaActual = new Factura(ObtenerSiguienteNumeroFactura());

            txtNumeroFactura.Text = _facturaActual.Numero.ToString().PadLeft(6, '0');
            
            RefrescarItems(_facturaActual.Items);
        }

        private void RefrescarItems(List<Item> listaItems)
        {
            dgvItems.DataSource = listaItems.ToList();
            FormatearGrillaItems();

            _facturaActual.Descuento = nudDescuento.Value;

            RefrescarTotalizadores(_facturaActual.SubTotal, _facturaActual.Total, _facturaActual.Descuento);
        }

        private void RefrescarTotalizadores(decimal subtotal, decimal total, decimal descuento)
        {
            txtSubTotal.Text = subtotal.ToString("C2");
            txtTotal.Text = total.ToString("C2");
            nudDescuento.Value = descuento;
        }

        private void FormatearGrillaItems()
        {
            dgvItems.Columns["CodigoProducto"].Visible = true;
            dgvItems.Columns["CodigoProducto"].HeaderText = "Código";
            dgvItems.Columns["CodigoProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvItems.Columns["DescripcionProducto"].Visible = true;
            dgvItems.Columns["DescripcionProducto"].HeaderText = "Producto";
            dgvItems.Columns["DescripcionProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvItems.Columns["DescripcionProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvItems.Columns["PrecioVentaProducto"].Visible = true;
            dgvItems.Columns["PrecioVentaProducto"].HeaderText = "Precio Venta";
            dgvItems.Columns["PrecioVentaProducto"].DefaultCellStyle.Format = "C2";
            dgvItems.Columns["PrecioVentaProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItems.Columns["PrecioVentaProducto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvItems.Columns["Cantidad"].Visible = true;
            dgvItems.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvItems.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItems.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvItems.Columns["SubTotalItem"].Visible = true;
            dgvItems.Columns["SubTotalItem"].HeaderText = "Sub-Total";
            dgvItems.Columns["SubTotalItem"].DefaultCellStyle.Format = "C2";
            dgvItems.Columns["SubTotalItem"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItems.Columns["SubTotalItem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private int ObtenerSiguienteNumeroFactura()
        {
            if (Program.Facturas.Any())
            {
                return Program.Facturas.Max(x => x.Numero) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                _productoActual = VerificarSiExisteProducto(txtCodigo.Text);

                if(_productoActual != null)
                {
                    btnAgregar.PerformClick();
                }
                else 
                {

                    btnAgregar.PerformClick();
                }
            }
        }

        private Clases.Producto VerificarSiExisteProducto(string codigoProducto)
        {
            int codigo = -1;
            int.TryParse(codigoProducto, out codigo);

            return Program.Productos.FirstOrDefault(x => x.Codigo == codigo);
        }

        private void BtnAgregar_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Por favor Ingrese el codigo del Producto","Atención",MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            _productoActual = VerificarSiExisteProducto(txtCodigo.Text);

            if (_productoActual != null)
            {
                if (_productoActual.Stock > 0 && _productoActual.Stock >= nudCantidad.Value)
                {
                    if (_productoActual.EstaEliminado != true)
                    {
                        txtDescripcion.Text = _productoActual.Descripcion;
                        txtPrecio.Text = _productoActual.PrecioPublico.ToString();

                        AgregarProductoItems(_productoActual, nudCantidad.Value);
                    }
                    else
                    {
                        MessageBox.Show("Ese producto se encuentra eliminado.", "Atención");
                    }
                }
                else
                {
                    MessageBox.Show("No hay stock de ese producto.","Atención");
                }
            }
            else
            {
                var fBusquedaProducto = new LookUpProducto();
                fBusquedaProducto.ShowDialog();

                if (fBusquedaProducto.Confirmar == true)
                {
                    if (fBusquedaProducto.ProductoSeleccionado != null)
                    {
                        _productoActual = fBusquedaProducto.ProductoSeleccionado;

                        if (_productoActual.Stock > 0 && _productoActual.Stock >= nudCantidad.Value)
                        {
                            if (_productoActual.EstaEliminado != true)
                            {
                                txtCodigo.Text = _productoActual.Codigo.ToString();
                                AgregarProductoItems(_productoActual, nudCantidad.Value);
                            }
                            else
                            {
                                MessageBox.Show("Ese producto se encuentra eliminado.", "Atención");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay stock de ese producto.", "Atención");
                        }
                    }
                }
            }

            RefrescarItems(_facturaActual.Items);
            nudCantidad.Value = 1;
        }

        private void LimpiarParaNuevoProducto()
        {
            nudCantidad.Value = 1;
            nudDescuento.Value = 0;
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtCodigo.Focus();
        }

        private void AgregarProductoItems(Clases.Producto producto, decimal cantidad)
        {
            var itemExistente = VerificarSiEstaCargadoElProducto(producto.Codigo);

            if (itemExistente != null)
            {
                if (nudCantidad.Value >= 1)
                {
                    itemExistente.Cantidad += cantidad;

                    _productoActual.Stock -= cantidad;
                }
            }
            else 
            {
                _facturaActual.Items.Add(new Item
                {
                    Cantidad = cantidad,
                    CodigoProducto = producto.Codigo,
                    DescripcionProducto = producto.Descripcion,
                    PrecioVentaProducto = producto.PrecioPublico
                });

                _productoActual.Stock -= cantidad;
            }
        }

        private Clases.Item VerificarSiEstaCargadoElProducto(int codigo)
        {
            return _facturaActual.Items.FirstOrDefault(x => x.CodigoProducto == codigo);
        }

        private void BtnFacturar_Click(object sender, EventArgs e)
        {
            _total = _facturaActual.Total;

            if (_total != 0)
            {
                Facturar facturar = new Facturar(_total);

                facturar.ShowDialog();

                if (facturar.confirmar != false)
                {

                    LimpiarParaNuevoProducto();

                    CrearNuevaFactura();

                    LimpiarParaNuevoProducto();
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("No hay ningun producto cargado.", "Ateción",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        }


        private void nudDescuento_ValueChanged(object sender, EventArgs e)
        {
            RefrescarItems(_facturaActual.Items);
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            _productoActual = VerificarSiExisteProducto(txtCodigo.Text);

            if (_productoActual != null)
            {
                txtDescripcion.Text = _productoActual.Descripcion;
                txtPrecio.Text = _productoActual.PrecioPublico.ToString("C");
            }
            else
            {
                txtDescripcion.Text = "";
                txtPrecio.Text = "";
                nudCantidad.Value = 1;
            }
        }
    }
}
