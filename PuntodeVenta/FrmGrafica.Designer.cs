namespace PuntodeVenta
{
    partial class FrmGrafica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ChartGrafica = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rbMes = new System.Windows.Forms.RadioButton();
            this.rbAño = new System.Windows.Forms.RadioButton();
            this.rbTipoPago = new System.Windows.Forms.RadioButton();
            this.btnLeerA = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbGraficas = new System.Windows.Forms.ComboBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.lvData = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.ChartGrafica)).BeginInit();
            this.SuspendLayout();
            // 
            // ChartGrafica
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartGrafica.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartGrafica.Legends.Add(legend1);
            this.ChartGrafica.Location = new System.Drawing.Point(530, 53);
            this.ChartGrafica.Name = "ChartGrafica";
            this.ChartGrafica.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Enero";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Febrero";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Marzo";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Abril";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Mayo";
            this.ChartGrafica.Series.Add(series1);
            this.ChartGrafica.Series.Add(series2);
            this.ChartGrafica.Series.Add(series3);
            this.ChartGrafica.Series.Add(series4);
            this.ChartGrafica.Series.Add(series5);
            this.ChartGrafica.Size = new System.Drawing.Size(243, 247);
            this.ChartGrafica.TabIndex = 1;
            this.ChartGrafica.Text = "chart1";
            // 
            // rbMes
            // 
            this.rbMes.AutoSize = true;
            this.rbMes.Location = new System.Drawing.Point(250, 312);
            this.rbMes.Name = "rbMes";
            this.rbMes.Size = new System.Drawing.Size(56, 17);
            this.rbMes.TabIndex = 2;
            this.rbMes.TabStop = true;
            this.rbMes.Text = "Meses";
            this.rbMes.UseVisualStyleBackColor = true;
            this.rbMes.CheckedChanged += new System.EventHandler(this.rbMes_CheckedChanged);
            // 
            // rbAño
            // 
            this.rbAño.AutoSize = true;
            this.rbAño.Location = new System.Drawing.Point(250, 336);
            this.rbAño.Name = "rbAño";
            this.rbAño.Size = new System.Drawing.Size(44, 17);
            this.rbAño.TabIndex = 3;
            this.rbAño.TabStop = true;
            this.rbAño.Text = "Año";
            this.rbAño.UseVisualStyleBackColor = true;
            this.rbAño.CheckedChanged += new System.EventHandler(this.rbAño_CheckedChanged);
            // 
            // rbTipoPago
            // 
            this.rbTipoPago.AutoSize = true;
            this.rbTipoPago.Location = new System.Drawing.Point(250, 360);
            this.rbTipoPago.Name = "rbTipoPago";
            this.rbTipoPago.Size = new System.Drawing.Size(86, 17);
            this.rbTipoPago.TabIndex = 4;
            this.rbTipoPago.TabStop = true;
            this.rbTipoPago.Text = "Tipo dePago";
            this.rbTipoPago.UseVisualStyleBackColor = true;
            this.rbTipoPago.CheckedChanged += new System.EventHandler(this.rbTipoPago_CheckedChanged);
            // 
            // btnLeerA
            // 
            this.btnLeerA.Location = new System.Drawing.Point(26, 312);
            this.btnLeerA.Name = "btnLeerA";
            this.btnLeerA.Size = new System.Drawing.Size(75, 23);
            this.btnLeerA.TabIndex = 5;
            this.btnLeerA.Text = "Leer Archivo";
            this.btnLeerA.UseVisualStyleBackColor = true;
            this.btnLeerA.Click += new System.EventHandler(this.btnLeerA_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(26, 360);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(451, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Selecciona tipo de grafica ";
            // 
            // cbGraficas
            // 
            this.cbGraficas.FormattingEnabled = true;
            this.cbGraficas.Items.AddRange(new object[] {
            "Point",
            "FastPoint",
            "Bubble ",
            "Line",
            "Spline",
            "StepLine",
            "FastLine",
            "Bar",
            "StackedBar",
            "StackedBar100",
            "Column",
            "StackedColumn",
            "StackedColumn100",
            "Area",
            "SplineArea",
            "StackedArea",
            "StackedArea100",
            "Pie",
            "Doughnut",
            "Stock",
            "Candlestick",
            "Range",
            "SplineRange",
            "RangeBar",
            "RangeColumn",
            "Radar",
            "Polar",
            "ErrorBar",
            "BoxPlot",
            "Renko",
            "ThreeLineBreak",
            "Kagi",
            "PointAndFigure",
            "Funnel",
            "Pyramid"});
            this.cbGraficas.Location = new System.Drawing.Point(650, 320);
            this.cbGraficas.Name = "cbGraficas";
            this.cbGraficas.Size = new System.Drawing.Size(121, 21);
            this.cbGraficas.TabIndex = 9;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(698, 354);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionar.TabIndex = 10;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // lvData
            // 
            this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvData.HideSelection = false;
            this.lvData.Location = new System.Drawing.Point(26, 42);
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(415, 258);
            this.lvData.TabIndex = 11;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Fecha";
            this.columnHeader1.Width = 170;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Total";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tipo de pago";
            this.columnHeader3.Width = 95;
            // 
            // FrmGrafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvData);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.cbGraficas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLeerA);
            this.Controls.Add(this.rbTipoPago);
            this.Controls.Add(this.rbAño);
            this.Controls.Add(this.rbMes);
            this.Controls.Add(this.ChartGrafica);
            this.Name = "FrmGrafica";
            this.Text = "FrmGrafica";
            ((System.ComponentModel.ISupportInitialize)(this.ChartGrafica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartGrafica;
        private System.Windows.Forms.RadioButton rbMes;
        private System.Windows.Forms.RadioButton rbAño;
        private System.Windows.Forms.RadioButton rbTipoPago;
        private System.Windows.Forms.Button btnLeerA;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbGraficas;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.ListView lvData;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}