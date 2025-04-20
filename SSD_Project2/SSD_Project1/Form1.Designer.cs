namespace SSD_Project1
{
	partial class Form_Start
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
            this.button_loadData = new System.Windows.Forms.Button();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.label_startDate = new System.Windows.Forms.Label();
            this.label_endDate = new System.Windows.Forms.Label();
            this.openFileDialog_stockData = new System.Windows.Forms.OpenFileDialog();
            this.hScrollBar_Start = new System.Windows.Forms.HScrollBar();
            this.label_Start = new System.Windows.Forms.Label();
            this.toolTip_marginStart = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // button_loadData
            // 
            this.button_loadData.Location = new System.Drawing.Point(421, 85);
            this.button_loadData.Name = "button_loadData";
            this.button_loadData.Size = new System.Drawing.Size(86, 35);
            this.button_loadData.TabIndex = 0;
            this.button_loadData.Text = "Load";
            this.button_loadData.UseVisualStyleBackColor = true;
            this.button_loadData.Click += new System.EventHandler(this.button_loadData_Click);
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(675, 64);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(298, 26);
            this.dateTimePicker_startDate.TabIndex = 1;
            this.dateTimePicker_startDate.Value = new System.DateTime(2024, 3, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(675, 110);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(298, 26);
            this.dateTimePicker_endDate.TabIndex = 2;
            this.dateTimePicker_endDate.Value = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            // 
            // label_startDate
            // 
            this.label_startDate.AutoSize = true;
            this.label_startDate.Location = new System.Drawing.Point(572, 70);
            this.label_startDate.Name = "label_startDate";
            this.label_startDate.Size = new System.Drawing.Size(83, 20);
            this.label_startDate.TabIndex = 3;
            this.label_startDate.Text = "Start Date";
            // 
            // label_endDate
            // 
            this.label_endDate.AutoSize = true;
            this.label_endDate.Location = new System.Drawing.Point(572, 110);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(77, 20);
            this.label_endDate.TabIndex = 4;
            this.label_endDate.Text = "End Date";
            // 
            // openFileDialog_stockData
            // 
            this.openFileDialog_stockData.FileName = "openFileDialog";
            this.openFileDialog_stockData.Multiselect = true;
            // 
            // hScrollBar_Start
            // 
            this.hScrollBar_Start.LargeChange = 1;
            this.hScrollBar_Start.Location = new System.Drawing.Point(576, 190);
            this.hScrollBar_Start.Maximum = 4;
            this.hScrollBar_Start.Minimum = 1;
            this.hScrollBar_Start.Name = "hScrollBar_Start";
            this.hScrollBar_Start.Size = new System.Drawing.Size(400, 26);
            this.hScrollBar_Start.TabIndex = 5;
            this.hScrollBar_Start.Value = 1;
            this.hScrollBar_Start.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Start_Scroll);
            // 
            // label_Start
            // 
            this.label_Start.AutoSize = true;
            this.label_Start.Location = new System.Drawing.Point(282, 190);
            this.label_Start.Name = "label_Start";
            this.label_Start.Size = new System.Drawing.Size(252, 20);
            this.label_Start.TabIndex = 6;
            this.label_Start.Text = "Margin (Detect Peaks and Valleys)";
            // 
            // Form_Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1730, 969);
            this.Controls.Add(this.label_Start);
            this.Controls.Add(this.hScrollBar_Start);
            this.Controls.Add(this.label_endDate);
            this.Controls.Add(this.label_startDate);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.button_loadData);
            this.Name = "Form_Start";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_loadData;
		private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
		private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
		private System.Windows.Forms.Label label_startDate;
		private System.Windows.Forms.Label label_endDate;
		private System.Windows.Forms.OpenFileDialog openFileDialog_stockData;
        private System.Windows.Forms.HScrollBar hScrollBar_Start;
        private System.Windows.Forms.Label label_Start;
        private System.Windows.Forms.ToolTip toolTip_marginStart;
    }
}

