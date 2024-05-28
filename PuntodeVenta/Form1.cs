using System;
using System.Windows.Forms;

namespace PuntodeVenta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ArticulosBs obj = new ArticulosBs();


       

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obj.AgregarArticulos();
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obj.EliminarArt();
        }

        private void claveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CClave frmConsultaClave = new CClave();
            frmConsultaClave.Show();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CArticulo frmConsultaArticulo = new CArticulo();
            frmConsultaArticulo.Show();
        }

        private void precioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPrecio frmConsultaPrecio = new CPrecio();
            frmConsultaPrecio.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CStock frmConsultaStock = new CStock();
            frmConsultaStock.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obj.ModificaArticulos();
        }

        private void todosLosArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obj.ConsultarArticulos(listView1);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

          
            FrmLogin loginForm = new FrmLogin();

 
            loginForm.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmVenta frmV=new FrmVenta();
            frmV.Show();
        }

        private void graficaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGrafica frmG=new FrmGrafica();
            frmG.Show();
        }
    }
}
