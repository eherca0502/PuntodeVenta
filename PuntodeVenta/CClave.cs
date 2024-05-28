using System;
using ClosedXML.Excel;
using System.IO;

using System.Windows.Forms;

namespace PuntodeVenta
{
    public partial class CClave : Form
    {
        public CClave()
        {
            InitializeComponent();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            string claveConsulta = txtClave.Text;

            if (!string.IsNullOrEmpty(claveConsulta))
            {
                string rutaArchivo = "articulos.xlsx"; 
                if (File.Exists(rutaArchivo))
                {
                    using (var workbook = new XLWorkbook(rutaArchivo))
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
                            for (int i = 1; i <= lastRowUsed.RowNumber(); i++)
                            {
                                var clave = worksheet.Cell(i, 1).Value.ToString();
                                if (clave.Equals(claveConsulta))
                                {
                                    var articulo = worksheet.Cell(i, 2).Value.ToString();
                                    var precio = worksheet.Cell(i, 3).Value.ToString(); 
                                    var stock = worksheet.Cell(i, 4).Value.ToString(); 

                                    MessageBox.Show($"Artículo encontrado:\nClave: {claveConsulta}\nDescripción: {articulo}\nPrecio: {precio}\nStock: {stock}", "Consulta de Artículo");
                                    return; 
                                }
                            }
                        }

                        MessageBox.Show("No se encontró ninguna clave", "Consulta de Artículo");
                    }
                }
                else
                {
                    MessageBox.Show("El archivo de artículos no existe.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una clave para realizar la consulta.", "Advertencia");
            }
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

