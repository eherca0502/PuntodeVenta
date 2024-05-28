using System;

using System.IO;
using ClosedXML.Excel;
using System.Windows.Forms;

namespace PuntodeVenta
{
    public partial class CPrecio : Form
    {
        public CPrecio()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string precioConsulta = txtPrecio.Text;

            if (!string.IsNullOrEmpty(precioConsulta))
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
                                var precio = worksheet.Cell(i, 3).Value.ToString(); 
                                if (precio == precioConsulta)
                                {
                                    var clave = worksheet.Cell(i, 1).Value.ToString(); 
                                    var articulo = worksheet.Cell(i, 2).Value.ToString(); 
                                    var stock = worksheet.Cell(i, 4).Value.ToString(); 

                                    MessageBox.Show($"Artículo encontrado:\nClave: {clave}\nDescripción: {articulo}\nPrecio: {precioConsulta}\nStock: {stock}", "Consulta de Artículo");
                                    return; 
                                }
                            }
                        }

                        MessageBox.Show("No se encontró ningún precio.", "Consulta de Artículo");
                    }
                }
                else
                {
                    MessageBox.Show("El archivo de artículos no existe.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un precio para realizar la consulta.", "Advertencia");
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

