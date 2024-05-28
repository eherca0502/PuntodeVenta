using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using xls = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace PuntodeVenta
{
    public partial class FrmGrafica : Form
    {
        private Graficas graficas;
        private xls.Application x;
        private OpenFileDialog dialogo;
        private string nombreArchivo = "";
        public FrmGrafica()
        {
            InitializeComponent();

            btnSeleccionar.Click += new EventHandler(btnSeleccionar_Click);

            foreach (var chartType in Enum.GetNames(typeof(SeriesChartType)))
            {
                cbGraficas.Items.Add(chartType);
            }

            cbGraficas.SelectedIndex = 0;
            graficas = new Graficas(lvData, ChartGrafica);
        }
       


        private void btnLeerA_Click(object sender, EventArgs e)
        {
            dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
            DialogResult resultado = dialogo.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                nombreArchivo = dialogo.FileName;
            }

            if (!string.IsNullOrEmpty(nombreArchivo))
            {
                try
                {
                    x = new xls.Application();
                    x.Workbooks.Open(nombreArchivo);
                    xls.Worksheet hoja = x.ActiveWorkbook.ActiveSheet;
                    int ultimaFila = hoja.Cells[hoja.Rows.Count, "A"].End[xls.XlDirection.xlUp].Row;
                    for (int i = 5; i <= ultimaFila; i++)
                    {
                        string fecha = hoja.Cells[i, 1].Value?.ToString();
                        string total = hoja.Cells[i, 2].Value?.ToString();
                        string tipopago = hoja.Cells[i, 3].Value?.ToString();
                        ListViewItem datos = new ListViewItem(fecha);
                        datos.SubItems.Add(total);
                        datos.SubItems.Add(tipopago);
                        lvData.Items.Add(datos);
                    }
                    x.ActiveWorkbook.Close();
                    x.Quit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al leer el archivo de Excel: {ex.Message}");
                    if (x != null)
                    {
                        x.Quit();
                    }
                }
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbMes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMes.Checked)
            {
                string tipoGraficaSeleccionada = cbGraficas.SelectedItem.ToString();
                graficas.GraficarPorMes(tipoGraficaSeleccionada);
            }
        }

        private void rbAño_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAño.Checked)
            {

                string tipoGraficaSeleccionada = cbGraficas.SelectedItem.ToString();
                graficas.GraficarPorAño(tipoGraficaSeleccionada);
            }
        }

        private void rbTipoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTipoPago.Checked)
            {

                string tipoGraficaSeleccionada = cbGraficas.SelectedItem.ToString();
                graficas.GraficarPorTipoPago(tipoGraficaSeleccionada);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            string tipoGraficaSeleccionada = cbGraficas.SelectedItem.ToString();

            if(rbMes.Checked)
            {
                graficas.GraficarPorMes(tipoGraficaSeleccionada);
            }
            else if (rbAño.Checked)
            {
                graficas.GraficarPorMes(tipoGraficaSeleccionada);
            }
            else if(rbTipoPago.Checked)
            {
                graficas.GraficarPorTipoPago(tipoGraficaSeleccionada);
            }
        }
    }
    }


 

    







