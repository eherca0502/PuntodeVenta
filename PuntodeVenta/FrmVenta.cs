using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ClosedXML.Excel;
using System.Globalization;

namespace PuntodeVenta
{
    public partial class FrmVenta : Form
    {

        private Dictionary<string, decimal> articulos = new Dictionary<string, decimal>();


        public FrmVenta()
        {
            InitializeComponent();
            CargarArticulosDesdeArchivoExcel("articulos.xlsx");
        }
        private void CargarArticulosDesdeArchivoExcel(string filePath)
        {

            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet("Articulos");
                    if (worksheet == null)
                    {
                        MessageBox.Show("La hoja 'Articulos' no se encontró en el archivo Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var lastRowUsed = worksheet.LastRowUsed();
                    if (lastRowUsed != null)
                    {
                        
                        for (int i = 4; i <= lastRowUsed.RowNumber(); i++)
                        {
                            var codigo = worksheet.Cell(i, 1).Value.ToString().Trim();
                            var nombre = worksheet.Cell(i, 2).Value.ToString().Trim();
                            var precioStr = worksheet.Cell(i, 3).Value.ToString().Trim();

                            if (decimal.TryParse(precioStr, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out decimal precio))
                            {
                                string articuloCompleto = $"{nombre} - ${precio}";
                                comboBoxArticulos.Items.Add(articuloCompleto);

                                articulos.Add(nombre, precio);
                            }
                            else
                            {
                                MessageBox.Show($"Error al cargar el artículo {nombre}: el precio no es un número válido. Valor encontrado: {precioStr}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los artículos: " + ex.Message);
            }
        }



        private void btnAgregarCombo_Click(object sender, EventArgs e)
        {

            if (comboBoxArticulos.SelectedIndex != -1)
            {

                string articuloSeleccionado = comboBoxArticulos.SelectedItem.ToString();


                string[] partes = articuloSeleccionado.Split('-');
                string nombreArticulo = partes[0].Trim();
                decimal precio = decimal.Parse(partes[1].Trim().Replace("$", ""));

                dgvArticulos.Rows.Add(nombreArticulo, precio);


                ActualizarPrecioTotal();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un artículo.");
            }
        }

        private void ActualizarPrecioTotal()
        {
            decimal precioTotal = 0;
            foreach (DataGridViewRow row in dgvArticulos.Rows)
            {
                precioTotal += Convert.ToDecimal(row.Cells["Precio"].Value);
            }
            lblPrecio.Text = $"Precio Total: {precioTotal:C2}";
        }
        private void btnVenta_Click(object sender, EventArgs e)
        {
            if (cbTipoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un tipo de pago.");
                return;
            }

            string tipoPagoSeleccionado = cbTipoPago.SelectedItem.ToString();
            decimal total = 0;
            foreach (DataGridViewRow row in dgvArticulos.Rows)
            {
                total += Convert.ToDecimal(row.Cells["Precio"].Value);
            }
            string mensaje = $"Total de la venta: {total:C2}\nFecha y Hora: {DateTime.Now}\nTipo de Pago: {tipoPagoSeleccionado}";
            MessageBox.Show(mensaje);

            
            GuardarVentaEnArchivo(total, tipoPagoSeleccionado);
            dgvArticulos.Rows.Clear();
        }

        private void GuardarVentaEnArchivo(decimal total, string tipoPago)
        {
            try
            {
                string filePath = "ventas.xlsx";
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet("Ventas");
                    if (worksheet == null)
                    {
                        MessageBox.Show("La hoja 'Ventas' no se encontró en el archivo Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    
                    
                    int nextRow = worksheet.LastRowUsed()?.RowNumber() ?? 3;
                    nextRow++; 

                    
                    if (nextRow < 4) nextRow = 4;

                    worksheet.Cell(nextRow, 1).Value = DateTime.Now;
                    worksheet.Cell(nextRow, 2).Value = $"{total:C2}";
                    worksheet.Cell(nextRow, 3).Value = tipoPago;

                    
                    workbook.Save();
                }

                MessageBox.Show("Venta guardada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la venta: " + ex.Message);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows.Count > 0)
            {

                DataGridViewRow filaSeleccionada = dgvArticulos.SelectedRows[0];


                dgvArticulos.Rows.Remove(filaSeleccionada);


                ActualizarPrecioTotal();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.");
            }
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {

        }
    }
}
    


