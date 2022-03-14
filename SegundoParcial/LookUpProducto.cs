using System;
using System.Linq;
using System.Windows.Forms;

namespace SegundoParcial
{
    public partial class LookUpProducto : Form
    {
        private string _cadenaBuscar;

        public bool Confirmar { get; set; }
        
        public SegundoParcial.Clases.Producto ProductoSeleccionado { get; set; }

        public LookUpProducto()
        {
            InitializeComponent();
            _cadenaBuscar = string.Empty;
            ProductoSeleccionado = null;
        }

        public LookUpProducto(string cadenaBuscar)
        {
            InitializeComponent();
            _cadenaBuscar = cadenaBuscar;
            ProductoSeleccionado = null;
            txtBuscar.Text = _cadenaBuscar;
        }

        private void BuscarProducto()
        {
            int _codigo = -1;
            int.TryParse(_cadenaBuscar, out _codigo);

            dgvLookUpProducto.DataSource = Program.Productos
                .Where(x =>x.EstaEliminado != true && x.Codigo == _codigo
                    || x.Descripcion.ToLower().Contains(_cadenaBuscar.ToLower())
                    || x.CodigoBarra == _cadenaBuscar)
                .ToList();

            FormatearGrilla();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Confirmar = false;
            this.Close();
        }

        private void DgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLookUpProducto.Rows.Count > 0)
            {
                ProductoSeleccionado = (Clases.Producto)dgvLookUpProducto.Rows[e.RowIndex].DataBoundItem;
                Confirmar = true;
            }
            else {
                ProductoSeleccionado = null;
            }
        }

        private void LookUpProducto_Load(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void DgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            _cadenaBuscar = txtBuscar.Text;
            BuscarProducto();
        }

        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        private void FormatearGrilla()
        {
            dgvLookUpProducto.Columns["Codigo"].Visible = true;
            dgvLookUpProducto.Columns["CodigoBarra"].Visible = false;
            dgvLookUpProducto.Columns["Descripcion"].Visible = true;
            dgvLookUpProducto.Columns["PrecioCosto"].Visible = false;
            dgvLookUpProducto.Columns["PrecioPublico"].Visible = false;
            dgvLookUpProducto.Columns["Stock"].Visible = true;
            dgvLookUpProducto.Columns["EstaEliminado"].Visible = false;
            dgvLookUpProducto.Columns["EstaEliminadoStr"].Visible = false;
            dgvLookUpProducto.Columns["Marca"].Visible = false;
            dgvLookUpProducto.Columns["Rubro"].Visible = false;
            dgvLookUpProducto.Columns["MarcaStr"].Visible = false;
            dgvLookUpProducto.Columns["RubroStr"].Visible = false;

            dgvLookUpProducto.Columns["Codigo"].HeaderText = "Código";
            dgvLookUpProducto.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLookUpProducto.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvLookUpProducto.Columns["Descripcion"].HeaderText = "Descripción";
            dgvLookUpProducto.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLookUpProducto.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dgvLookUpProducto.Columns["Stock"].HeaderText = "Stock";
            dgvLookUpProducto.Columns["Stock"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLookUpProducto.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
