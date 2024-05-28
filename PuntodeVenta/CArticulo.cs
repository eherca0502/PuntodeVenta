using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace PuntodeVenta
{
    public partial class CArticulo : Form
    {
        public CArticulo()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string articuloConsulta = txtArticulo.Text;

            if (!string.IsNullOrEmpty(articuloConsulta))
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
                                var descripcion = worksheet.Cell(i, 2).Value.ToString(); 
                                if (descripcion.Equals(articuloConsulta))
                                {
                                    var clave = worksheet.Cell(i, 1).Value.ToString(); 
                                    var precio = worksheet.Cell(i, 3).Value.ToString(); 
                                    var stock = worksheet.Cell(i, 4).Value.ToString(); 

                                    MessageBox.Show($"Artículo encontrado:\nClave: {clave}\nDescripción: {articuloConsulta}\nPrecio: {precio}\nStock: {stock}", "Consulta de Artículo");
                                    return; 
                                }
                            }
                        }

                        MessageBox.Show("No se encontró ningún artículo", "Consulta de Artículo");
                    }
                }
                else
                {
                    MessageBox.Show("El archivo de artículos no existe.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un artículo para realizar la consulta.", "Advertencia");
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
