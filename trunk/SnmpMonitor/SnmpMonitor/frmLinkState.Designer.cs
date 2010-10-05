namespace SnmpMonitor
{
    partial class frmLinkState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLinkState));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdLinkState = new System.Windows.Forms.DataGridView();
            this.chtLinkState = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLinkState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtLinkState)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdLinkState);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chtLinkState);
            this.splitContainer1.Size = new System.Drawing.Size(684, 399);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 0;
            // 
            // grdLinkState
            // 
            this.grdLinkState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLinkState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLinkState.Location = new System.Drawing.Point(0, 0);
            this.grdLinkState.Name = "grdLinkState";
            this.grdLinkState.ReadOnly = true;
            this.grdLinkState.Size = new System.Drawing.Size(684, 195);
            this.grdLinkState.TabIndex = 0;
            // 
            // chtLinkState
            // 
            chartArea1.Name = "ChartArea1";
            this.chtLinkState.ChartAreas.Add(chartArea1);
            this.chtLinkState.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chtLinkState.Legends.Add(legend1);
            this.chtLinkState.Location = new System.Drawing.Point(0, 0);
            this.chtLinkState.Name = "chtLinkState";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Availability";
            this.chtLinkState.Series.Add(series1);
            this.chtLinkState.Size = new System.Drawing.Size(684, 200);
            this.chtLinkState.TabIndex = 0;
            this.chtLinkState.Text = "chart1";
            // 
            // frmLinkState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 399);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLinkState";
            this.Text = "frmLinkState";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLinkState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtLinkState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.DataGridView grdLinkState;
        public System.Windows.Forms.DataVisualization.Charting.Chart chtLinkState;
    }
}