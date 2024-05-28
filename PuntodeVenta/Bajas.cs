using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntodeVenta
{
    public partial class Bajas : Form
    {
        public Bajas()
        {
            InitializeComponent();
        }
        public string clave
        {
            get
            {
                return (txtIngresarClave.Text);
            }
        }

        private void Bajas_Load(object sender, EventArgs e)
        {
            txtIngresarClave.Clear();
            txtIngresarClave.Focus();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
