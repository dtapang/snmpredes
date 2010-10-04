namespace SnmpMonitor
{
    partial class TrapSimulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrapSimulator));
            this.SendTrap = new System.Windows.Forms.Button();
            this.rdbLinkUp = new System.Windows.Forms.RadioButton();
            this.rdbLinkDown = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendTrap
            // 
            this.SendTrap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SendTrap.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SendTrap.Image = global::SnmpMonitor.Properties.Resources.trap_send1;
            this.SendTrap.Location = new System.Drawing.Point(204, 14);
            this.SendTrap.Name = "SendTrap";
            this.SendTrap.Size = new System.Drawing.Size(61, 47);
            this.SendTrap.TabIndex = 15;
            this.SendTrap.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SendTrap.UseVisualStyleBackColor = true;
            this.SendTrap.Click += new System.EventHandler(this.SendTrap_Click);
            // 
            // rdbLinkUp
            // 
            this.rdbLinkUp.AutoSize = true;
            this.rdbLinkUp.Checked = true;
            this.rdbLinkUp.Location = new System.Drawing.Point(8, 14);
            this.rdbLinkUp.Name = "rdbLinkUp";
            this.rdbLinkUp.Size = new System.Drawing.Size(62, 17);
            this.rdbLinkUp.TabIndex = 16;
            this.rdbLinkUp.TabStop = true;
            this.rdbLinkUp.Text = "Link Up";
            this.rdbLinkUp.UseVisualStyleBackColor = true;
            this.rdbLinkUp.CheckedChanged += new System.EventHandler(this.rdbLinkUp_CheckedChanged);
            // 
            // rdbLinkDown
            // 
            this.rdbLinkDown.AutoSize = true;
            this.rdbLinkDown.Location = new System.Drawing.Point(8, 37);
            this.rdbLinkDown.Name = "rdbLinkDown";
            this.rdbLinkDown.Size = new System.Drawing.Size(76, 17);
            this.rdbLinkDown.TabIndex = 17;
            this.rdbLinkDown.Text = "Link Down";
            this.rdbLinkDown.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Destino del Trap";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbLinkDown);
            this.groupBox1.Controls.Add(this.rdbLinkUp);
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 67);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(6, 35);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(192, 20);
            this.txtDestino.TabIndex = 20;
            this.txtDestino.Text = "127.0.0.1";
            this.txtDestino.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDestino);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.SendTrap);
            this.groupBox2.Location = new System.Drawing.Point(104, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 66);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // TrapSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 75);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrapSimulator";
            this.Text = "TrapSimulator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SendTrap;
        private System.Windows.Forms.RadioButton rdbLinkUp;
        private System.Windows.Forms.RadioButton rdbLinkDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}