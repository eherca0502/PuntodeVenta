using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace PuntodeVenta
{
    class ArticulosBs
    {
        private int clave;
        private string descripcion;
        private double precio;
        private int stock;

        public int Clave
        {
            get
            {
                return (clave);
            }
            set
            {
                clave = value;
            }
        }
        public string Descripcion
        {
            get
            {
                return (descripcion);
            }
            set
            {
                descripcion = value;
            }
        }
        public double Precio
        {
            get
            {
                return (precio);
            }
            set
            {
                precio = value;
            }
        }
        public int Stock
        {
            get
            {
                return (stock);
            }
            set
            {
                stock = value;
            }
        }
        public void AgregarArticulos()
        {
            frmAgregar altas = new frmAgregar();
            if (altas.ShowDialog() == DialogResult.Yes)
            {
                string filePath = "articulos.xlsx";
                using (var workbook = new XLWorkbook(filePath))
                {

                    var worksheet = workbook.Worksheet("Articulos");
                    if (worksheet == null)
                    {

                        worksheet = workbook.Worksheets.Add("Articulos");
                    }

                    var lastRowUsed = worksheet.LastRowUsed();
                    if (lastRowUsed == null || lastRowUsed.RowNumber() < 4)
                    {

                        worksheet.Cell(4, 1).Value = altas.clave;
                        worksheet.Cell(4, 2).Value = altas.articulo;
                        worksheet.Cell(4, 3).Value = altas.precio;
                        worksheet.Cell(4, 4).Value = altas.stock;
                    }
                    else
                    {

                        var firstEmptyRow = lastRowUsed.RowBelow().RowNumber();
                        worksheet.Cell(firstEmptyRow, 1).Value = altas.clave;
                        worksheet.Cell(firstEmptyRow, 2).Value = altas.articulo;
                        worksheet.Cell(firstEmptyRow, 3).Value = altas.precio;
                        worksheet.Cell(firstEmptyRow, 4).Value = altas.stock;
                    }
                    workbook.Save();
                }
                MessageBox.Show("Los datos del articulo han sido guardados", "Altas de Articulos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void EliminarArt()
        {
            Bajas bajaart = new Bajas();
            if (bajaart.ShowDialog() == DialogResult.Yes)
            {
                string filePath = "articulos.xlsx";
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet("Articulos");
                    if (worksheet == null)
                    {
                        MessageBox.Show("La hoja 'Articulos' no se encontró en el archivo Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bool claveBorrada = false;
                    var lastRowUsed = worksheet.LastRowUsed();
                    if (lastRowUsed != null)
                    {
                        for (int i = 1; i <= lastRowUsed.RowNumber(); i++)
                        {
                            var clave = worksheet.Cell(i, 1).Value.ToString();
                            if (clave != bajaart.clave)
                            {
                                worksheet.Cell(i, 1).CopyTo(worksheet.Cell(i, 1));
                                worksheet.Cell(i, 2).CopyTo(worksheet.Cell(i, 2));
                                worksheet.Cell(i, 3).CopyTo(worksheet.Cell(i, 3));
                                worksheet.Cell(i, 4).CopyTo(worksheet.Cell(i, 4));
                            }
                            else
                            {
                                claveBorrada = true;

                                worksheet.Row(i).Delete();
                            }
                        }
                    }

                    workbook.Save();

                    if (claveBorrada)
                    {
                        MessageBox.Show("La clave ha sido borrada exitosamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la clave para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        public void ConsultarArticulos(ListView ls)
        {

            ls.Items.Clear();  

            string filePath = "articulos.xlsx";  
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
                        var clave = worksheet.Cell(i, 1).Value.ToString();  
                        var articulo = worksheet.Cell(i, 2).Value.ToString();  
                        var precio = worksheet.Cell(i, 3).Value.ToString();  
                        var stock = worksheet.Cell(i, 4).Value.ToString();  

                        
                        ListViewItem lista = new ListViewItem(clave);
                        
                        lista.SubItems.Add(articulo);
                        lista.SubItems.Add(precio);
                        lista.SubItems.Add(stock);

                        ls.Items.Add(lista);  
                    }
                }
            }
        }
        public void ModificaArticulos()
        {
            Modificar modificar = new Modificar();
            if (modificar.ShowDialog() == DialogResult.Yes)
            {
                string filePath = "articulos.xlsx"; 
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet("Articulos"); 
                    if (worksheet == null)
                    {
                        MessageBox.Show("La hoja 'Articulos' no se encontró en el archivo Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bool articuloModificado = false;
                    var lastRowUsed = worksheet.LastRowUsed();
                    if (lastRowUsed != null)
                    {
                        for (int i = 1; i <= lastRowUsed.RowNumber(); i++)
                        {
                            var clave = worksheet.Cell(i, 1).Value.ToString();
                            if (clave != modificar.claveActual)
                            {
                                
                            }
                            else
                            {
                                
                                worksheet.Cell(i, 1).Value = modificar.nuevaClave;
                                worksheet.Cell(i, 2).Value = modificar.nuevoArticulo;
                                worksheet.Cell(i, 3).Value = modificar.nuevoPrecio;
                                worksheet.Cell(i, 4).Value = modificar.nuevoStock;
                                articuloModificado = true;
                            }
                        }
                    }

                    workbook.Save();

                    if (articuloModificado)
                    {
                        MessageBox.Show("El artículo ha sido modificado exitosamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el artículo para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}


