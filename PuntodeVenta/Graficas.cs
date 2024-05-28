using System;
using System.Collections.Generic;

using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PuntodeVenta
{
    public class Graficas
    {
        private ListView lvData;
        private Chart ChartGrafica;

        public Graficas(ListView listView, Chart chart)
        {
            lvData = listView;
            ChartGrafica = chart;
        }
        public void GraficarPorMes(string tipoGrafica)
        {
            Dictionary<int, int> conteoPorMes = new Dictionary<int, int>();
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo" };
            Color[] colores = { Color.Red, Color.Aqua, Color.Blue, Color.Yellow, Color.Orange };

            foreach (ListViewItem item in lvData.Items)
            {
                string[] partesFecha = item.SubItems[0].Text.Split('/');
                if (partesFecha.Length >= 2 && int.TryParse(partesFecha[1], out int mes))
                {
                    if (conteoPorMes.ContainsKey(mes))
                    {
                        conteoPorMes[mes]++;
                    }
                    else
                    {
                        conteoPorMes[mes] = 1;
                    }
                }
            }

            ChartGrafica.Series.Clear();

            Series series = new Series("Ventas por Mes");
            series.ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), tipoGrafica, true);
            series.IsValueShownAsLabel = true;

            foreach (var mes in conteoPorMes)
            {
                int mesIndex = mes.Key - 1;
                if (mesIndex < meses.Length)
                {
                    series.Points.AddXY(meses[mesIndex], mes.Value);
                    series.Points.Last().Color = colores[mesIndex];
                }
            }

            ChartGrafica.Series.Add(series);

            // Limpiar la leyenda anterior y agregar una nueva
            ChartGrafica.Legends.Clear();
            Legend legend = new Legend();
            for (int i = 0; i < meses.Length; i++)
            {
                legend.CustomItems.Add(colores[i], meses[i]);
            }
            ChartGrafica.Legends.Add(legend);
        }


        public void GraficarPorAño(string tipoGrafica)
        {
            Dictionary<int, int> conteoPorAño = new Dictionary<int, int>();
            List<int> años = new List<int>();
            Color[] colores = { Color.Red, Color.Aqua, Color.Blue, Color.Yellow, Color.Orange, Color.Purple, Color.Green, Color.Pink, Color.Brown, Color.OrangeRed, Color.Violet, Color.Gold };

            foreach (ListViewItem item in lvData.Items)
            {
                string[] partesFecha = item.SubItems[0].Text.Split('/');
                if (partesFecha.Length >= 3 && int.TryParse(partesFecha[2].Substring(0, 4), out int año))
                {
                    if (conteoPorAño.ContainsKey(año))
                    {
                        conteoPorAño[año]++;
                    }
                    else
                    {
                        conteoPorAño[año] = 1;
                        años.Add(año);
                    }
                }
            }

            if (conteoPorAño.Count == 0)
            {
                MessageBox.Show("No se encontraron datos para graficar por año.");
                return;
            }

            ChartGrafica.Series.Clear();

            Series series = new Series("Ventas por Año");
            series.ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), tipoGrafica, true);
            series.IsValueShownAsLabel = true;

            foreach (var año in conteoPorAño)
            {
                int añoIndex = años.IndexOf(año.Key);
                if (añoIndex >= 0)
                {
                    series.Points.AddXY(año.Key, año.Value);
                    series.Points.Last().Color = colores[añoIndex % colores.Length];
                }
            }

            ChartGrafica.Series.Add(series);

            ChartGrafica.Legends.Clear();
            Legend legend = new Legend();
            for (int i = 0; i < años.Count; i++)
            {
                legend.CustomItems.Add(colores[i % colores.Length], años[i].ToString());
            }
            ChartGrafica.Legends.Add(legend);
        }
        public void GraficarPorTipoPago(string tipoGrafica)
        {
            Dictionary<string, int> conteoTipoPago = new Dictionary<string, int>();
            Color[] colores = { Color.Red, Color.Aqua, Color.Blue, Color.Yellow, Color.Orange, Color.Purple, Color.Green };

            foreach (ListViewItem item in lvData.Items)
            {
                string tipoPago = item.SubItems[2].Text;
                if (conteoTipoPago.ContainsKey(tipoPago))
                {
                    conteoTipoPago[tipoPago]++;
                }
                else
                {
                    conteoTipoPago[tipoPago] = 1;
                }
            }

            if (conteoTipoPago.Count == 0)
            {
                MessageBox.Show("No se encontraron datos para graficar por tipo de pago.");
                return;
            }

            ChartGrafica.Series.Clear();

            Series series = new Series("Tipos de Pago");
            series.ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), tipoGrafica, true);
            series.IsValueShownAsLabel = true;

            int colorIndex = 0;
            foreach (var tipoPago in conteoTipoPago)
            {
                DataPoint point = new DataPoint();
                point.AxisLabel = tipoPago.Key;
                point.YValues = new double[] { tipoPago.Value };
                point.Color = colores[colorIndex % colores.Length];
                series.Points.Add(point);
                colorIndex++;
            }

            ChartGrafica.Series.Add(series);

            ChartGrafica.Legends.Clear();
            Legend legend = new Legend();
            legend.Title = "Tipos de Pago";
            colorIndex = 0;
            foreach (var tipoPago in conteoTipoPago)
            {
                legend.CustomItems.Add(colores[colorIndex % colores.Length], tipoPago.Key);
                colorIndex++;
            }
            ChartGrafica.Legends.Add(legend);
        }
    }

}