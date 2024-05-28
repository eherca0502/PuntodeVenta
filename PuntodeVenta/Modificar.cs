using System;

using System.Windows.Forms;

namespace PuntodeVenta
{
    public partial class Modificar : Form
    {
        public string claveActual { get; set; }
        public string nuevaClave { get; set; }
        public string articuloActual { get; set; }
        public string nuevoArticulo { get; set; }
        public string precioActual { get; set; }
        public string nuevoPrecio { get; set; }
        public string stockActual { get; set; }
        public string nuevoStock { get; set; }

        public Modificar()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            claveActual = txtClave.Text;
            nuevaClave = txtClaveNueva.Text;
            articuloActual = txtArticulo.Text;
            nuevoArticulo = txtArticuloNuevo.Text;
            precioActual = txtPrecio.Text;
            nuevoPrecio = txtPrecioN.Text;
            stockActual = txtStock.Text;
            nuevoStock = txtStockN.Text;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
