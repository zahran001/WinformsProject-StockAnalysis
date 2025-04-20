namespace SSD_Project1
{
    partial class Form_ChartDisplay
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dateTimePicker_modifyStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_modifyEndDate = new System.Windows.Forms.DateTimePicker();
            this.label_modifyStartDate = new System.Windows.Forms.Label();
            this.label_modifyEndDate = new System.Windows.Forms.Label();
            this.button_RefreshChart = new System.Windows.Forms.Button();
            this.chart_stockData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolTip_margin = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox_UpWaves = new System.Windows.Forms.ComboBox();
            this.comboBox_DownWaves = new System.Windows.Forms.ComboBox();
            this.label_Upwave = new System.Windows.Forms.Label();
            this.label_Downwave = new System.Windows.Forms.Label();
            this.label_SelectToDraw = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker_modifyStartDate
            // 
            this.dateTimePicker_modifyStartDate.Location = new System.Drawing.Point(1409, 23);
            this.dateTimePicker_modifyStartDate.Name = "dateTimePicker_modifyStartDate";
            this.dateTimePicker_modifyStartDate.Size = new System.Drawing.Size(295, 26);
            this.dateTimePicker_modifyStartDate.TabIndex = 0;
            this.dateTimePicker_modifyStartDate.Value = new System.DateTime(2024, 3, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_modifyEndDate
            // 
            this.dateTimePicker_modifyEndDate.Location = new System.Drawing.Point(1409, 93);
            this.dateTimePicker_modifyEndDate.Name = "dateTimePicker_modifyEndDate";
            this.dateTimePicker_modifyEndDate.Size = new System.Drawing.Size(295, 26);
            this.dateTimePicker_modifyEndDate.TabIndex = 1;
            this.dateTimePicker_modifyEndDate.Value = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            // 
            // label_modifyStartDate
            // 
            this.label_modifyStartDate.AutoSize = true;
            this.label_modifyStartDate.Location = new System.Drawing.Point(1273, 29);
            this.label_modifyStartDate.Name = "label_modifyStartDate";
            this.label_modifyStartDate.Size = new System.Drawing.Size(83, 20);
            this.label_modifyStartDate.TabIndex = 2;
            this.label_modifyStartDate.Text = "Start Date";
            // 
            // label_modifyEndDate
            // 
            this.label_modifyEndDate.AutoSize = true;
            this.label_modifyEndDate.Location = new System.Drawing.Point(1273, 99);
            this.label_modifyEndDate.Name = "label_modifyEndDate";
            this.label_modifyEndDate.Size = new System.Drawing.Size(77, 20);
            this.label_modifyEndDate.TabIndex = 3;
            this.label_modifyEndDate.Text = "End Date";
            // 
            // button_RefreshChart
            // 
            this.button_RefreshChart.Location = new System.Drawing.Point(1122, 60);
            this.button_RefreshChart.Name = "button_RefreshChart";
            this.button_RefreshChart.Size = new System.Drawing.Size(108, 37);
            this.button_RefreshChart.TabIndex = 4;
            this.button_RefreshChart.Text = "Refresh";
            this.button_RefreshChart.UseVisualStyleBackColor = true;
            this.button_RefreshChart.Click += new System.EventHandler(this.button_RefreshChart_Click);
            // 
            // chart_stockData
            // 
            chartArea7.Name = "CandlestickArea";
            chartArea8.Name = "VolumeArea";
            this.chart_stockData.ChartAreas.Add(chartArea7);
            this.chart_stockData.ChartAreas.Add(chartArea8);
            legend4.Name = "Legend1";
            this.chart_stockData.Legends.Add(legend4);
            this.chart_stockData.Location = new System.Drawing.Point(12, 155);
            this.chart_stockData.Name = "chart_stockData";
            series7.ChartArea = "CandlestickArea";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series7.Legend = "Legend1";
            series7.Name = "Series_OHLC";
            series7.YValuesPerPoint = 4;
            series8.ChartArea = "VolumeArea";
            series8.Legend = "Legend1";
            series8.Name = "Series_Volume";
            this.chart_stockData.Series.Add(series7);
            this.chart_stockData.Series.Add(series8);
            this.chart_stockData.Size = new System.Drawing.Size(1726, 699);
            this.chart_stockData.TabIndex = 5;
            this.chart_stockData.Text = "chart1";
            // 
            // comboBox_UpWaves
            // 
            this.comboBox_UpWaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_UpWaves.FormattingEnabled = true;
            this.comboBox_UpWaves.Location = new System.Drawing.Point(428, 27);
            this.comboBox_UpWaves.Name = "comboBox_UpWaves";
            this.comboBox_UpWaves.Size = new System.Drawing.Size(362, 28);
            this.comboBox_UpWaves.TabIndex = 6;
            this.comboBox_UpWaves.SelectedIndexChanged += new System.EventHandler(this.comboBox_UpWaves_SelectedIndexChanged);
            // 
            // comboBox_DownWaves
            // 
            this.comboBox_DownWaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DownWaves.FormattingEnabled = true;
            this.comboBox_DownWaves.Location = new System.Drawing.Point(428, 82);
            this.comboBox_DownWaves.Name = "comboBox_DownWaves";
            this.comboBox_DownWaves.Size = new System.Drawing.Size(362, 28);
            this.comboBox_DownWaves.TabIndex = 7;
            this.comboBox_DownWaves.SelectedIndexChanged += new System.EventHandler(this.comboBox_DownWaves_SelectedIndexChanged);
            // 
            // label_Upwave
            // 
            this.label_Upwave.AutoSize = true;
            this.label_Upwave.Location = new System.Drawing.Point(271, 35);
            this.label_Upwave.Name = "label_Upwave";
            this.label_Upwave.Size = new System.Drawing.Size(79, 20);
            this.label_Upwave.TabIndex = 8;
            this.label_Upwave.Text = "UP waves";
            // 
            // label_Downwave
            // 
            this.label_Downwave.AutoSize = true;
            this.label_Downwave.Location = new System.Drawing.Point(271, 85);
            this.label_Downwave.Name = "label_Downwave";
            this.label_Downwave.Size = new System.Drawing.Size(107, 20);
            this.label_Downwave.TabIndex = 9;
            this.label_Downwave.Text = "DOWN waves";
            // 
            // label_SelectToDraw
            // 
            this.label_SelectToDraw.AutoSize = true;
            this.label_SelectToDraw.Location = new System.Drawing.Point(22, 60);
            this.label_SelectToDraw.Name = "label_SelectToDraw";
            this.label_SelectToDraw.Size = new System.Drawing.Size(188, 20);
            this.label_SelectToDraw.TabIndex = 10;
            this.label_SelectToDraw.Text = "Select a wave to visualize";
            // 
            // Form_ChartDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1750, 812);
            this.Controls.Add(this.label_SelectToDraw);
            this.Controls.Add(this.label_Downwave);
            this.Controls.Add(this.label_Upwave);
            this.Controls.Add(this.comboBox_DownWaves);
            this.Controls.Add(this.comboBox_UpWaves);
            this.Controls.Add(this.chart_stockData);
            this.Controls.Add(this.button_RefreshChart);
            this.Controls.Add(this.label_modifyEndDate);
            this.Controls.Add(this.label_modifyStartDate);
            this.Controls.Add(this.dateTimePicker_modifyEndDate);
            this.Controls.Add(this.dateTimePicker_modifyStartDate);
            this.Name = "Form_ChartDisplay";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_modifyStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_modifyEndDate;
        private System.Windows.Forms.Label label_modifyStartDate;
        private System.Windows.Forms.Label label_modifyEndDate;
        private System.Windows.Forms.Button button_RefreshChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_stockData;
        private System.Windows.Forms.ToolTip toolTip_margin;
        private System.Windows.Forms.ComboBox comboBox_UpWaves;
        private System.Windows.Forms.ComboBox comboBox_DownWaves;
        private System.Windows.Forms.Label label_Upwave;
        private System.Windows.Forms.Label label_Downwave;
        private System.Windows.Forms.Label label_SelectToDraw;
    }
}