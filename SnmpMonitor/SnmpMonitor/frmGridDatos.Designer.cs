namespace SnmpMonitor
{
    partial class frmGridDatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGridDatos));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timeStampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.counterValueInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.counterValueOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataInOutBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsInOut = new SnmpMonitor.dsInOut();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataInOutBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInOut)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timeStampDataGridViewTextBoxColumn,
            this.counterValueInDataGridViewTextBoxColumn,
            this.valueInDataGridViewTextBoxColumn,
            this.counterValueOutDataGridViewTextBoxColumn,
            this.valueOutDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dataInOutBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(621, 340);
            this.dataGridView1.TabIndex = 0;
            // 
            // timeStampDataGridViewTextBoxColumn
            // 
            this.timeStampDataGridViewTextBoxColumn.DataPropertyName = "TimeStamp";
            this.timeStampDataGridViewTextBoxColumn.HeaderText = "Hora";
            this.timeStampDataGridViewTextBoxColumn.Name = "timeStampDataGridViewTextBoxColumn";
            this.timeStampDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // counterValueInDataGridViewTextBoxColumn
            // 
            this.counterValueInDataGridViewTextBoxColumn.DataPropertyName = "CounterValueIn";
            this.counterValueInDataGridViewTextBoxColumn.HeaderText = "Contador In";
            this.counterValueInDataGridViewTextBoxColumn.Name = "counterValueInDataGridViewTextBoxColumn";
            this.counterValueInDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueInDataGridViewTextBoxColumn
            // 
            this.valueInDataGridViewTextBoxColumn.DataPropertyName = "ValueIn";
            this.valueInDataGridViewTextBoxColumn.HeaderText = "Kbps In";
            this.valueInDataGridViewTextBoxColumn.Name = "valueInDataGridViewTextBoxColumn";
            this.valueInDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // counterValueOutDataGridViewTextBoxColumn
            // 
            this.counterValueOutDataGridViewTextBoxColumn.DataPropertyName = "CounterValueOut";
            this.counterValueOutDataGridViewTextBoxColumn.HeaderText = "Contador Out";
            this.counterValueOutDataGridViewTextBoxColumn.Name = "counterValueOutDataGridViewTextBoxColumn";
            this.counterValueOutDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueOutDataGridViewTextBoxColumn
            // 
            this.valueOutDataGridViewTextBoxColumn.DataPropertyName = "ValueOut";
            this.valueOutDataGridViewTextBoxColumn.HeaderText = "Kbps Out";
            this.valueOutDataGridViewTextBoxColumn.Name = "valueOutDataGridViewTextBoxColumn";
            this.valueOutDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataInOutBindingSource
            // 
            this.dataInOutBindingSource.DataMember = "DataInOut";
            this.dataInOutBindingSource.DataSource = this.dsInOut;
            // 
            // dsInOut
            // 
            this.dsInOut.DataSetName = "dsInOut";
            this.dsInOut.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmGridDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 340);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGridDatos";
            this.Text = "Tabla de datos";
            this.Load += new System.EventHandler(this.frmGridDatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataInOutBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource dataInOutBindingSource;
        private dsInOut dsInOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeStampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn counterValueInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn counterValueOutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueOutDataGridViewTextBoxColumn;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}