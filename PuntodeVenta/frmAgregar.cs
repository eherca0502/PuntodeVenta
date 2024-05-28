using System;
using System.Windows.Forms;

namespace PuntodeVenta
{
    public partial class frmAgregar : Form
    {
        public frmAgregar()
        {
            InitializeComponent();






        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            txtClave.Clear();
            txtArticulo.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtClave.Focus();
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtArticulo.Focus();
            }
        }

        private void txtArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPrecio.Focus();
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtStock.Focus();
            }
        }
        public string clave
        {
            get
            {
                return (txtClave.Text);
            }
        }
        public string articulo
        {
            get
            {
                return (txtArticulo.Text);
            }
        }
        public string precio
        {
            get
            {
                return (txtPrecio.Text);
            }
        }
        public string stock
        {
            get
            {
                return (txtStock.Text);
            }
        }


        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAgregar.PerformClick();
            }
        }
      

    }
    }

    


       


