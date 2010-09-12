namespace SnmpMonitor
{
    partial class frmConfigMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigMonitor));
            this.numPollInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMibIn = new System.Windows.Forms.TextBox();
            this.txtMibOut = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numMonitorTime = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numIfIndex = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numPollInterval)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonitorTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIfIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // numPollInterval
            // 
            this.numPollInterval.Location = new System.Drawing.Point(159, 14);
            this.numPollInterval.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.numPollInterval.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPollInterval.Name = "numPollInterval";
            this.numPollInterval.Size = new System.Drawing.Size(83, 20);
            this.numPollInterval.TabIndex = 0;
            this.numPollInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Poll Interval (En milisegundos)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numIfIndex);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numMonitorTime);
            this.groupBox1.Controls.Add(this.txtMibOut);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMibIn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numPollInterval);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 152);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(186, 161);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 24);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(105, 161);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MIB data in";
            // 
            // txtMibIn
            // 
            this.txtMibIn.Location = new System.Drawing.Point(73, 93);
            this.txtMibIn.Name = "txtMibIn";
            this.txtMibIn.Size = new System.Drawing.Size(169, 20);
            this.txtMibIn.TabIndex = 3;
            // 
            // txtMibOut
            // 
            this.txtMibOut.Location = new System.Drawing.Point(73, 119);
            this.txtMibOut.Name = "txtMibOut";
            this.txtMibOut.Size = new System.Drawing.Size(169, 20);
            this.txtMibOut.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "MIB data out";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Monitoreo (En minutos)";
            // 
            // numMonitorTime
            // 
            this.numMonitorTime.Location = new System.Drawing.Point(178, 40);
            this.numMonitorTime.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numMonitorTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMonitorTime.Name = "numMonitorTime";
            this.numMonitorTime.Size = new System.Drawing.Size(64, 20);
            this.numMonitorTime.TabIndex = 6;
            this.numMonitorTime.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Indice de interfaz";
            // 
            // numIfIndex
            // 
            this.numIfIndex.Location = new System.Drawing.Point(178, 66);
            this.numIfIndex.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numIfIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numIfIndex.Name = "numIfIndex";
            this.numIfIndex.Size = new System.Drawing.Size(64, 20);
            this.numIfIndex.TabIndex = 9;
            this.numIfIndex.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // frmConfigMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 196);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfigMonitor";
            this.Text = "Configurar";
            this.Load += new System.EventHandler(this.frmConfigMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPollInterval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonitorTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIfIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numPollInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtMibOut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMibIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numMonitorTime;
        private System.Windows.Forms.NumericUpDown numIfIndex;
        private System.Windows.Forms.Label label5;
    }
}