using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnmpMonitor
{
    public partial class frmConfigMonitor : Form
    {
        public frmConfigMonitor(SnmpConector cnx)
        {
            InitializeComponent();
            this.cnx = cnx;
            this.MibIn = cnx.MIBInData;
            this.MibOut = cnx.MIBDataOut;
            this.pollInterval = Convert.ToInt32(cnx.PollInterval);
            this.monitorTime = Convert.ToInt32(cnx.MonitorTime);
            this.interfaceIndex = Convert.ToInt32(cnx.InterfaceIndex);

            this.txtMibIn.Text = this.MibIn;
            this.txtMibOut.Text = this.MibOut;
            this.numPollInterval.Value = this.pollInterval;
            this.numMonitorTime.Value = this.monitorTime;
            this.numIfIndex.Value = this.interfaceIndex;
        }
        private SnmpConector cnx;
        private String MibIn;
        private String MibOut;
        private int pollInterval;
        private int monitorTime;
        private int interfaceIndex;

        private void frmConfigMonitor_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String warning;
            if (HayCambios())
            {
                if (HayCambiosMib())
                {
                    warning = "Está seguro que desea guardar los cambios?\n\rCambios en el identificador MIB pueden hacer que el programa no funcione correctamente";
                }
                else
                {
                    warning = "Está seguro que desea guardar los cambios?";
                }
                DialogResult r = MessageBox.Show(warning, "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (r == System.Windows.Forms.DialogResult.Yes)
                {
                    Guardar();
                    this.Close();
                }
                else
                {
                    
                }
            }
            else 
            {
                this.Close();
            }
        }
        private void Guardar()
        {
            if (this.MibIn != this.txtMibIn.Text)
            {
                this.cnx.MIBInData = this.txtMibIn.Text;
            }
            if (this.MibOut != this.txtMibOut.Text)
            {
                this.cnx.MIBDataOut = this.txtMibOut.Text;
            }
            if (this.pollInterval != this.numPollInterval.Value)
            {
                this.cnx.PollInterval = this.numPollInterval.Value.ToString();
            }
            if (this.monitorTime != this.numMonitorTime.Value)
            {
                this.cnx.MonitorTime = this.numMonitorTime.Value.ToString();
            }
            if (this.interfaceIndex != this.numIfIndex.Value)
            {
                this.cnx.InterfaceIndex = this.numIfIndex.Value.ToString();
            }
        }
        private Boolean HayCambios()
        {
            Boolean noHayCambios = true;
            
            noHayCambios = noHayCambios && (this.MibIn == this.txtMibIn.Text);
            noHayCambios = noHayCambios && (this.MibOut == this.txtMibOut.Text);
            noHayCambios = noHayCambios && (this.pollInterval == this.numPollInterval.Value);
            noHayCambios = noHayCambios && (this.monitorTime == this.numMonitorTime.Value);
            noHayCambios = noHayCambios && (this.interfaceIndex == this.numIfIndex.Value);

            return !noHayCambios;
        }
        private Boolean HayCambiosMib()
        {
            Boolean noHayCambios = true;

            noHayCambios = noHayCambios && (this.MibIn == this.txtMibIn.Text);
            noHayCambios = noHayCambios && (this.MibOut == this.txtMibOut.Text);
            
            return !noHayCambios;
        }

    }
}
