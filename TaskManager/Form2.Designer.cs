namespace TaskManager
{
    partial class Performance
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pRam = new System.Diagnostics.PerformanceCounter();
            this.pCpu = new System.Diagnostics.PerformanceCounter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroProgressBarCpu = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroProgressBarRam = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pRam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCpu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // pRam
            // 
            this.pRam.CategoryName = "Memory";
            this.pRam.CounterName = "% Committed Bytes In Use";
            // 
            // pCpu
            // 
            this.pCpu.CategoryName = "Processor";
            this.pCpu.CounterName = "% Processor Time";
            this.pCpu.InstanceName = "_Total";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // metroProgressBarCpu
            // 
            this.metroProgressBarCpu.Location = new System.Drawing.Point(153, 113);
            this.metroProgressBarCpu.Name = "metroProgressBarCpu";
            this.metroProgressBarCpu.Size = new System.Drawing.Size(387, 37);
            this.metroProgressBarCpu.TabIndex = 0;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(65, 113);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(82, 37);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "CPU";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(563, 113);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(31, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "0 %";
            // 
            // metroProgressBarRam
            // 
            this.metroProgressBarRam.Location = new System.Drawing.Point(153, 176);
            this.metroProgressBarRam.Name = "metroProgressBarRam";
            this.metroProgressBarRam.Size = new System.Drawing.Size(387, 37);
            this.metroProgressBarRam.TabIndex = 3;
            // 
            // metroLabel3
            // 
            this.metroLabel3.Location = new System.Drawing.Point(65, 176);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(82, 37);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "RAM";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(563, 176);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(31, 19);
            this.metroLabel4.TabIndex = 5;
            this.metroLabel4.Text = "0 %";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(153, 317);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "CPU";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "RAM";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(975, 508);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            // 
            // Performance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 875);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroProgressBarRam);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroProgressBarCpu);
            this.Name = "Performance";
            this.Text = "Performance";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pRam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCpu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.PerformanceCounter pRam;
        private System.Diagnostics.PerformanceCounter pCpu;
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroProgressBar metroProgressBarCpu;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroProgressBar metroProgressBarRam;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}